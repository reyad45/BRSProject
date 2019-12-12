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

        public List<Userlogin> GetUserRole()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string SqlQuery = "SELECT Id, Role FROM UserRole";
            SqlCommand command = new SqlCommand(SqlQuery, con);
            command.Parameters.Clear();
            SqlDataReader reader = command.ExecuteReader();
            List<Userlogin> Userlogins = new List<Userlogin>();
            while(reader.Read())
            {
                Userlogin auserLong = new Userlogin();
                auserLong.id = Convert.ToInt16(reader["id"].ToString());
                auserLong.userRole = reader["Role"].ToString();
                Userlogins.Add(auserLong);
            }
            reader.Close();
            con.Close();
            return Userlogins;

        }

    }
}