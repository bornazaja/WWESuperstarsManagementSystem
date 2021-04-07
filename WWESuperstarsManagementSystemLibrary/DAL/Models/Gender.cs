using System;
using System.Collections.Generic;

#nullable disable

namespace WWESuperstarsManagementSystemLibrary.DAL.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Superstars = new HashSet<Superstar>();
        }

        public int IDGender { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Superstar> Superstars { get; set; }
    }
}
