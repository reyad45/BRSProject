using BRS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRS.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            UserBll aUserBll = new UserBll();
            ViewBag.GetRole = aUserBll.GetUserRole();
           
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }


	}
}