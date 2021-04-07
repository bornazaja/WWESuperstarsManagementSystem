using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WWESuperstarsManagementSystemLibrary.BLL.Validation.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Validation.Validators.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Validation.Validators.Implementations
{
    public class DataAnnotationValidator : IValidator
    {
        public IEnumerable<ValidationResultDto> Validate(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return validationResults.GroupBy(
                x => x.MemberNames.FirstOrDefault(),
                x => x.ErrorMessage,
                (key, errorMessages) => new ValidationResultDto { PropertyName = key, ErrorMessages = errorMessages }).ToList();
        }
    }
}
