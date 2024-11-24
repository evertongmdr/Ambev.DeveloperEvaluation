using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.StartSale
{
    public class StartSaleHandler : IRequestHandler<StartSaleCommand, StartSaleResult>
    {
        public async Task<StartSaleResult> Handle(StartSaleCommand command, CancellationToken cancellationToken)
        {
           var validator = new StartSaleCommandValidator();
           var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);


        }
    }
}
