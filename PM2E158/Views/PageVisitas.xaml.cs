using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubicaciongps.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E158.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVisitas : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public PageVisitas()
        {
            InitializeComponent();
            BindingContext = new LocalizacionViewModel();
        }

        public string Getimage64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    String Base64 = Convert.ToBase64String(fotobyte);

                    return Base64;
                }
            }
            return null;
        }

        public byte[] GetimageBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    return fotobyte;
                }
            }
            return null;
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            
                var visit = new Models.Visitas
                {
                    foto = GetimageBytes(),
                    Latitud = latitud.Text,
                    Longitud = longitud.Text,
                    Descripcion = Desc.Text                
                };
                if (await App.Instancia.AddVisit(visit) > 0)
                {
                    await DisplayAlert("Alerta", "Visita Ingresada con Exito", "Ok");
                }
                else

                    await DisplayAlert("Alerta", "Ha Ocurido un Error", "Ok");


            
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MYAPP",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        private async void lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListaVisitas());
        }

        private void salir_Clicked(object sender, EventArgs e)
        {

        }
    }
}