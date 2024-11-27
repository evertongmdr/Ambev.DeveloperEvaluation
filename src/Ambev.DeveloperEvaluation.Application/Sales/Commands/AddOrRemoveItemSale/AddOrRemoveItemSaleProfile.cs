using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale
{
    public class AddOrRemoveItemSaleProfile : Profile
    {

        public AddOrRemoveItemSaleProfile()
        {

            CreateMap<Sale, AddOrRemoveItemSaleResult>();

            CreateMap<SaleItem, AddOrRemoveItemSaleItemResult>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name));

        }
    }
}

