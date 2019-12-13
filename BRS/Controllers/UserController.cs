using BRS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BRS.Models;

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

    

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Userlogin aUserlogin)
        {
            if (ModelState.IsValid)
            {
                using ( DB_Entities db = new DB_Entities() )
                {
                    var obj =
                        db.Users.Where(
                            a => a.UserName.Equals(aUserlogin.userName) && a.Password.Equals(aUserlogin.Password))
                            .FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        Session["UserRole"] = obj.UserRole.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                      //  ViewBag.Message = "invalid user name or password";
                        ModelState.AddModelError("", "Invalid User Name or Password");
                    }
                }
            }
           
            return View(aUserlogin);
        }




        public ActionResult Registration()
        {
            UserBll aUserBll = new UserBll();
            ViewBag.GetRole = aUserBll.GetUserRole();

            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegisterView auserlogin)
        {
            UserBll aUserBll = new UserBll();
            ViewBag.GetRole = aUserBll.GetUserRole();
            ViewBag.Message = aUserBll.saveUserReg(auserlogin);


            return View();
        }
    
}
}