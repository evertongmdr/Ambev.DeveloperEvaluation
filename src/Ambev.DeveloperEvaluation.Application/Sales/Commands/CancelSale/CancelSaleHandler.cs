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
        private readonly IMapper _mapper;

        public CancelSaleHandler(DomainValidationContext domainValidationContext,
            ISaleRepository saleRepository, IMapper mapper) : base(domainValidationContext)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
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

            sale.CancelSale();

            _saleRepository.Update(sale);
            sale.AddEvent(new SaleCancelledEvent(sale.Id));

            if (!await PersistData(_saleRepository.UnitOfWork))
                return null;

            return new CancelSaleResult { Success = true };
        }
    }
}
