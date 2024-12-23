using FluentValidation.Results;
using TODO.Domain.Shared.Exceptions;

namespace TODO.Domain.Shared.Validation
{
    public class ValidationEngine : IValidationEngine
    {
        public List<ValidationFailure>? Validate<T>(IValidationModel<T>? input, bool throwException = true)
        {
            if (input is null)
            {
                return null;
            }

            if (input.IsValid)
            {
                return null;
            }

            if (throwException)
            {
                throw new DataNotValidException(errors: input.ValidationErrors);
            }
            return input.ValidationErrors;
        }
    }
}
