using ProjectMangerXamarin.Models;
using ProjectMangerXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMangerXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditProductPage : ContentPage
    {
        public ProductInfo ProductInfo { get; set; }
        public AddEditProductPage()
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel();
        }

        public AddEditProductPage(ProductInfo productInfo)
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel();

            if(productInfo != null)
            {
                ((AddProductViewModel)BindingContext).ProductInfo = productInfo;
            }
        }
    }
}