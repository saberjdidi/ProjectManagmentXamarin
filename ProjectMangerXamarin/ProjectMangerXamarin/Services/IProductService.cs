using ProjectMangerXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangerXamarin.Services
{
   public interface IProductService
    {
        Task<bool> AddProductAsync(ProductInfo product);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductInfo> GetProductAsync(int id);
        Task<List<ProductInfo>> GetAllProductsAsync();
    }
}
