using BRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace BRS.Getway
{
    public class UserGetway
    {
        private string ConnectionString = WebConfigurationManager.ConnectionStrings["BRS"].ConnectionString;
        Userlogin aUserlogin = new Userlogin();
        public int saveReg(RegisterView auserlogin)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "insert into [User] (userName, password, userRole) values (@uName, @uPassword, @uRole);";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("uName", auserlogin.UserName);
            com.Parameters.AddWithValue("uPassword", auserlogin.Password);
            com.Parameters.AddWithValue("uRole", auserlogin.Id);
            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }
        public bool isExistUser(string userName)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "select * from  [User] where UserName=@uName";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("uName", userName);
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
        public List<Userlogin> GetUserRole()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string SqlQuery = "SELECT Id, Role FROM UserRole";
            SqlCommand command = new SqlCommand(SqlQuery, con);
            command.Parameters.Clear();
            SqlDataReader reader = command.ExecuteReader();
            List<Userlogin> Userlogins = new List<Userlogin>();
            while (reader.Read())
            {
                Userlogin auserLong = new Userlogin();
                auserLong.id = Convert.ToInt16(reader["id"].ToString());
                auserLong.RoleName = reader["Role"].ToString();
                Userlogins.Add(auserLong);
            }
            reader.Close();
            con.Close();
            return Userlogins;

        }
    }
}