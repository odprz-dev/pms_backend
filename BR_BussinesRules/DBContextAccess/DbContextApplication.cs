using DB_ApplicationContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR_BussinesRules.DBContextAccess
{
    public class DbContextApplication : IDisposable
    {
        protected DbAppContext Db = new DbAppContext();
        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}
