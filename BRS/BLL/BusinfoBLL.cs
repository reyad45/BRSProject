using BRS.Getway;
using BRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRS.BLL
{
    public class BusinfoBLL
    {
        BusinfoGetway busGetway = new BusinfoGetway();
        public string Save(BusInfo busInfo)
        {
            if (!busGetway.isExistBusNo(busInfo.busNo, busInfo.BusNameId))
            {
                if (busGetway.Save(busInfo) > 0)
                {
                    return "This Bus Schedule Successfully Save";
                }

                return "Error";

            }
            else
                return "This already Exist this bus";
        }

        //BusName
        public string SaveBusName(BusInfo BusName)
        {
            if (!busGetway.isExistBusName(BusName.busCode, BusName.busName))
            {
                if (busGetway.SaveBusName(BusName) > 0)
                {
                    return "This Bus Name Successfully Save";
                }

                return "Error";

            }
            else
                return "This already Exist this bus";
        }
        public List<BusInfo> GetBusName()
        {
            return busGetway.GetBusName();
        }

        public List<BusInfo> GetBusShedule(DateTime Fdate)
        {
            return busGetway.GetSehcdule(Fdate);

        }

        public List<BusInfo> GetBusSheduleID()
        {
            return busGetway.GetSehcduleID();

        }


    }
}