using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BRS.Models;
using System.Data.SqlClient;
namespace BRS.Getway
{

    public class BusinfoGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["BRS"].ConnectionString;
        public int Save(BusInfo businfo)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "insert into Businfo(BusNo, BusNameID,  Source_Station, destination_Station, FDate, Todate,sTime, eTime, interStation, maxSeat, availSeat, Description) values(@BusNo, @BusNameid, @source_Station, @destination_Station, @FDate,@tdate, @sTime, @eTime, @interStation, @MaxSeat,@availSeat, @description);";
            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.Clear();
            cm.Parameters.AddWithValue("BusNo", businfo.busNo);
            cm.Parameters.AddWithValue("BusNameid", businfo.BusNameId);
            cm.Parameters.AddWithValue("source_Station", businfo.sourceStation);
            cm.Parameters.AddWithValue("destination_Station", businfo.desStation);
            cm.Parameters.AddWithValue("FDate", businfo.Fdate);
            cm.Parameters.AddWithValue("tdate", businfo.Tdate);
            cm.Parameters.AddWithValue("sTime", businfo.sTime);
            cm.Parameters.AddWithValue("eTime", businfo.ETime);
            cm.Parameters.AddWithValue("interStation", businfo.interStation);
            cm.Parameters.AddWithValue("MaxSeat", businfo.maxSeat);
            cm.Parameters.AddWithValue("availSeat", businfo.maxSeat);
            cm.Parameters.AddWithValue("description", businfo.description);



            int rowcount = cm.ExecuteNonQuery();
            con.Close();
            return rowcount;

        }
        public bool isExistBusNo(string busNo, int busNameId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlquery = "select * from busInfo where  BusNo=@busno and BusNameId=@busNameId";
            SqlCommand com = new SqlCommand(sqlquery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("busno", busNo);
            com.Parameters.AddWithValue("busNameId", busNameId);
            SqlDataReader reader = com.ExecuteReader();
            if(reader.HasRows)
            {
                return true;

            }
            else
            {
                return false;
            }


        }


//Add Bus Name

        public int SaveBusName(BusInfo BusName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "insert into BusName(BusCode, BusName) values(@BusCode, @BusName);";
            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.Clear();
            cm.Parameters.AddWithValue("BusCode", BusName.busCode);
            cm.Parameters.AddWithValue("BusName", BusName.busName);
            int rowcount = cm.ExecuteNonQuery();
            con.Close();
            return rowcount;

        }

        //Check Is Exist
        public bool isExistBusName(string BusCode, string BusName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlquery = "select * from BusName where  BusCode=@BusCode and BusName=@busName";
            SqlCommand com = new SqlCommand(sqlquery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("BusCode", BusCode);
            com.Parameters.AddWithValue("busName", BusName);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                return true;

            }
            else
            {
                return false;
            }


        }
        //View All Bus Name
        public List<BusInfo> GetBusName()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlquery = " select * from BusName order by Busname";
            SqlCommand com = new SqlCommand(sqlquery, con);
            com.Parameters.Clear();
            SqlDataReader reader = com.ExecuteReader();
            List<BusInfo> businfos = new List<BusInfo>();
            while(reader.Read())
            {
                BusInfo businfo = new BusInfo();
                businfo.Id = Convert.ToInt32(reader["Id"].ToString()); 
                businfo.busCode = reader["BusCode"].ToString();
                businfo.busName = reader["BusName"].ToString();
                businfos.Add(businfo);

            }
            reader.Close();
            con.Close();
            return businfos;
        }


        internal bool isExist(string p1, int p2)
        {
            throw new NotImplementedException();
        }
    }
}


     
