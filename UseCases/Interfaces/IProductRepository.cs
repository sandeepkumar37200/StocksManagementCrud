using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.ProductsUseCase
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product, int productId);
        IEnumerable<Product> GetAllProducts(bool loadCategory);
        Product? GetProductById(int productId, bool loadCategory);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}