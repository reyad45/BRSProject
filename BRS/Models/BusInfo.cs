using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BRS.Models
{
    public class BusInfo
    {
  
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Bus Name")]

        public int BusNameId { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        //[Remote("IsNameExist", "Department", ErrorMessage = "Name already exist")]
       // [Required(ErrorMessage = "This Field is Required")]
        //[StringLength(7, MinimumLength = 2, ErrorMessage = "Code should be between 2 to 7  characters")]
        [Display(Name = "Bus No :")]
        //[Remote("isbusnoExist", "busInfo", ErrorMessage = "Code is Already Exist")]
        public string busNo  { get; set; }
       
        //BusName
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name="Bus Name :")]
     
        public string busName { get; set; }
        
        //BusCode
        [Required(ErrorMessage = "Please Entry Bus Code")]
        [Display(Name = "Bus Code")]
        public string busCode { get; set; }
        
        //Source station
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name="Source Station")]

        public string sourceStation { get; set; }
       
        //Destination
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name="Destation Station")]
        public string desStation { get; set; }
       
        //interStation
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Intermediate Station")]
        public string interStation { get; set; }
      
        //Start Time 
        [Display(Name="Start Time")]
        public string  sTime { get; set; }
       
        //End TIme
        [Display(Name = "End Time")]
        public string   ETime { get; set; }
     
        //Max Seat
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name="Max Seat")]
        public int maxSeat { get; set; }
        public int availSeat { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name="Description")]
        public string description { get; set; }
        [Display(Name="Journy Date")]
        public DateTime Fdate { get; set; }
        [Display(Name="To")]
        public DateTime Tdate { get; set; }

        public int SetPrice { get; set; }
        public string entryBy { get; set; }
        public DateTime entryDate { get; set; }

    }

    


}