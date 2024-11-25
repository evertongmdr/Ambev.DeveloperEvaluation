using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using static Ambev.DeveloperEvaluation.Domain.Entities.Sale;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.StartSale
{
    public class StartSaleHandler : IRequestHandler<StartSaleCommand, StartSaleResult>
    {

        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public StartSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<StartSaleResult> Handle(StartSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new StartSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = SaleFactory.Initiate(command.ClientId, command.CompanyId);

            var createdSale = await _saleRepository.CreateAsync(sale);

            var result = _mapper.Map<StartSaleResult>(createdSale);

            // chamar o event de criação
            return result;
        }
    }
}
