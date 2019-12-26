using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BRS.BLL;
using BRS.Models;

namespace BRS.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        UserBll aUserBll = new UserBll();
        EmployeeBLL aEmployeeBll = new EmployeeBLL();
        [HttpGet]
        public ActionResult Save()
        {

            ViewBag.GetRole = aEmployeeBll.GetUserRole();
            ViewBag.District = aEmployeeBll.GetDistricts();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Employee2 aEmployee)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GetRole = aUserBll.GetUserRole();
                ViewBag.District = aEmployeeBll.GetDistricts();
                return View();  
            }
            ViewBag.GetRole = aEmployeeBll.GetUserRole();
            ViewBag.District = aEmployeeBll.GetDistricts();
            ViewBag.Message = aEmployeeBll.saveEmployee(aEmployee);
            ModelState.Clear();
           
            return View();
      
        }


        public ActionResult SelectedDistrict(int id)
        {
            List<Thana> aThana = aEmployeeBll.GetThana();
            var ThanaName = aThana.FindAll(a => a.DisID == id).ToList();
            return Json(ThanaName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrict(string pregix)
        {
            DivEntities dbEntity = new DivEntities();
            {
                var DistrictName = (from d in dbEntity.Districts
                                where d.Name.StartsWith(pregix) 
                                select new { d.Name });
                return Json(DistrictName, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetThana(string Prefix)
        {
            DivEntities ThanaEntity = new DivEntities();
            {
                var ThanaName = (from thana in ThanaEntity.Thanas
                    where thana.Name.StartsWith(Prefix)
                    select new {thana.Name});
                return Json(ThanaName, JsonRequestBehavior.AllowGet);
            }
        }
    
	}
}