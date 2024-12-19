using ProjectMangerXamarin.Models;
using ProjectMangerXamarin.Services;
using ProjectMangerXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectMangerXamarin.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        #region service
        IProductService productService = new ProductService();
        #endregion
        public Command LoadProductCommand { get; }
        public Command AddProductCommand { get; }
        public Command ProductEditCommand { get; }
        public Command ProductDeleteCommand { get; }
        public Command ClearProductCommand { get; }

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
        public ObservableCollection<ProductInfo> Products { get; }

        public ProductViewModel(INavigation _navigation)
        {
            LoadProductCommand = new Command(async ()=> await ExecuteLoadProduct());
            AddProductCommand = new Command(OnAddProduct);
            ProductEditCommand = new Command<ProductInfo>(OnEditProduct);
            ProductDeleteCommand = new Command<ProductInfo>(OnDeleteProduct);
            ClearProductCommand = new Command(OnClearProduct);
            Products = new ObservableCollection<ProductInfo>();
            Navigation = _navigation;
        }

        async Task ExecuteLoadProduct()
        {
            IsBusy = true;
            try
            {
                Products.Clear();
                //using sqlite
                var listProduct = await App.ProductRepository.GetAllProductsAsync();
                //using Web API
                //var listProduct = await productService.GetAllProductsAsync();
                foreach (var product in listProduct)
                {
                    Products.Add(product);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddProduct(object obj)
        {
           await Shell.Current.GoToAsync(nameof(AddEditProductPage));
           //await Navigation.PushAsync(AddEditProductPage());
        }
        //private async Task OnAddEditProduct()
        //{
        //    await Shell.Current.GoToAsync(nameof(AddEditProductPage));
        //}

        private async void OnEditProduct(ProductInfo product)
        {
            await Navigation.PushAsync(new AddEditProductPage(product));
        }

        private async void OnDeleteProduct(ProductInfo product)
        {
            if(product == null)
            {
                return;
            }

            await App.ProductRepository.DeleteProductAsync(product.ProductId);
            await ExecuteLoadProduct();
        }

        private void OnClearProduct()
        {
            Products.Clear();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
