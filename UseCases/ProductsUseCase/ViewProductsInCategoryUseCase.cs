using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCase
{
    public class ViewProductsInCategoryUseCase : IViewProductsInCategoryUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductsInCategoryUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(int categoryId)
        {
            return _productRepository.GetProductsByCategoryId(categoryId);
        }
    }
}
