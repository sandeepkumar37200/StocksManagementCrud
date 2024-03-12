using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases;

namespace Plugins.DateStore.InMemory
{
    public class CategoriesInMemoryRepository : ICategoryRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId=1,Name="Beverage",Description="Beverage"},
            new Category{ CategoryId=2,Name="Bakery",Description="Bakery"},
            new Category { CategoryId=3,Name="Meat",Description="Meat"}
        };

        public IEnumerable<Category> GetCategories() => _categories;


        public Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                // We never retun actual data object we always make an copy of it
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };

            }
            return null;
        }
        public void AddCategory(Category category)
        {
            if (_categories != null && _categories.Count() > 0)
            {
                var MaxId = _categories.Max(x => x.CategoryId);
                category.CategoryId = MaxId + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
            if (_categories == null) _categories = new List<Category>();
            _categories.Add(category);
        }
       
        public void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpadte = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpadte != null)
            {
                categoryToUpadte.Name = category.Name;
                categoryToUpadte.Description = category.Description;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var cateogry = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (cateogry != null)
            {
                _categories.Remove(cateogry);
            }
        }

    }
}
