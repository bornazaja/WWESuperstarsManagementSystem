using System.ComponentModel.DataAnnotations;

namespace WWESuperstarsManagementSystemLibrary.BLL.DTO
{
    public class CitySaveDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int CountryID { get; set; }
    }
}
