using Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddItemSale
{
    public class AddItemSaleProfile : Profile
    {
        public AddItemSaleProfile()
        {
            CreateMap<AddItemSaleRequest, AddItemSaleCommand>();
            CreateMap<AddItemSaleResult, AddItemSaleResponse>();
            CreateMap<AddItemSaleItemResult, AddItemSaleItemResponse>();
        }
    }
}
