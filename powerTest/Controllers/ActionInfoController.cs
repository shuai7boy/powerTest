using powerTest.BLL;
using powerTest.IBLL;
using powerTest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace powerTest.Controllers
{
    public class ActionInfoController : Controller
    {
        //
        // GET: /ActionInfo/
     //   ActionInfoBLL bll = new ActionInfoBLL();
        public IActionInfoService ActionInfoBLL { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPageList(int page,int rows)
        {
            int total=0;
            var result = ActionInfoBLL.GetPageList(page, rows, c => c.ActionId, c => c.IsDelete == false, out total);
            return Json(new { total, rows = result });            
        }
        public ActionResult Add(ActionInfo act)
        {
            var result = "ok";
            act.IsDelete = false;
            if (string.IsNullOrEmpty(act.ActionTitle))
            {
                result = "请输入权限名...";
            }else if(string.IsNullOrEmpty(act.ControllerName))
            {
                result = "请输入控制器名...";
            }else if(string.IsNullOrEmpty(act.ActionName))
            {
                result = "请输入行为名...";
            }
            else { 
                if (act.Remark==null)
                {
                    act.Remark = "";
                }
                act.SubBy = 1;
                act.SubTime = DateTime.Now;
                string Menu = Request["Menu"];
                if (Menu=="1")
                {
                    act.IsMenu = true;
                    if (String.IsNullOrEmpty(Request["IconUrl"]))
                    {
                        result = "请选择要上传的图片~";
                    }
                    else
                    {
                        act.MenuIcon = Request["IconUrl"];
                        if (!ActionInfoBLL.Add(act)) result = "添加失败,请稍后再试...";
                    }
                }
                else
                {
                    act.IsMenu = false;
                    act.MenuIcon = "";
                    if (!ActionInfoBLL.Add(act)) result = "添加失败,请稍后再试...";
                }
               
            }
            return Content(result);
        }
        //图片处理
        [HttpPost]
        public ActionResult ImageHandler()
        {
            var result = "no";
            var requestFile = Request.Files["iconImg"];
            string ext=Path.GetExtension(requestFile.FileName);//首先获得扩展名                  
            if ((ext == ".jpg" || ext == ".png" || ext == ".gif") && requestFile.ContentType.ToLower().StartsWith("image"))
						 {
                             string imagePath = "/Upload/Images/";
                             string fileName = imagePath + Guid.NewGuid().ToString() + requestFile.FileName;
                             requestFile.SaveAs(Server.MapPath(fileName));
                             result = fileName;
						 }


            return Content(result);
        }
       [HttpGet]
        public ActionResult Edit(int id)
        {
            ActionInfo info = ActionInfoBLL.LoadById(id);
            return View(info);
        }
        /// <summary>
        /// 编辑权限
        /// </summary>
        /// <param name="act">对象</param>
        /// <returns></returns>
        [HttpPost]
       public ActionResult Edit(ActionInfo act)
       {
           var result = "ok";
           act.IsDelete = false;
           if (string.IsNullOrEmpty(act.ActionTitle))
           {
               result = "请输入权限名...";
           }
           else if (string.IsNullOrEmpty(act.ControllerName))
           {
               result = "请输入控制器名...";
           }
           else if (string.IsNullOrEmpty(act.ActionName))
           {
               result = "请输入行为名...";
           }
           else
           {
               if (act.Remark == null)
               {
                   act.Remark = "";
               }
               act.SubBy = 1;
               act.SubTime = DateTime.Now;
               string Menu = Request["Menu"];
               if (Menu == "1")
               {
                   act.IsMenu = true;
                   if (String.IsNullOrEmpty(Request["MenuIcon"]))
                   {
                       result = "请选择要上传的图片~";
                   }
                   else if (!ActionInfoBLL.Edit(act))
                   {                      
                      result = "保存失败,请稍后再试...";
                   }
               }
               else
               {
                   act.IsMenu = false;
                   act.MenuIcon = "";
                   if (!ActionInfoBLL.Edit(act)) result = "保存失败,请稍后再试...";
               }

           }
           return Content(result);
       }

        public ActionResult Remove(string ids)
        {
            var result = "ok";
            string[] rec=ids.Split(',');
            List<int> list = new List<int>();
            for (int i = 0; i < rec.Length; i++)
            {
                list.Add(int.Parse(rec[i]));
            }
            if (!ActionInfoBLL.Delete(list.ToArray()))
            {
                result = "no";
            }
            return Content(result);
        }
    }
}
