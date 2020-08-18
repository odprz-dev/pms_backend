using System;
using System.Collections.Generic;

namespace DB_ApplicationContext.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Users = new HashSet<User>();
        }

        public int Pk_IdSexo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
