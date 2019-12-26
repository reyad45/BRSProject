using BRS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BRS.Getway
{
    public class BusticketGetway
    {

        private string  sqlquery { get; set; }
        
        private string connectionString = WebConfigurationManager.ConnectionStrings["BRS"].ConnectionString;
        public List<BusInfo>GetTicketInfo(string sourceStation, string desStation, DateTime jdate)
        {
            
            DateTime now = DateTime.Now;
            var SystemDate = DateTime.Now.ToString("MM/dd/yyyy");
           // DateTime time = DateTime.Now.ToString("HH:mm:ss");
           var Time= DateTime.Now.ToString("HH:mm:ss");
            var date = jdate.ToString("MM/dd/yyyy");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (date == SystemDate)
            {
                sqlquery = " SELECT  BusInfo.Id, BusInfo.BusNo, BusInfo.Source_Station, BusInfo.destination_Station, BusInfo.FDate, BusInfo.ToDate, BusInfo.sTime, BusInfo.eTime, BusInfo.interStation, BusInfo.maxSeat, BusInfo.availSeat,BusInfo.SetPrice, BusName.BusName,           BusName.BusCode FROM    BusInfo INNER JOIN  BusName ON BusInfo.BusNameId = BusName.Id WHERE (BusInfo.destination_Station = '" + desStation + "') AND (BusInfo.Source_Station = '" + sourceStation + "') and (BusInfo.ToDate >='" + date + "') and (BusInfo.sTime >='" + Time + "') ORDER BY BusName.BusName";
            }

            else
            {
                sqlquery = " SELECT  BusInfo.Id, BusInfo.BusNo, BusInfo.Source_Station, BusInfo.destination_Station, BusInfo.FDate, BusInfo.ToDate, BusInfo.sTime, BusInfo.eTime, BusInfo.interStation, BusInfo.maxSeat, BusInfo.availSeat,BusInfo.SetPrice, BusName.BusName,           BusName.BusCode FROM    BusInfo INNER JOIN  BusName ON BusInfo.BusNameId = BusName.Id WHERE (BusInfo.destination_Station = '" + desStation + "') AND (BusInfo.Source_Station = '" + sourceStation + "') and (BusInfo.ToDate >='" + date + "') ORDER BY BusName.BusName";
                
            }
           
            SqlCommand com = new SqlCommand(sqlquery, con);
            com.Parameters.Clear();
            SqlDataReader reader = com.ExecuteReader();
            List<BusInfo> businfos = new List<BusInfo>();
            while(reader.Read())
            {
                BusInfo businfo = new BusInfo();
                businfo.busNo = reader["BusNo"].ToString();
                businfo.busName = reader["BusName"].ToString();
                businfo.busCode = reader["BusCode"].ToString();
                businfo.ETime = reader["eTime"].ToString();
                businfo.sTime = reader["sTime"].ToString();
                businfo.sourceStation = reader["Source_Station"].ToString();
                businfo.desStation = reader["destination_Station"].ToString();
                businfo.availSeat = Convert.ToInt32(reader["availSeat"].ToString());
                businfo.SetPrice = Convert.ToInt32(reader["SetPrice"].ToString());
                businfos.Add(businfo);

            }
            reader.Close();
            con.Close();
            return businfos;
        }

        }
 }