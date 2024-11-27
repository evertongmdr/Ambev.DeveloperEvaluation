using Ambev.DeveloperEvaluation.Common.Messages.Commnad;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using static Ambev.DeveloperEvaluation.Domain.Entities.Sale;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.StartSale
{
    public class StartSaleHandler : CommandHandler, IRequestHandler<StartSaleCommand, StartSaleResult?>
    {

        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public StartSaleHandler(DomainValidationContext domainValidationContext, ISaleRepository saleRepository,
            IMapper mapper) : base(domainValidationContext)
        {
            {
                _saleRepository = saleRepository;
                _mapper = mapper;
            }
        }

        public async Task<StartSaleResult?> Handle(StartSaleCommand command, CancellationToken cancellationToken)
        {

            if (!ValidCommand(command)) return null;

            var sale = SaleFactory.Initiate(command.ClientId, command.CompanyId);

            var createdSale = await _saleRepository.CreateAsync(sale);

            var result = _mapper.Map<StartSaleResult>(createdSale);

            // chamar o event de criação
            return result;
        }

    }
}
