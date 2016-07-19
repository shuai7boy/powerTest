using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace powerTest.IBLL
{
    public partial interface IUserInfoService
    {
      //  bool Login(UserInfo userInfo);
        bool SetRole(int uid, string rids);
    }
}
