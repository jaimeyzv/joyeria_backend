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

        public async Task<CategoryModel> CreateAsync(Category categoryToCreate)
        {
            var models = _mapper.Map<CategoryModel>(categoryToCreate);
            await _unitOfWork.Categories.CreateAsync(categoryToCreate);
            await _unitOfWork.SaveChangesAsync();

            return models;
        }

        public async Task<CategoryModel> UpdateAsync(Category categoryToUpdate)
        {
            var models = _mapper.Map<CategoryModel>(categoryToUpdate);
            await _unitOfWork.Categories.UpdateAsync(categoryToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return models;
        }
    }
}
