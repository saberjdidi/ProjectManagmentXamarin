using ProjectMangerXamarin.Repositories;
using ProjectMangerXamarin.Services;
using ProjectMangerXamarin.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMangerXamarin
{
    public partial class App : Application
    {
        static ProductRepository _productRepository;
        public static ProductRepository ProductRepository
        {
            get
            {
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Product.db3"));
                }
                return _productRepository;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
