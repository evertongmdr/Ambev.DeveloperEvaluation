using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale
{
    public class AddItemSaleProfile : Profile
    {

        public AddItemSaleProfile()
        {

            CreateMap<Sale, AddItemSaleResult>();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Totalvalue, opt => opt.MapFrom(src => src.Totalvalue))
            //.ForMember(dest => dest.Discountvalue, opt => opt.MapFrom(src => src.Discountvalue));

            CreateMap<SaleItem, AddItemSaleItemResult>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name));

        }
    }
}

