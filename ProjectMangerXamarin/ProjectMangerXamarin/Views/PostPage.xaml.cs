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
    public partial class PostPage : ContentPage
    {
        PostViewModel postViewModel;
        public PostPage()
        {
            InitializeComponent();
            BindingContext = postViewModel = new PostViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            postViewModel.OnAppearing();
        }
    }
}