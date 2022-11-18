using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exercise2_4.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reproductor : ContentPage
    {
        public Reproductor()
        {
            InitializeComponent();
        }
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            await CrossMediaManager.Current.Stop();
        }
    }
}