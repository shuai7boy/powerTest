using powerTest.BLL;
using powerTest.IBLL;
using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace powerTest.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
       // UserInfoBLL bll = new UserInfoBLL();
        public IUserInfoService UserInfoBLL { get; set; }
        public ActionResult Index(int id)
        {
            UserInfo user = UserInfoBLL.LoadById(id);                      
            return View(user);
        }
        [HttpPost]
        public ActionResult EditHandler(UserInfo user)
        {
            string result = "ok";
            if (string.IsNullOrEmpty(user.UserName))
            {
                result = "用户名不能为空...";
            }
            else { 
            if (string.IsNullOrEmpty(Request["UserPwd"].Trim()))
            {
                user.UserPwd=Request["UserPwd2"];
            }
            else
            {
                user.UserPwd=Md5Helper.GetMd5Str((Request["UserPwd"]));
            }
            if (string.IsNullOrEmpty(user.Remark))
            {
                user.Remark = "";
            }

            user.IsDelete = false;
            user.SubBy = 1;
            user.SubTime = DateTime.Now;
            if (!UserInfoBLL.Edit(user))
            {
                result = "保存失败，请稍后再试...";
            }
            }
            return Content(result);
        }
      
    }
}
