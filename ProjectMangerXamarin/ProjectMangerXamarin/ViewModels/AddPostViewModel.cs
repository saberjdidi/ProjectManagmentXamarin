using ProjectMangerXamarin.Helpers;
using ProjectMangerXamarin.Models;
using ProjectMangerXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjectMangerXamarin.ViewModels
{
   public class AddPostViewModel : BaseViewModel
    {
        #region service
        IPostService postService = new PostService();
        #endregion

        private PostModel _post;
        public PostModel Post
        {
            get
            {
                return _post;
            }
            set
            {
                _post = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AddPostViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            Post = new PostModel();
        }

        private async void OnSave()
        {
            if (string.IsNullOrWhiteSpace(Post.title) || string.IsNullOrWhiteSpace(Post.body))
            {
                ToastHelper.Show("Please fill in all fields.");
                return;
            }

            var post = Post;
            var success = await postService.AddPostAsync(post);
            if (success)
            {
                ToastHelper.Show("Post added successfully");
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
