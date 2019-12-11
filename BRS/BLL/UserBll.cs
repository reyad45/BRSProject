using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BRS.Getway;
using BRS.Models;

namespace BRS.BLL
{
    public class UserBll
    {
       
        public List<Userlogin>GetUserRole()
        {
            UserGetway aUserGetway = new UserGetway();
            return aUserGetway.GetUserRole();
        }
        
    }
}