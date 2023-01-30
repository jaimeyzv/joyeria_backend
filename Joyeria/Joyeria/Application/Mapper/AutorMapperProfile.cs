using AutoMapper;
using Joyeria.Application.ViewModels;
using Joyeria.Domain.Entities;
using Joyeria.Domain.Entities.Report;

namespace Joyeria.Application.Mapper
{
    public class AutorMapperProfile : Profile
    {
        public AutorMapperProfile()
        {
            CreateMap<CategoryVM, Category>().ReverseMap();
            CreateMap<ComplaintVM, Complaint>().ReverseMap();
            CreateMap<OrderItemVM, OrderItem>().ReverseMap();
            CreateMap<OrderVM, Order>().ReverseMap();
            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ReporteVM, ReporteVentas>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();
        }
    }
}
