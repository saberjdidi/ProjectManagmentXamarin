using ProjectMangerXamarin.ViewModels;
using ProjectMangerXamarin.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProjectMangerXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddEditProductPage), typeof(AddEditProductPage));
            Routing.RegisterRoute(nameof(AddEditPostPage), typeof(AddEditPostPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
