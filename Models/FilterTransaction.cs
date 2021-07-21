using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankProject.Models
{
    public class FilterTransaction
    {
        public int Id { get; set; }

        [Display(Name="From Date")]
        public DateTime FromDate {get; set;}

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
    }
}