using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.Sensors;
using Xamarin.Forms;

namespace SensoresExemplo.ViewModels
{
    public class SensorModel<TReading> : ISensorModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        protected virtual bool Set<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(property, value))
                return false;

            property = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }


        IDisposable sensorSub;

        public SensorModel(ISensor<TReading> sensor, string valueName, string title = null)
        {
            this.Title = title ?? sensor.GetType().Name.Replace("Impl", String.Empty);
            this.ValueName = valueName;
            this.ToggleText = sensor.IsAvailable ? "Iniciar" : "Sensor indisponivel";

            this.Toggle = new Command(() =>
            {
                if (!sensor.IsAvailable)
                    return;

                if (this.sensorSub == null)
                {
                    this.ToggleText = "Parar";
                    this.sensorSub = sensor
                        .WhenReadingTaken()
                        .Sample(TimeSpan.FromMilliseconds(500))
                        .Subscribe(this.Update);
                }
                else
                {
                    this.ToggleText = "Iniciar";
                    this.sensorSub.Dispose();
                    this.sensorSub = null;
                }
            });
        }


        public string Title { get; }
        public ICommand Toggle { get; }
        public string ValueName { get; }


        string sensorValue;
        public string Value
        {
            get => this.sensorValue;
            set => this.Set(ref this.sensorValue, value);
        }


        string toggleText;
        public string ToggleText
        {
            get => this.toggleText;
            set => this.Set(ref this.toggleText, value);
        }


        protected virtual void Update(TReading reading) => Device.BeginInvokeOnMainThread(() =>
            this.Value = reading.ToString()
        );



       
    }


}
