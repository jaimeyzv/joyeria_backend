//using Joyeria.Application.Interfaces;
//using Joyeria.Application.Interfaces.Services;
//using Joyeria.Domain.Entities;

//namespace Joyeria.Infrastructure.Services
//{
//    public class CategoryService : ICategoryService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CategoryService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<CategoryUC> CreateAsync(CategoryUC categoryToCreate)
//        {
//            await _unitOfWork.Categories.CreateAsync(categoryToCreate);
//            await _unitOfWork.SaveChangesAsync();

//            return categoryToCreate;
//        }

//        public async Task<IEnumerable<CategoryUC>> GetCategoriesAsync()
//        {
//            return await _unitOfWork.Categories.GetCategoriesAsync();
//        }

//        public async Task<CategoryUC> GetCategoryByIdAsync(int id)
//        {
//            return await _unitOfWork.Categories.GetCategoryByIdAsync(id);
//        }

//        public async Task<CategoryUC> UpdateAsync(CategoryUC categoryToUpdate)
//        {
//            await _unitOfWork.Categories.UpdateAsync(categoryToUpdate);
//            await _unitOfWork.SaveChangesAsync();
//            return categoryToUpdate;
//        }
//    }
//}
