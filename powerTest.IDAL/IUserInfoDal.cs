using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace powerTest.IBLL
{
    public partial interface IUserInfoDal
    {
        int SetRole(int uid, int[] rids);
    }
}
