using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCase
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(Product product, int productId)
        {
            _productRepository.UpdateProduct(product, productId);
        }
    }
}
