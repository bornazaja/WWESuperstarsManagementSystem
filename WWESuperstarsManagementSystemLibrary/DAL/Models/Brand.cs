using System;
using System.Collections.Generic;

#nullable disable

namespace WWESuperstarsManagementSystemLibrary.DAL.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Superstars = new HashSet<Superstar>();
        }

        public int IDBrand { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Superstar> Superstars { get; set; }
    }
}
