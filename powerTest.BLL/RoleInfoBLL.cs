using powerTest.DAL;
using powerTest.IBLL;
using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace powerTest.BLL
{
    public partial class RoleInfoBLL
    {
        public bool SetAction(int rid, string aids)
        {
            List<int> list1 = new List<int>();
            string[] list2 = aids.Split(',');
            foreach (var item in list2)
            {
                list1.Add(int.Parse(item));
            }

            ((IRoleInfoDal)curDal).SetAction(rid, list1.ToArray());

            return dbSession.SaveChanges() > 0;
        }
    }
}
