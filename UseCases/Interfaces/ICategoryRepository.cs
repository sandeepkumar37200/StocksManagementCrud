using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.CategoriesUseCases
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category? GetCategoryById(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(int categoryId, Category category);
        void DeleteCategory(int categoryId);
      
    }
}