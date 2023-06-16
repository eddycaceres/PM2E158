using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E158.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaVisitas : ContentPage
    {
        public ListaVisitas()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = await App.Instancia.GetAll();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void mapa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageMapa());
        }
    }
}