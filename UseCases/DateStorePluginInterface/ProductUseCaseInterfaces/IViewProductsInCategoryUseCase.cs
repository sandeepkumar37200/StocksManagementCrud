using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.ProductsUseCase
{
    public interface IViewProductsInCategoryUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}