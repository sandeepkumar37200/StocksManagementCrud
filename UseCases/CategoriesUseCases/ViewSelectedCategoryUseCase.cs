using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.CategoriesUseCases
{
    public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category? Execute(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

    }
}
