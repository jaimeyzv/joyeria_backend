using AutoMapper;
using Joyeria.Application.UseCase.CategoryUC.Commands;
using Joyeria.Application.ViewModels;
using Joyeria.Domain.Entities;
using Joyeria.Domain.Entities.Report;

namespace Joyeria.Infrastructure.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryVM, CategoryModel>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();

            CreateMap<ComplaintVM, Complaint>().ReverseMap();
            CreateMap<OrderItemVM, OrderItem>().ReverseMap();
            CreateMap<OrderVM, Order>().ReverseMap();
            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ReporteVM, ReporteVentas>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();

        }
    }
}
