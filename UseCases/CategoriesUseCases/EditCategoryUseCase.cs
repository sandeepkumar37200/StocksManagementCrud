using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.CategoriesUseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Execute(int categoryId, Category category)
        {
            _categoryRepository.UpdateCategory(categoryId, category);
        }
    }
}
