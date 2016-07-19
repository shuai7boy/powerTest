 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using powerTest.Model;

namespace powerTest.IBLL
{
    public partial interface IUserInfoDal:IBaseDal<UserInfo>
    {
	}
    public partial interface IUserActionDal:IBaseDal<UserAction>
    {
	}
    public partial interface IActionInfoDal:IBaseDal<ActionInfo>
    {
	}
    public partial interface IRoleInfoDal:IBaseDal<RoleInfo>
    {
	}
}
