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
    public partial class GridVisitas : ContentPage
    {
        public GridVisitas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listemple.ItemsSource = await App.Instancia.GetAll();
        }

        
    }
}