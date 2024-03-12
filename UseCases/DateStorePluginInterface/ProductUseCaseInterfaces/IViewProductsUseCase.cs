using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.ProductsUseCase
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
    }
}