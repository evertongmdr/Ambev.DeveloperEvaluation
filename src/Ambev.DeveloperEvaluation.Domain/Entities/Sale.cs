using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {


         const int MaxQuantityItems = 20;
        /// <summary>
        /// Indicates the manimum quantity of identical items allowed in the sale.
        /// </summary>
         const int MinQuantityIdenticalItemsDicount10Porcent = 5;

         const int MaxQuantityIdenticalItemsDicount10Porcent = 9;

         const int MinQuantityIdenticalItemsDicount20Porcent = 10;

         const int MaxQuantityIdenticalItemsDicount20Porcent = 20;


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

        public decimal AmountToPay { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal DiscountAmount { get; private set; }

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

        private bool ExistsSaleItem(Guid productId)
        {
            return SaleItems.Any(si => si.ProductId == productId);
        }

        private SaleItem GetSaleItemById(Guid productId)
        {
            return SaleItems.FirstOrDefault(si => si.ProductId == productId);
        }

        public string AddOrRemoveSaleItem(Guid productId, decimal price, int units)
        {
            if (ExistsSaleItem(productId))
            {
                var existingSaleItem = GetSaleItemById(productId);
                existingSaleItem.AddUnits(units);

                if(!existingSaleItem.HasUnits())
                    _saleItems.Remove(existingSaleItem);
                
            } else
            {
                if (units <= 0)
                    return "It is not possible to add a product item with zero or negative quantity.";

                var newSaleItem = CreateSaleItem(productId, price, units);
                _saleItems.Add(newSaleItem);
            }

            var existsMessageError = ValidateSaleRestrictions();

            if (!string.IsNullOrEmpty(existsMessageError))
                return existsMessageError;

            CalculateSaleValue();

            return string.Empty;

        }

        private SaleItem CreateSaleItem(Guid productId, decimal price, int units)
        {
            return new SaleItem
            {
                SaleId = Id,
                ProductId = productId,
                Quantity = units,
                UnitPrice = price
            };
        }

        private void CalculateSaleValue()
        {
            TotalAmount = SaleItems.Sum(p => p.CalculateValue());

            CalculateTotalDiscountValue();
        }

        private void CalculateTotalDiscountValue()
        {

            decimal discountRate = GetDiscountRateValue();

            var discount = TotalAmount * discountRate;

            DiscountAmount = discount;

            AmountToPay = TotalAmount - discount;
        }

        private decimal GetDiscountRateValue()
        {

            var saleItemsWithHighestIdenticalMinimum = SaleItems.Where(x =>
                x.Quantity > MinQuantityIdenticalItemsDicount10Porcent).ToList();

            if (!saleItemsWithHighestIdenticalMinimum.Any())
                return 0;

            var existsSaleItemsIntervalBetweenDicount20Porcent = saleItemsWithHighestIdenticalMinimum
                 .Where(x => x.Quantity >= MinQuantityIdenticalItemsDicount20Porcent &&
                 x.Quantity <= MaxQuantityIdenticalItemsDicount20Porcent).ToList();


            if (existsSaleItemsIntervalBetweenDicount20Porcent.Any())
                return 0.20M;


            return 0.10M;
        }

        private string ValidateSaleRestrictions()
        {

            var saleItemsWithMaxAllowedQuantity = SaleItems.Where(x =>
                x.Quantity > MaxQuantityItems).ToList();

            if (saleItemsWithMaxAllowedQuantity.Any())
                return $"It is not possible to sell more than {MaxQuantityItems} identical products";

            return string.Empty;
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
