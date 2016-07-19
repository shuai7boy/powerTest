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
    public partial class RoleInfoDal
    {
        public int SetAction(int rid, int[] aids)
        {
            var roleInfo = LoadById(rid);
            roleInfo.ActionInfo.Clear();
            ActionInfoDal actionInfoDal = new ActionInfoDal();
            foreach (var aid in aids)
            {
                roleInfo.ActionInfo.Add(actionInfoDal.LoadById(aid));
            }
            return 0;
        }
      
    }
}
