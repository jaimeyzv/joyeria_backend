using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Domain.Entities;
using Microsoft.VisualBasic;

namespace Joyeria.Application.UseCase.ProductUC.Commands
{
    public class ProductCommands : IProductCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductModel> CreateAsync(ProductModel productToCreate)
        {
            var domain = _mapper.Map<Product>(productToCreate);
            await _unitOfWork.Products.CreateAsync(domain);
            await _unitOfWork.SaveChangesAsync();
            return productToCreate;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ProductModel> UpdateAsync(ProductModel productToUpdate)
        {
            var domain = _mapper.Map<Product>(productToUpdate);
            await _unitOfWork.Products.UpdateAsync(domain);
            await _unitOfWork.SaveChangesAsync();
            return productToUpdate;
        }
    }
}
