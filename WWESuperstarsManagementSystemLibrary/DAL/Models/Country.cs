using System;
using System.Collections.Generic;

#nullable disable

namespace WWESuperstarsManagementSystemLibrary.DAL.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int IDCountry { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
