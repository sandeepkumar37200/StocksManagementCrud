using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ProductsUseCase;

namespace Plugins.DateStore.InMemory
{
   
    public class ProductsInMemoryRepository : IProductRepository
    {
        // Seeding data in List
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, CategoryId=1 , Name="Iced Tea",Quantity=2, Price=30},
            new Product { ProductId = 2, CategoryId=1 , Name="Canada Dry",Quantity=1, Price=60},
            new Product { ProductId = 3, CategoryId=2 , Name="Brown Bread",Quantity=2, Price=40},
            new Product { ProductId = 4, CategoryId=1 , Name="Cake",Quantity=2, Price=40}
        };

        public void AddProduct(Product product)
        {
            if (_products != null && _products.Count() > 0)
            {
                var maxId = _products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            if (_products == null) _products = new List<Product>();
            _products.Add(product);
        }

        // loadCategory act as default variable
        public IEnumerable<Product> GetAllProducts(bool loadCategory = false)
        {
            if (!loadCategory)
            {
                 _products.ForEach(x =>
                {
                    if (x.CategoryId.HasValue)
                    {
                        CategoriesInMemoryRepository categorgies = new CategoriesInMemoryRepository();
                        x.Category = categorgies.GetCategoryById(x.CategoryId.Value);
                    }
                });
                return _products ?? new List<Product>();
            }
            else
            {
                if (_products != null && _products.Count > 0)
                {
                    //Applying loop on _product List
                    _products.ForEach(x =>
                    {
                        if (x.CategoryId.HasValue)
                        {
                            CategoriesInMemoryRepository categorgies = new CategoriesInMemoryRepository();
                            x.Category = categorgies.GetCategoryById(x.CategoryId.Value);
                        }
                    });
                }
            }
            return _products ?? new List<Product>();
        }


        public void UpdateProduct(Product product, int productId)
        {
            if (product.ProductId != productId) return;

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;
            }
        }

        public void DeleteProduct(int productId)
        {
            var data = _products.FirstOrDefault(x => x.ProductId == productId);
            if (data != null)
            {
                _products.Remove(data);
            }
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = _products.Where(x => x.CategoryId == categoryId).ToList();
            if (products != null)
            {
                return products;
            }
            else
                return new List<Product>();
        }

        public Product GetProductById(int productId, bool loadCategory = false)
        {
            var data = _products.FirstOrDefault(x => x.ProductId == productId);
            if (data != null)
            {
                var product = new Product
                {
                    ProductId = data.ProductId,
                    CategoryId = data.CategoryId,
                    Name = data.Name,
                    Quantity = data.Quantity,
                    Price = data.Price
                };
                if (loadCategory)
                {
                    CategoriesInMemoryRepository categorgies = new CategoriesInMemoryRepository();

                    product.Category = categorgies.GetCategoryById(product.CategoryId.Value);
                }
                return product;
            }
            return null;
        }

       
    }
}

