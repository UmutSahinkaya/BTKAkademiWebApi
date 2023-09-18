using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager repositoryManager)
        {
            _manager = repositoryManager;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _manager.Category.GetAllCategoriesAsync(trackChanges);
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            var category= await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(id);
            return category;
        }
    }
}
