using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Indicates the maximum quantity of identical items allowed in the sale.
        /// </summary>
        const int MaxQuantityIdenticalItems = 20;

        /// <summary>
        /// Gets the identifier of client associated with the sale
        /// </summary>
        public Guid ClientId { get; private set; }

        /// <summary>
        /// Gets the identifier of the company where the sale was made.
        /// </summary>
        public Guid CompanyId { get; private set; }

        /// <summary>
        /// Gets the sale number 
        /// </summary>
        public long Number { get; private set; }

        /// <summary>
        /// Gets the sale Status
        /// </summary>
        public SaleStatus Status { get; private set; }

        /// <summary>
        /// Gets the total value of the sale.
        /// </summary>
        public decimal Totalvalue { get; private set; }

        /// <summary>
        /// Gets the Discount Value of sale
        /// </summary>
        public decimal Discountvalue { get; private set; }

        /// <summary>
        /// Gets the date and time when sale was finished.
        /// </summary>
        public DateTime? FinalizedAt { get; private set; }

       
        private readonly List<SaleItem> _saleItems;

        /// <summary>
        /// Gets list items associated with the sale.
        /// </summary
        public IReadOnlyCollection<SaleItem> SaleItems => _saleItems;

        /// <summary>
        /// Property mapping of EF Core.<br /> 
        /// Gets information about the client associated with the sale. 
        /// </summary>
        public User Client { get; private set; }

        /// <summary>
        /// Property mapping of EF Core. <br /> 
        /// Gets information about the Company that made sale.
        /// </summary>
        public Company Company { get; private set; }

        public void InitiateSale()
        {
            Status = SaleStatus.Initialized;
        }
        
        public void CancelSale()
        {
            Status = SaleStatus.Cancelled;
        }

        public void FinisheSale()
        {
            Status = SaleStatus.Fineshed;
        }

        public SaleItem? ExistsSaleItem(Guid productId)
        {
            return SaleItems.FirstOrDefault(si => si.ProductId == productId);
        }

        public void AddSaleItem(SaleItem saleItem)
        {
            _saleItems.Add(saleItem);
            CalculateOrderValue();

        }

        public void CalculateOrderValue()
        {
            Totalvalue = SaleItems.Sum(p => p.CalculateValue());

            CalculateTotalDiscountValue();
        }


        public void CalculateTotalDiscountValue()
        {

        }

        public static class SaleFactory
        {
            public static Sale Initiate(Guid clientId, Guid companyId)
            {
                var sale = new Sale 
                { 
                    ClientId = clientId, 
                    CompanyId = companyId, 
                   
                };

                sale.InitiateSale();
                
                return sale;    
            }
        }

        
    }
}
