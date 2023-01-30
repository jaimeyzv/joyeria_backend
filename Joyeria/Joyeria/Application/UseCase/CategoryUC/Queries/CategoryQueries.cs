using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Application.UseCase.CategoryUC.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var models = _unitOfWork.Categories.GetCategoriesAsync();
            
        }

        public Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
