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

        UserGetway aUserGetway = new UserGetway();
        public List<Userlogin> GetUserRole()
        {

            return aUserGetway.GetUserRole();
        }
        public string saveUserReg(Userlogin auserlogin)
        {
            if (!aUserGetway.isExistUser(auserlogin.userName))
            {
                if (aUserGetway.saveReg(auserlogin) > 0)
                {
                    return "Registration Successfully";
                }
                return "Error!! Not Save.......";
            }
            else
            {
                return "This User Name Already Exist!!!";
            }
        }


    }
}