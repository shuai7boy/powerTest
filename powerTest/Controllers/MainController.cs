using powerTest.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace powerTest.Controllers
{   
    public class MainController : Controller
    {              
        // GET: /Main/
        public IActionInfoService ActionInfoBLL { get; set; }
        public ActionResult Index()
        {
            ViewData.Model=ActionInfoBLL.GetList(c=>((c.IsDelete==false)&&(c.IsMenu==true)));
            return View();
        }

    }
}
