using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace powerTest.DAL
{
    public partial class ContextFactory
    {
        public static DbContext GetContext()
        {
            DbContext context = CallContext.GetData("OAContext") as DbContext;
            if (context == null)
            {
                context = new Model1Container();
                CallContext.SetData("OAContext", context);
            }
            return context;
        }
    }
}
