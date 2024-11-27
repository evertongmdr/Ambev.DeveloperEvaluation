namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddItemSale
{

    public class AddOrRemoveItemSaleResponse
    {
        public Guid Id { get; set; }
        public decimal Totalvalue { get; set; }

        public decimal Discountvalue { get; set; }

        public List<AddOrRemoveItemSaleItemResponse> SaleItems { get; set; }
    }

    public class AddOrRemoveItemSaleItemResponse
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
