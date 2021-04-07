using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Validation.DTO;

namespace WWESuperstarsManagementSystemLibrary.BLL.Validation.Validators.Interfaces
{
    public interface IValidator
    {
        IEnumerable<ValidationResultDto> Validate(object obj);
    }
}
