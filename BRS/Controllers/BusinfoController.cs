using BRS.BLL;
using BRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRS.Controllers
{
	public class BusinfoController : Controller
	{
		BusinfoBLL businfoBll = new BusinfoBLL(); 
		//
		// GET: /Businfo/
       
	    public ActionResult SearchShedule()

	    {
            ViewBag.BusNames = businfoBll.GetBusName();
	        return View();
	    }
   

        public ActionResult SearchShedulebus(DateTime  jdate)
        {
            List<BusInfo> GetShedule = businfoBll.GetBusShedule(jdate);

            var date = jdate.ToString("MM/dd/yyyy");
            ViewBag.jdate = date;

            return Json(GetShedule,JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchShedulebusid(int id)
        {
            List<BusInfo> GetSheduleID = businfoBll.GetBusSheduleID();
            var Schedule = GetSheduleID.FindAll(a => a.BusNameId == id).ToList();
            return Json(Schedule, JsonRequestBehavior.AllowGet);
        }


		[HttpGet]
		public ActionResult Create() 
		{
            ViewBag.BusNames = businfoBll.GetBusName();
			return View();
		}
        
		[HttpPost]
		public ActionResult Create(BusInfo busInfo )
        {
            ViewBag.BusNames = businfoBll.GetBusName();
			ViewBag.Message = businfoBll.Save(busInfo);
            ModelState.Clear();
			return View();
		}
        [HttpGet]
        public ActionResult BusName()
        {
           
            return View();
        }
         [HttpPost]
        public ActionResult BusName(BusInfo busInfo)
        {

            ViewBag.Message = businfoBll.SaveBusName(busInfo);
            //ModelState.Clear();
            return View();
        }
   
        public ActionResult BusNameAndView()  
        {
            List<BusInfo> busNames = businfoBll.GetBusName();

            return View(busNames);
        }

		
		//public JsonResult GetBusName(string term)
		//{
		//    List<string> businfo;
		//   List<BusInfo> Businfos = businfoBll.GetBusInfo();


		//    //Searching records from list using LINQ query  
		//   businfo = Businfos.Where(u => u.busName.StartsWith(term)) 
		//       .Select(y => y.busName).ToList();
		//   return Json(businfo, JsonRequestBehavior.AllowGet);
		//}


		public JsonResult GetDestination(string prefix)
		{
			DistinationEntities db = new DistinationEntities();
			{
					var Countries = (from c in db.Distanations
									 where c.Name.StartsWith(prefix)
							 select new { c.Name});
			return Json(Countries, JsonRequestBehavior.AllowGet);
			}

		}

		public JsonResult GetBusName(string prefix)
		{
			busNameEntities db = new busNameEntities();
			{
				var busNames = (from b in db.BusNames
								where b.bName.StartsWith(prefix)
								select new { b.bName });
				return Json(busNames, JsonRequestBehavior.AllowGet);
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
		public JsonResult GetinterStation(string prefix)
		{
			busSourceEntities db = new busSourceEntities();
			{
				var busSources = (from b in db.SourceStations
								  where b.InterStation.StartsWith(prefix)  
								  select new { b.InterStation });
				return Json(busSources, JsonRequestBehavior.AllowGet);
			}

		}


       // public JsonResult isbusnoExist(string busno)
       //{
       //     List<BusInfo> BusInfos = businfoBll.GetBusInfo();
       //     bool isExist = BusInfos.FirstOrDefault(u =>u.busNo.ToLowerInvariant().Equals(busno.ToLower())) != null;
       //     return Json(!isExist, JsonRequestBehavior.AllowGet);
       // }
       // [HttpGet]
       // public JsonResult isbusnameExist(string busName)
       // {
       //     List<BusInfo> Businfos = businfoBll.GetBusInfo();
       //     bool isExist = Businfos.FirstOrDefault(u=>u.busName.ToLowerInvariant().Equals(busName.ToLower()))!=null;
       //     return Json(!isExist, JsonRequestBehavior.AllowGet);
       // }


	}
}