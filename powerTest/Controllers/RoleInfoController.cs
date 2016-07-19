using powerTest.IBLL;
using powerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace powerTest.Controllers
{
    public class RoleInfoController : Controller
    {
        //
        // GET: /RoleInfo/
       // RoleInfoBLL bll = new RoleInfoBLL();
        public IRoleInfoService RoleInfoBLL { get; set; }
        public IActionInfoService ActionInfoBLL{ get; set; }
        public ActionResult Index()
        {        
            
            return View();
        }
        public ActionResult GetPageList(int page,int rows)
        {           
            int total;
            var result = RoleInfoBLL.GetPageList(page, rows, c => c.RoleId, c => c.IsDelete == false, out total);

            return Json(new { total, rows = result });
        }
        public ActionResult Add(RoleInfo rol)
        {
            string result = "ok";
            rol.IsDelete = false;
            rol.SubBy = 1;
            rol.SubTime = DateTime.Now;
            if (rol.Remark==null)
            {
                rol.Remark = "";
            }
            if (string.IsNullOrEmpty(rol.RoleName))
            {
                result = "请输入角色名...";
            }
            else if (!RoleInfoBLL.Add(rol))
            {
                result = "添加失败，请稍后再试...";
            }
            return Content(result);
        }
        public ActionResult Edit(int id)
        {
            RoleInfo role = RoleInfoBLL.LoadById(id);
            return View(role);
        }       
        [HttpPost]
        public ActionResult EditHandler(RoleInfo role)
        {
            var result = "添加失败,请稍后再试...";
            role.IsDelete = false;
            role.SubBy = 1;
            role.SubTime = DateTime.Now;
            if (role.Remark==null)
            {
                role.Remark = "";
            }
            if (string.IsNullOrEmpty(role.RoleName))
            {
                result = "请输入用户名...";
            }
            else if (RoleInfoBLL.Edit(role))
            {
                result = "ok";
            }
            return Content(result);
        }
        [HttpPost]
        public ActionResult Remove(string ids)
        {
            string result = "no";
            List<int> list = new List<int>();
            string[] strNum=ids.Split(',');
            for (int i = 0; i < strNum.Length; i++)
            {
                list.Add(int.Parse(strNum[i]));
            }
            if (RoleInfoBLL.Delete(list.ToArray()))
            {
                result = "ok";
            }
            return Content(result);
        }
        //给角色设置权限
        public ActionResult SetAction(int id)
        {
            ViewBag.RoleInfo = RoleInfoBLL.LoadById(id);
            ViewData.Model = ActionInfoBLL.GetList(c => c.IsDelete == false);
            return View();
        }
        [HttpPost]
        public ActionResult SetAction(int rid, string aids)
        {
            string result = "no";
            if(RoleInfoBLL.SetAction(rid, aids))
            {
                result = "ok";
            }
            return Content(result);
        }
    }
}
