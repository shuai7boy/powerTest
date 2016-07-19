using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace powerTest.IBLL
{
   public partial  interface IDbSession
    {
       int SaveChanges();
    }
}
