﻿using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {

        /// <summary>
        /// Gets name of the product.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets the quantity of the product available in stock.
        /// </summary>
        public int StockQuantity { get; private set; }

        /// <summary>
        /// Property mapping of EF Core.
        /// </summary
        public List<SaleItem> SaleItems { get; set; }

    }
}
