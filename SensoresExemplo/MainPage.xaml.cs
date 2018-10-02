using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensoresExemplo.ViewModels;
using Xamarin.Forms;

namespace SensoresExemplo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();

        }
    }
}
