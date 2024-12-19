using ProjectMangerXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangerXamarin.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public SQLiteAsyncConnection _database;
        public ProductRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProductInfo>().Wait();
        }

        public async Task<bool> AddProductAsync(ProductInfo product)
        {
            if(product.ProductId > 0)
            {
               await _database.UpdateAsync(product);
            } else
            {
                await _database.InsertAsync(product);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            await _database.DeleteAsync<ProductInfo>(id);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<ProductInfo>> GetAllProductsAsync()
        {
            var response = await _database.Table<ProductInfo>().ToListAsync();
            return await Task.FromResult(response);
        }

        public async Task<ProductInfo> GetProductAsync(int id)
        {
            var response = await _database.Table<ProductInfo>().Where(a => a.ProductId == id).FirstOrDefaultAsync();
            return await Task.FromResult(response);
        }
    }
}
