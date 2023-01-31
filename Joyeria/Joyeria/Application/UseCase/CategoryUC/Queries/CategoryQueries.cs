using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Application.UseCase.CategoryUC.Commands;

namespace Joyeria.Application.UseCase.CategoryUC.Queries
{
    public class CategoryQueries : ICategoryQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetCategoriesAsync();
            var model = _mapper.Map<IEnumerable<CategoryModel>>(categories);
            return model;
            
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            var categories = await _unitOfWork.Categories.GetCategoryByIdAsync(id);

            var model = _mapper.Map<CategoryModel>(categories);

            return model;


        }
    }
}
