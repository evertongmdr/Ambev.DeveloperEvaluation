using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem 
    {
        /// <summary>
        /// Gets the identifier of sale associated with the sale item
        /// </summary>
        public Guid SaleId { get; private set; }

        /// <summary>
        /// Gets the identifier of product associated with the sale item
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Gets quantity of products
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        ///Gets unit price of product
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Property mapping of EF Core.<br /> 
        /// </summary
        public Sale Sale { get; set; }

        /// <summary>
        /// Property mapping of EF Core.<br /> 
        /// </summary
        public Product Product { get; set; }
    }
}
