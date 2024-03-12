using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCase
{
    public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewSelectedProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product? Execute(int productId)
        {
            bool loadCategory = false;
            return _productRepository.GetProductById(productId,loadCategory);
        }
    }
}
