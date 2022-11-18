using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaManager;
using Plugin.Media;
using Exercise2_4.Modelos;
using Exercise2_4.Vistas;

namespace Exercise2_4
{
    public partial class MainPage : ContentPage
    {
        String pathVideo="";
        public MainPage()
        {
            InitializeComponent();
        }
        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("AVISO", "La camará no esta disponible.", "OK"); return;
            }
            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "Vid01.mp4",
                Directory = "MysVideos"
            });
            if (file == null)
                return;
            await DisplayAlert("AVISO", "El video se ha Guardado en: "+file.Path, "OK");
            videoV.Source = file.Path;
            pathVideo = file.Path;
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathVideo))
            {
                var respuesta = await App.BaseDatos.guardaVideos(new Video { path = pathVideo });
                if (respuesta == 1)
                {
                    await DisplayAlert("AVISO", "SE GUARDO EL VIDEO EN SQLite.", "OK");
                    videoV.Source = null;
                    pathVideo = "";
                }
                else
                {
                    await DisplayAlert("ALERTA", "ALGO FALLO AL GUARDAR A SQLite", "OK");
                }
            }
            else
            {
                await DisplayAlert("ALERTA", "No se Encontro la ruta de tu video Grabado!", "OK");
            }
        }
        
        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            var listado = await App.BaseDatos.GetListVid();//LLENAR LA LISTAA
            if (listado != null)
            {
                if (listado.Count() > 0)
                {
                    await Navigation.PushAsync(new ListadoVid());
                }
                else
                {
                    await DisplayAlert("ALERTA","NO HAY ELEMENTOS EN TU LISTA","OK");
                }
            }
            else 
            {
                await DisplayAlert("ALERTA", "NO HAY ELEMENTOS EN TU LISTA", "OK");
            }
        }
    }
}
