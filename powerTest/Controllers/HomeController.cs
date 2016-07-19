using powerTest.IBLL;
using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace powerTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //UserInfoUserInfoBLL UserInfoBLL = new UserInfoUserInfoBLL();
        //RoleInfoUserInfoBLL rUserInfoBLL = new RoleInfoUserInfoBLL();
        public IUserInfoService UserInfoBLL { get; set; }
        public IRoleInfoService RoleInfoBLL { get; set; }
        public ActionResult Index()
        {            
            return View();
        }
        public ActionResult GetPageList()
        {
           
            int pageIndex = String.IsNullOrEmpty(Request["page"])?1:int.Parse(Request["page"]);
            int pageSize = String.IsNullOrEmpty(Request["rows"]) ? 10 : int.Parse(Request["rows"]);            
            int recordCount=0;
            List<UserInfo> list = UserInfoBLL.GetPageList(pageIndex, pageSize, n => n.UserId,n=>n.IsDelete==false,out recordCount);
            return Json(new { total = recordCount, rows = list }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetUserMsg(UserInfo user)
        {
            string result = "ok";          
            if (string.IsNullOrEmpty(user.Remark))
            {
                user.Remark = "";
            }
            if (string.IsNullOrEmpty(user.UserName))
            {
                result = "请输入用户名...";
            }
            else if (string.IsNullOrEmpty(Request["UserPwd"]))
            {
                result = "请输入密码...";
            }           
            else {
                user.IsDelete = false;
                user.SubBy = 1;
                user.SubTime = DateTime.Now;              
                user.UserPwd = Md5Helper.GetMd5Str(Request["UserPwd"]);
                if (!UserInfoBLL.Add(user))
                {
                    result = "添加失败，请稍后再试...";
                }
                
            }          
           
         
            return Content(result);
        }
        public ActionResult Remove(string ids)
        {
            string result = "no";
            List<int> list = new List<int>();
            string[] strNum = ids.Split(',');
            for (int i = 0; i < strNum.Length; i++)
            {
                list.Add(int.Parse(strNum[i]));
            }
            if (UserInfoBLL.Delete(list.ToArray()))
            {
                result = "ok";
            }
            return Content(result);
        }
        [HttpGet]
        public ActionResult SetRoleinfo(int id)
        {
           // ViewBag.UserId = id;
            ViewBag.UserInfo = UserInfoBLL.LoadById(id);
            ViewData.Model = RoleInfoBLL.GetList(c => c.IsDelete == false);
            return View();
        }
        [HttpPost]
        public ActionResult SetRoleinfo(int userId, string rids)
        {
            string result = "no";            
            if (UserInfoBLL.SetRole(userId, rids))
            {
                result = "ok";
            }
            return Content(result);
        }

    }
}
