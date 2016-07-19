 
using powerTest.DalFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using powerTest.Model;
using powerTest.IBLL;
using powerTest.IBLL;
namespace powerTest.BLL
{
    public partial class UserInfoBLL:BaseBLL<UserInfo>,IUserInfoService
    {
        protected override IBaseDal<UserInfo> GetDal()
        {
            return dbSession.GetUserInfoDal();
        }
	}
    public partial class UserActionBLL:BaseBLL<UserAction>,IUserActionService
    {
        protected override IBaseDal<UserAction> GetDal()
        {
            return dbSession.GetUserActionDal();
        }
	}
    public partial class ActionInfoBLL:BaseBLL<ActionInfo>,IActionInfoService
    {
        protected override IBaseDal<ActionInfo> GetDal()
        {
            return dbSession.GetActionInfoDal();
        }
	}
    public partial class RoleInfoBLL:BaseBLL<RoleInfo>,powerTest.IBLL.IRoleInfoService
    {
        protected override IBaseDal<RoleInfo> GetDal()
        {
            return dbSession.GetRoleInfoDal();
        }
	}
}