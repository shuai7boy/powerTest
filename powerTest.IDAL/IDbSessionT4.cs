 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using powerTest.Model;
namespace powerTest.IBLL
{
    public partial interface IDbSession
    {
		IUserInfoDal GetUserInfoDal();
		IUserActionDal GetUserActionDal();
		IActionInfoDal GetActionInfoDal();
		IRoleInfoDal GetRoleInfoDal();
	}
}