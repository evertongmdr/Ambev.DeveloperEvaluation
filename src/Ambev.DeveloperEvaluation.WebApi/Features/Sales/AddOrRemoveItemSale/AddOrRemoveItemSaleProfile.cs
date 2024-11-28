using Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddItemSale
{
    public class AddOrRemoveItemSaleProfile : Profile
    {
        public AddOrRemoveItemSaleProfile()
        {
            CreateMap<AddOrRemoveItemSaleRequest, AddOrRemoveItemSaleCommand>();
            CreateMap<AddOrRemoveItemSaleResult, AddOrRemoveItemSaleResponse>();
            CreateMap<AddOrRemoveItemSaleItemResult, AddOrRemoveItemSaleItemResponse>();
        }
    }
}
