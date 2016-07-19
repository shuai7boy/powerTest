 
using powerTest.Model;
using powerTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using powerTest.IBLL;
namespace powerTest.DalFactory
{
    public partial class DbSession:IDbSession
    {
        
		public IUserInfoDal GetUserInfoDal()
        {
            return  new UserInfoDal();
        }
		public IUserActionDal GetUserActionDal()
        {
            return  new UserActionDal();
        }
		public IActionInfoDal GetActionInfoDal()
        {
            return  new ActionInfoDal();
        }
		public IRoleInfoDal GetRoleInfoDal()
        {
            return  new RoleInfoDal();
        }
	}
}