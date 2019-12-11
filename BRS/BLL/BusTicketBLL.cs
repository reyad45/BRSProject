using BRS.Getway;
using BRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRS.BLL
{
    public class BusTicketBLL
    {

        BusticketGetway busGetway = new BusticketGetway();
        public List<BusInfo> GetTicketInfo(string sourceStation, string desStation, DateTime jdate)
        {
            return busGetway.GetTicketInfo (sourceStation, desStation, jdate);

        }

    }
}