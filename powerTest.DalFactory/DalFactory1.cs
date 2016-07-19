using powerTest.DAL;
using powerTest.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace powerTest.DalFactory
{
    public partial class DalFactory1
    {
        //简单工厂
        public static IUserInfoDal GetUserInfoDal()
        {
            return new UserInfoDal();
        }
        //抽象工厂
        public static IUserInfoDal GetUserInfoDal2()
        {
            //从配置文件中读取的名字和程序集的名字
            string s1 = System.Configuration.ConfigurationManager.AppSettings["UserInfoDal"];
            string assemblyName = s1.Split(',')[0];
            string className = s1.Split(',')[1];
            //获取程序集对象
            Assembly a1 = Assembly.Load(assemblyName);
            //创建对象实例
            return a1.CreateInstance(className) as IUserInfoDal;
        }
    }
}
