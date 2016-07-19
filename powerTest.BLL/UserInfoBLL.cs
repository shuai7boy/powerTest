using powerTest.DAL;
using powerTest.DalFactory;
using powerTest.IBLL;
using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace powerTest.BLL
{
    public partial class UserInfoBLL
    {
   
        //让用户关联权限
        public bool SetRole(int userId, string rids)
        {
            List<int> list = new List<int>();
            string[] strIds = rids.Split(',');
            for (int i = 0; i < strIds.Length; i++)
            {
                list.Add(int.Parse(strIds[i]));
            }

            ((IUserInfoDal)curDal).SetRole(userId, list.ToArray());
            return dbSession.SaveChanges() > 0;
        }
    }
}
