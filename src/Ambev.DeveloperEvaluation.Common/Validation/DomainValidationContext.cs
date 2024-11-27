using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Common.Validation
{
    public class DomainValidationContext
    {
        public readonly ValidationResult DomainValidation;

        public DomainValidationContext()
        {
            DomainValidation = new ValidationResult(); ;
        }

        public bool ExistNofications => DomainValidation.IsValid;

        public void AddValidationError(string key, string message)
        {
            DomainValidation.Errors.Add(new ValidationFailure(key, message));
        }

        public void AddValidationErrors(List<ValidationFailure> validations)
        {
            DomainValidation.Errors.AddRange(validations);
        }

    }
}
