using Newtonsoft.Json;
using ProjectMangerXamarin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangerXamarin.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        public PostService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<bool> AddPostAsync(PostModel postModel)
        {
            if (postModel.id == 0)
            {
                string json = JsonConvert.SerializeObject(postModel);
                Debug.WriteLine($"json : {json}");
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("posts", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(postModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync($"posts/{postModel.id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            }
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"posts/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<List<PostModel>> GetAllPostsAsync()
        {
            var listPosts = new List<PostModel>();
            HttpResponseMessage response = await _httpClient.GetAsync("posts");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                listPosts = JsonConvert.DeserializeObject<List<PostModel>>(content);
            }
            return await Task.FromResult(listPosts);
        }

        public async Task<PostModel> GetPostAsync(int id)
        {
            var post = new PostModel();
            HttpResponseMessage response = await _httpClient.GetAsync($"posts/{id}");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                post = JsonConvert.DeserializeObject<PostModel>(content);
            }
            return await Task.FromResult(post);
        }
    }
}
