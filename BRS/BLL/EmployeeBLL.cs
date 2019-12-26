using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BRS.Getway;
using BRS.Models;

namespace BRS.BLL
{
    public class EmployeeBLL
    {
        EmplyeeGetway EmpGetway=new EmplyeeGetway();
        public List<District> GetDistricts()
        {
            return EmpGetway.GetDistrict();
        }

        public List<Thana> GetThana()
        {
            return EmpGetway.GetThana();
        }

        public List<Userlogin> GetUserRole()
        {

            return EmpGetway.GetUserRole();
        }


        public string saveEmployee(Employee2 aEmployee)
        {
            if (!EmpGetway.isExistEmpCode(aEmployee.EmpID))
            {
                if (EmpGetway.Save(aEmployee) > 0)
                {
                    return "Save Successfully";
                }
                return "Error!! Not Save.......";
            }
            else
            {
                return "This Employee Id Already Exist";
            }
        


        }
    }
}