using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCase
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Execute()
        {
            bool loadCategory = false;
            return _productRepository.GetAllProducts(loadCategory);
        }
    }
}
