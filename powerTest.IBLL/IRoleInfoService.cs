using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace powerTest.IBLL
{
    public partial interface IRoleInfoService
    {
        bool SetAction(int rid, string aids);
    }
}
