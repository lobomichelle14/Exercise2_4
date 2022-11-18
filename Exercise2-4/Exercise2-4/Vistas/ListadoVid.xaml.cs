using Exercise2_4.Modelos;
using MediaManager;
using MediaManager.Forms;
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
    public partial class ListadoVid : ContentPage
    {
        public ListadoVid()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listadoVideos.ItemsSource = await App.BaseDatos.GetListVid();//LLENAR LA LISTAA
        }
        private async void listadoVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Video aa = (Video)e.Item;
            String[] nom = aa.path.Split('/');
            String nom1 = nom[nom.Length - 1];
            Reproductor rep = new Reproductor();
            rep.BindingContext = aa;

            rep.Title = "Reproduciendo: " + nom1;

            //await CrossMediaManager.Current.Play(aa.path);
            await Navigation.PushAsync(rep);
        }
    }
}