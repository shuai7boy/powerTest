using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace powerTest.DAL
{
    public partial class UserInfoDal
    {       
         public int SetRole(int userId, int[] ridss)
        {
            //首先根据userId获取用户对象 然后根据ridss获取角色对象 然后添加
            UserInfo user = LoadById(userId);
             user.RoleInfo.Clear();
            RoleInfoDal roleInfoDal = new RoleInfoDal();
            for (int i = 0; i < ridss.Length; i++)
            {
                //user.RoleInfo.Add(new RoleInfo()
                //{
                //    RoleId=ridss[i],
                //    RoleName="",
                //    SubTime=DateTime.Now,
                //    Remark=""
                //});              
                user.RoleInfo.Add(roleInfoDal.LoadById(ridss[i]));
            }
            return 0;          
        }
    }
}
