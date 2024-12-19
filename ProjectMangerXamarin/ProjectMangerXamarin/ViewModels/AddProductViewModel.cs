using ProjectMangerXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjectMangerXamarin.ViewModels
{
   public class AddProductViewModel : BaseViewModel
    {
        private ProductInfo _productInfo;
        public ProductInfo ProductInfo
        {
            get
            {
                return _productInfo;
            }
            set
            {
                _productInfo = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AddProductViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            ProductInfo = new ProductInfo();
        }

        private async void OnSave()
        {
            var product = ProductInfo;
            await App.ProductRepository.AddProductAsync(product);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
