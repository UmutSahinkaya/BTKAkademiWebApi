using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : 
            base(context)
        {
        }
        public void CreateOneCategory(Category category) => Create(category);

        public void DeleteOneCategory(Category category)=> Delete(category);
        public void UpdateOneCategory(Category category)=> Update(category);
        
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await FindAll(trackChanges)
                .OrderBy(c=>c.CategoryName)
                .ToListAsync();
            return categories;
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category= await FindByCondition(c=>c.CategoryId.Equals(id),trackChanges)
                .SingleOrDefaultAsync();
            return category;
        }

        
    }
}
