 
using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using powerTest.IBLL;
namespace powerTest.DAL
{
    public partial class UserInfoDal : BaseDal<UserInfo>,IUserInfoDal
    {
	}
    public partial class UserActionDal : BaseDal<UserAction>,IUserActionDal
    {
	}
    public partial class ActionInfoDal : BaseDal<ActionInfo>,IActionInfoDal
    {
	}
    public partial class RoleInfoDal : BaseDal<RoleInfo>,IRoleInfoDal
    {
	}
}