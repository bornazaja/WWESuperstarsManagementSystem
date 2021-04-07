using System;
using System.Collections.Generic;

#nullable disable

namespace WWESuperstarsManagementSystemLibrary.DAL.Models
{
    public partial class City
    {
        public City()
        {
            Superstars = new HashSet<Superstar>();
        }

        public int IDCity { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Superstar> Superstars { get; set; }
    }
}
