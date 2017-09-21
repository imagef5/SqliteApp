using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SqliteApp.Models;

namespace SqliteApp.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _databaseContext.Products.ToListAsync();

                return products;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _databaseContext.Products.FindAsync(id);

                return product;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                var tracking = await _databaseContext.Products.AddAsync(product);
                var isAdded = tracking.State == EntityState.Added;

                await _databaseContext.SaveChangesAsync();

                return isAdded;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                var tracking = _databaseContext.Update(product);
                var isModified = tracking.State == EntityState.Modified;

                await _databaseContext.SaveChangesAsync();

                return isModified;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            try
            {
                var product = await _databaseContext.Products.FindAsync(id);

                var tracking = _databaseContext.Remove(product);
                var isDeleted = tracking.State == EntityState.Deleted;

                await _databaseContext.SaveChangesAsync();

                return isDeleted;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public async Task<IList<Product>> QueryProductsAsync(Func<Product, bool> predicate)
        {
            try
            {
                var products = _databaseContext.Products.Where(predicate);

                return products.ToList();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }
    }
}
