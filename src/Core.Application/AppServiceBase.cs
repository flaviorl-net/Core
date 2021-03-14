using Core.Domain;

namespace Core.Application
{
    public class AppServiceBase : IAppServiceBase
    {
        protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Errors)
            {
                validationAppResult.Errors.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}
