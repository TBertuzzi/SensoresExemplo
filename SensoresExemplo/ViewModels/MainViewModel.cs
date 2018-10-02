using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Plugin.Sensors;

namespace SensoresExemplo.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ISensorModel> Sensors { get; }


        public MainViewModel()
        {
            this.Sensors = new ObservableCollection<ISensorModel>
            {
                new SensorModel<MotionReading>(CrossSensors.Accelerometer, "Acelerômetro"),
                new SensorModel<MotionReading>(CrossSensors.Gyroscope, "Giroscópio"),
                new SensorModel<MotionReading>(CrossSensors.Magnetometer, "Magnetômetro"),
                new SensorModel<CompassReading>(CrossSensors.Compass, "Bússola"),
                new SensorModel<DeviceOrientation>(CrossSensors.DeviceOrientation, "Posição"),
                new SensorModel<double>(CrossSensors.AmbientLight, "Luz"),
                new SensorModel<double>(CrossSensors.Barometer, "Pressão"),
                new SensorModel<int>(CrossSensors.Pedometer, "Passos"),
                new SensorModel<bool>(CrossSensors.Proximity, "Proximidade")
            };
        }
    }
}
