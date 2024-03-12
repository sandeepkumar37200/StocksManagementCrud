using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases;

namespace Plugins.DataStore.SQL.Repository
{
    public class CategorySQLRepository : ICategoryRepository
    {
        private readonly MarketDbContext db;

        public CategorySQLRepository(MarketDbContext marketDbContext)
        {
            this.db = marketDbContext;
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = db.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category == null) return;
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId)
            {
                return;
            }

            var cate = db.Categories.Find(categoryId);
            if (cate == null) return;

            cate.Name = category.Name;
            cate.Description = category.Description;
            db.SaveChanges();
        }
    }
}
