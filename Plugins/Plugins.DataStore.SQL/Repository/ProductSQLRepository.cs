using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ProductsUseCase;

namespace Plugins.DataStore.SQL.Repository
{
    public class ProductSQLRepository : IProductRepository
    {
        private readonly MarketDbContext db;

        public ProductSQLRepository(MarketDbContext dbContext)
        {
            this.db = dbContext;
        }
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null) return;

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts(bool loadCategory=false)
        {
            if (loadCategory)
                return db.Products.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList();
            else
                return db.Products.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList();
        }

        public Product GetProductById(int productId, bool loadCategory=false)
        {
            if (loadCategory)
                return db.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == productId);
            else
                return db.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product, int productId)
        {
            if (product.ProductId != productId) return;

            var prod = db.Products.Find(productId);

            if (prod == null) return;

            prod.CategoryId = product.CategoryId;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            db.SaveChanges();
           
        }
    }
}
