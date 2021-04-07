using System.ComponentModel.DataAnnotations;

namespace WWESuperstarsManagementSystemLibrary.BLL.DTO
{
    public class BrandSaveDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
