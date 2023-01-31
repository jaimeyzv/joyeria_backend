using Joyeria.Application.Interfaces.Repositories;
using Joyeria.Domain.Entities;
using Joyeria.Persitance.Shared;
using Microsoft.EntityFrameworkCore;

namespace Joyeria.Persitance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JoyeriaDbContext _dbContext;

        public CategoryRepository(JoyeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category categoryToCreate)
        {
            await _dbContext.Categories.AddAsync(categoryToCreate);
            return categoryToCreate;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<Category> UpdateAsync(Category categoryToUpdate)
        {
            _dbContext.Entry(categoryToUpdate).State = EntityState.Detached;
            _dbContext.Set<Category>().Update(categoryToUpdate);
            _dbContext.SaveChanges();
            return categoryToUpdate;
            //_dbContext.Categories.Update(categoryToUpdate);
            //return await Task.FromResult(categoryToUpdate);
        }
    }
}
