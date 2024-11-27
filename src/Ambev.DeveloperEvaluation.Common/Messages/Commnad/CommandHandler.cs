using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Common.Messages.Commnad
{
    public abstract class CommandHandler
    {
        protected readonly DomainValidationContext _domainValidationContext;

        protected CommandHandler(DomainValidationContext domainValidationContext)
        {
            _domainValidationContext = domainValidationContext;
        }
        
        protected bool ValidCommand<TResult>(Command<TResult> mensagem)
        {
            if (!mensagem.IsValid())
            {
                var result = mensagem.ValidationResult.Errors;
                _domainValidationContext.AddValidationErrors(result);

                return false;
            }
            return true;
        }
    }
}
