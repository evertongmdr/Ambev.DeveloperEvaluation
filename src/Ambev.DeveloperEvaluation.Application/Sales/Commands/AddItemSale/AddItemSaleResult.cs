namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale
{
    public class AddItemSaleResult
    {
        public Guid Id { get; set; }
        public decimal Totalvalue { get;  set; }

        public decimal Discountvalue { get;  set; }

        public List<AddItemSaleItemResult> SaleItems { get; set; }
    }

    public class AddItemSaleItemResult
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    } 

}
