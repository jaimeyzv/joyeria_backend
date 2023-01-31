using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.CategoryUC.Commands
{
    public class CategoryCommands : ICategoryCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryModel> CreateAsync(CategoryModel categoryToCreate)
        {
            var domain = _mapper.Map<Category>(categoryToCreate);
            await _unitOfWork.Categories.CreateAsync(domain);
            await _unitOfWork.SaveChangesAsync();

            return categoryToCreate;

        }

        public async Task<CategoryModel> UpdateAsync(CategoryModel categoryToUpdate)
        {
            var domain = _mapper.Map<Category>(categoryToUpdate);
            await _unitOfWork.Categories.UpdateAsync(domain);
            
            await _unitOfWork.SaveChangesAsync();

            return categoryToUpdate;
        }
    }
}
