using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.CategoriesUseCases
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}