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
        
        private string connectionString = WebConfigurationManager.ConnectionStrings["BRS"].ConnectionString;
        public List<BusInfo>GetTicketInfo(string sourceStation, string desStation, DateTime jdate)
        { 
            
            
         
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string sqlquery = " SELECT  BusInfo.Id, BusInfo.BusNo, BusInfo.Source_Station, BusInfo.destination_Station, BusInfo.FDate, BusInfo.ToDate, BusInfo.sTime, BusInfo.eTime, BusInfo.interStation, BusInfo.maxSeat, BusInfo.availSeat, BusName.BusName,           BusName.BusCode FROM    BusInfo INNER JOIN  BusName ON BusInfo.BusNameId = BusName.Id WHERE (BusInfo.destination_Station = '" + desStation + "') AND (BusInfo.Source_Station = '" + sourceStation + "') ORDER BY BusName.BusName";
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
                businfos.Add(businfo);

            }
            reader.Close();
            con.Close();
            return businfos;
        }

        }
 }