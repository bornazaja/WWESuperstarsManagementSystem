using System.ComponentModel.DataAnnotations;

namespace WWESuperstarsManagementSystemLibrary.BLL.DTO
{
    public class GenderSaveDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
