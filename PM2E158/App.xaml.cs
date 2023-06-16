using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E158.Controles;


namespace PM2E158
{
    public partial class App : Application
    {

        static Controles.BDExamen dExamen;

        public static  Controles.BDExamen Instancia
        {
            get
            {
                if (dExamen == null)
                {
                    String dbname = "Proc.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfulp = Path.Combine(dbpath, dbname);
                    dExamen = new Controles.BDExamen(dbfulp);
                }
                return dExamen;
            }
        }



        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageVisitas());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
