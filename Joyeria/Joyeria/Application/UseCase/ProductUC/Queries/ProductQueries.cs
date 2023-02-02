using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Application.UseCase.ProductUC.Commands;

namespace Joyeria.Application.UseCase.ProductUC.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductModel> GetProductByIdAsync(Guid id)
        {
            var domain = await _unitOfWork.Products.GetProductByIdAsync(id);
            return _mapper.Map<ProductModel>(domain);
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            var domain = await _unitOfWork.Products.GetProductsAsync();
            var model = _mapper.Map<IEnumerable<ProductModel>>(domain);
            return model;
            
        }

    }
}
