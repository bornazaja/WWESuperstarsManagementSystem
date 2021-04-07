using System;
using System.ComponentModel.DataAnnotations;

namespace WWESuperstarsManagementSystemLibrary.BLL.DTO
{
    public class SuperstarSaveDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal HeightCm { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal WeightKg { get; set; }

        [Required]
        public int GenderID { get; set; }

        [Required]
        public int BrandID { get; set; }

        [Required]
        public int CityID { get; set; }
    }
}
