using powerTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace powerTest.DalFactory
{
    public partial class DbSession
    {
        public int SaveChanges()
        {
            DbContext context = ContextFactory.GetContext();
            return context.SaveChanges();
        }
    }
}
