using BRS.BLL;
using BRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRS.Controllers
{
	public class BusticketsController : Controller
	{
		//
		// GET: /Bustickets/
		BusTicketBLL GetBusTicket = new BusTicketBLL();
		public ActionResult search()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ViewbusTicket(string sourceStation, string desStation, DateTime jdate)
		{
			List<BusInfo> GetTicket = GetBusTicket.GetTicketInfo(sourceStation, desStation, jdate);
		    
            //var listofTicket = GetTicket.FindAll(a => a.sourceStation  == sourceStation).ToList();
            ViewData.Add(sourceStation, 12);

            ViewBag.sou = sourceStation;
		    ViewBag.des = desStation;
            var date = jdate.ToString("MM/dd/yyyy");
            ViewBag.jdate = date;

            return View(GetTicket);
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
	}
}