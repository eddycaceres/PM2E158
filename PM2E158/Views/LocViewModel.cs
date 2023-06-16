using System;
using System.Collections.Generic;
using System.Text;
using ubicaciongps.Modelos;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ubicaciongps.ViewModel
{
    public class LocalizacionViewModel : LocalizacionModel
    {
        public Command LocalizameCommand { get; set; }

        public LocalizacionViewModel()
        {
            LocalizameCommand = new Command(Localizar);
        }

        private async void Localizar()
        {
            try
            {
                var localizacion = await Geolocation.GetLastKnownLocationAsync();
                if (localizacion == null)
                {
                    localizacion = await Geolocation.GetLocationAsync(
                        new GeolocationRequest()
                        {
                            DesiredAccuracy = GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(25)
                        }
                        );
                }
                if (localizacion == null)
                {
                    Error = "No se donde estoy";
                }
                else
                {
                    Longitud = localizacion.Longitude;
                    Latitud = localizacion.Latitude;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}