using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale
{
    /// <summary>
    /// Represents the command to add an item to a sale.
    /// </summary>
    public class AddItemSaleCommand : IRequest<AddItemSaleResult>
    {
        /// <summary>
        /// Unique identifier of the sale.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Unique identifier of the product to be added to the sale.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the product to be added to the sale.
        /// </summary>
        public int QuantityProduct { get; set; }
    }
}
