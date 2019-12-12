using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BRS.BLL;
using BRS.Models;


namespace BRS.Controllers
{
    public class HomeController : Controller
    {
        BusTicketBLL GetBusTicket = new BusTicketBLL();
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","User");
            }  
           
        }

        public JsonResult GetDestination(string prefix)
        {
            DistinationEntities db = new DistinationEntities();
            {
                var Countries = (from c in db.Distanations
                                 where c.Name.StartsWith(prefix)
                                 select new { c.Name });
                return Json(Countries, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult Getsource(string prefix)
        {
            busSourceEntities db = new busSourceEntities();
            {
                var busSources = (from b in db.SourceStations
                                  where b.SourceName1.StartsWith(prefix)
                                  select new { b.SourceName1 });
                return Json(busSources, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Sample()
        {
            SampleDBModel db = new SampleDBModel();
            ViewBag.Name = new SelectList(db.Employees, "EmployeeID", "Name");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}