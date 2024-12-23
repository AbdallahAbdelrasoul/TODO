using FluentValidation;
using FluentValidation.Results;

namespace TODO.Domain.Shared.Validation
{
    public interface IValidationModel<T>
    {
        AbstractValidator<T> Validator { get; }
        bool IsValid => Validator.Validate((T)this).IsValid;
        List<ValidationFailure>? ValidationErrors => Validator.Validate((T)this).Errors;
    }
}
