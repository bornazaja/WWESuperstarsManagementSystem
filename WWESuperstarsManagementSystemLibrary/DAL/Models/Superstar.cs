using System;
using System.Collections.Generic;

#nullable disable

namespace WWESuperstarsManagementSystemLibrary.DAL.Models
{
    public partial class Superstar
    {
        public int IDSuperstar { get; set; }
        public string Name { get; set; }
        public decimal HeightCm { get; set; }
        public decimal WeightKg { get; set; }
        public int GenderID { get; set; }
        public int BrandID { get; set; }
        public int CityID { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
