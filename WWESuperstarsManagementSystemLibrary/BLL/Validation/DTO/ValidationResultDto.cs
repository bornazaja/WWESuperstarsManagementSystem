using System.Collections.Generic;

namespace WWESuperstarsManagementSystemLibrary.BLL.Validation.DTO
{
    public class ValidationResultDto
    {
        public string PropertyName { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
