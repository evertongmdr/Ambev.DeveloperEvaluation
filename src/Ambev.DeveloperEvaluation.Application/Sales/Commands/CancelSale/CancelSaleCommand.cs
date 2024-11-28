using Ambev.DeveloperEvaluation.Common.Messages;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale
{
    public class CancelSaleCommand : Command<CancelSaleResult>
    {
        public Guid SaleId { get; set; }
    }
}
