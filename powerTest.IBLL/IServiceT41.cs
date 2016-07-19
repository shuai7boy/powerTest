 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using powerTest.Model;
namespace powerTest.IBLL
{
    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
    }
    public partial interface IUserActionService:IBaseService<UserAction>
    {
    }
    public partial interface IActionInfoService:IBaseService<ActionInfo>
    {
    }
    public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {
    }
}