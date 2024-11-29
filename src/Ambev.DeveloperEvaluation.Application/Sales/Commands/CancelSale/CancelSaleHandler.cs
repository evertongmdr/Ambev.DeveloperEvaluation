using Ambev.DeveloperEvaluation.Application.Categorys.DeleteCategory;
using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Common.Messages;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale
{
    public class CancelSaleHandler : CommandHandler, IRequestHandler<CancelSaleCommand, CancelSaleResult?>
    {
        private readonly ISaleRepository _saleRepository;
    
        public CancelSaleHandler(DomainValidationContext domainValidationContext,
            ISaleRepository saleRepository) : base(domainValidationContext)
        {
            _saleRepository = saleRepository;
        }

        public async Task<CancelSaleResult?> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
        {
            if (!ValidCommand(command)) return null;

            var sale = await _saleRepository.GetByIdAsync(command.SaleId);

            if (sale == null)
            {
                AddErro("Cancel Sale Error", "The sale was not found");
                return null;
            }

            if (!sale.IsSaleActiveForModification())
            {
                AddErro("Cancel Sale Error", $"Sale cannot be modified because it is {sale.Status}");
                return null;
            }

            sale.CancelSale();

            _saleRepository.Update(sale);
            sale.AddEvent(new SaleCancelledEvent(sale.Id));

            if (!await PersistData(_saleRepository.UnitOfWork))
                return null;

            return new CancelSaleResult { Success = true };
        }
    }
}
