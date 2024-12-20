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
    public partial class AddEditPostPage : ContentPage
    {
        public PostModel Post { get; set; }
        public AddEditPostPage()
        {
            InitializeComponent();
            BindingContext = new AddPostViewModel();
        }

        public AddEditPostPage(PostModel post)
        {
            InitializeComponent();
            BindingContext = new AddPostViewModel();

            if (post != null)
            {
                ((AddPostViewModel)BindingContext).Post = post;
            }
        }
    }
}