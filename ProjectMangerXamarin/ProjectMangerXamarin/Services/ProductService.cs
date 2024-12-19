using Newtonsoft.Json;
using ProjectMangerXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangerXamarin.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/");
        }
        public async Task<bool> AddProductAsync(ProductInfo product)
        {
           if(product.ProductId == 0)
            {
                string json = JsonConvert.SerializeObject(product);
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
            } else
            {
                string json = JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync($"posts/{product.ProductId}", content);

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

        public async Task<bool> DeleteProductAsync(int id)
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

        public async Task<List<ProductInfo>> GetAllProductsAsync()
        {
            var products = new List<ProductInfo>();
            HttpResponseMessage response = await _httpClient.GetAsync("posts");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductInfo>>(content);
            }
            return await Task.FromResult(products);
        }

        public async Task<ProductInfo> GetProductAsync(int id)
        {
            var product = new ProductInfo();
            HttpResponseMessage response = await _httpClient.GetAsync($"posts/{id}");

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductInfo>(content);
            }
            return await Task.FromResult(product);
        }
    }
}
