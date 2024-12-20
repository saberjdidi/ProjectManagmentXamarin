using ProjectMangerXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangerXamarin.Services
{
   public interface IPostService
    {
        Task<bool> AddPostAsync(PostModel postModel);
        Task<bool> DeletePostAsync(int id);
        Task<PostModel> GetPostAsync(int id);
        Task<List<PostModel>> GetAllPostsAsync();
    }
}
