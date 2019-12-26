using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BRS.Models;

namespace BRS.Getway
{
    public class EmplyeeGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["BRS"].ConnectionString;

        public int Save(Employee2 aEmployee)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlQuery ="insert into Employee2 (EmpID, EName,EFName, EMname, MAdd1, DisId, ThaID, DOb, ConNum1, ENID, PosID, JDate) values(@EmpID, @EmpName, @EmpEFName, @EMName, @MAdd1, @disId, @ThaID, @Dob, @ConNum1, @NID, @PID, @JDate) ";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("EmpID", aEmployee.EmpID);
            cmd.Parameters.AddWithValue("EmpName", aEmployee.EName);
            cmd.Parameters.AddWithValue("EmpEFName", aEmployee.EFName);
            cmd.Parameters.AddWithValue("EMName", aEmployee.EMName);
            cmd.Parameters.AddWithValue("MAdd1", aEmployee.MAdd1);
            cmd.Parameters.AddWithValue("disId", aEmployee.DisID);
            cmd.Parameters.AddWithValue("ThaID", aEmployee.ThaID);
            cmd.Parameters.AddWithValue("Dob", aEmployee.DOB);
            cmd.Parameters.AddWithValue("ConNum1", aEmployee.ENID);
            cmd.Parameters.AddWithValue("NID", aEmployee.PosID);
            cmd.Parameters.AddWithValue("PID", aEmployee.PID);
            cmd.Parameters.AddWithValue("JDate", aEmployee.JDate);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public bool isExistEmpCode(string EmpCode)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlQuery = "select * from  Employee2 where EmpID=@Code";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("Code", EmpCode);
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

        public List<District> GetDistrict()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlquery = " select * from District order by Name";
            SqlCommand com = new SqlCommand(sqlquery, con);
            com.Parameters.Clear();
            SqlDataReader reader = com.ExecuteReader();
            List<District> districts = new List<District>();
            while (reader.Read())
            {
                District district = new District();
                district.DisID = Convert.ToInt32(reader["DisID"].ToString());
                district.Name = reader["Name"].ToString();

                districts.Add(district);

            }
            reader.Close();
            con.Close();
            return districts;
        }

        public List<Thana> GetThana()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlquery = " select * from Thana order by Name";
            SqlCommand com = new SqlCommand(sqlquery, con);
            com.Parameters.Clear();
            SqlDataReader reader = com.ExecuteReader();
            List<Thana> Thanas = new List<Thana>();
            while (reader.Read())
            {
                Thana Thana = new Thana();
                Thana.ThaID = Convert.ToInt32(reader["ThaID"].ToString());
                Thana.DisID = Convert.ToInt32(reader["DisID"].ToString());
                Thana.Name = reader["Name"].ToString();
                Thanas.Add(Thana);

            }
            reader.Close();
            con.Close();
            return Thanas;
        }
        public List<Userlogin> GetUserRole()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string SqlQuery = "SELECT PosId, PosName FROM position";
            SqlCommand command = new SqlCommand(SqlQuery, con);
            command.Parameters.Clear();
            SqlDataReader reader = command.ExecuteReader();
            List<Userlogin> Userlogins = new List<Userlogin>();
            while (reader.Read())
            {
                Userlogin auserLong = new Userlogin();
                auserLong.id = Convert.ToInt16(reader["PosId"].ToString());
                auserLong.RoleName = reader["PosName"].ToString();
                Userlogins.Add(auserLong);
            }
            reader.Close();
            con.Close();
            return Userlogins;

        }
   
    }
}