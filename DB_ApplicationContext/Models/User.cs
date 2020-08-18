using System;
using System.Collections.Generic;

namespace DB_ApplicationContext.Models
{
    public partial class User
    {
        public string Pk_IdUser { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool CT_Status { get; set; }
        public int Fk_IdSexo { get; set; }

        public virtual Sexo Sexo { get; set; }
    }
}
