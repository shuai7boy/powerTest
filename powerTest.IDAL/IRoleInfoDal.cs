using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace powerTest.IBLL
{
    public partial interface IRoleInfoDal
    {
        int SetAction(int rid, int[] aids);
    }
}
