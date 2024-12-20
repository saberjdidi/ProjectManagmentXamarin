using ProjectMangerXamarin.Helpers;
using ProjectMangerXamarin.Models;
using ProjectMangerXamarin.Services;
using ProjectMangerXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectMangerXamarin.ViewModels
{
   public class PostViewModel : BaseViewModel
    {
        #region service
        IPostService postService = new PostService();
        #endregion

        #region Command
        public Command LoadPostCommand { get; }
        public Command AddPostCommand { get; }
        public Command DeletePostCommand { get; }
        public Command EditPostCommand { get; }
        public Command ClearPostCommand { get; }
        #endregion

        public INavigation Navigation { get; set; }
        public ObservableCollection<PostModel> Posts { get; }

        public PostViewModel(INavigation _navigation)
        {
            LoadPostCommand = new Command(async () => await LoadData());
            AddPostCommand = new Command(OnAdd);
            EditPostCommand = new Command<PostModel>(OnEdit);
            DeletePostCommand = new Command<PostModel>(OnDelete);
            ClearPostCommand = new Command(OnClear);
            Posts = new ObservableCollection<PostModel>();
            Navigation = _navigation;
        }

        #region Methods
        async Task LoadData()
        {
            IsBusy = true;
            try
            {
                Posts.Clear();
                var listPosts = await postService.GetAllPostsAsync();
                foreach (var item in listPosts)
                {
                    Debug.WriteLine($"post => id: {item.id} - title: {item.title}");
                    Posts.Add(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAdd(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddEditPostPage));
        }

        private async void OnEdit(PostModel post)
        {
            await Navigation.PushAsync(new AddEditPostPage(post));
        }

        private async void OnDelete(PostModel post)
        {
            if (post == null)
            {
                return;
            }
            var confirm = await Application.Current.MainPage.DisplayAlert("Confirm", "Delete this Post?", "Yes", "No");
            if (confirm)
            {               
                var success = await postService.DeletePostAsync(post.id);
                if (success)
                {
                    ToastHelper.Show("Post deleted successfully");
                    await LoadData();
                }
            }

            
        }

        private void OnClear()
        {
            Posts.Clear();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
        #endregion
    }
}
