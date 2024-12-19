using ProjectMangerXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjectMangerXamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}