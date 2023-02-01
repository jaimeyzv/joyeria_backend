using AutoMapper;
using Joyeria.Application.UseCase.CategoryUC.Commands;
using Joyeria.Application.UseCase.ComplaintUC.Commands;
using Joyeria.Application.UseCase.OrderUC.Commands;
using Joyeria.Application.ViewModels;
using Joyeria.Domain.Entities;
using Joyeria.Domain.Entities.Report;

namespace Joyeria.Application.Mapper
{
    public class AutorMapperProfile : Profile
    {
        public AutorMapperProfile()
        {
            CreateMap<CategoryVM, CategoryModel>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();

            CreateMap<ComplaintVM, ComplaintModel>().ReverseMap();
            CreateMap<ComplaintModel, Complaint>().ReverseMap();

            CreateMap<OrderItemVM, OrderItem>().ReverseMap();

            CreateMap<OrderVM, OrderModel>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();

            CreateMap<ProductVM, Product>().ReverseMap();

            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ReporteVM, ReporteVentas>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();
        }
    }
}
