using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Models
{
   public class EmployeeListItem
    {
        [Display(Name = "Full Name")]
        public String FullName { get; set; }

        [Display(Name = "Job Title")]
        public String Title { get; set; }


        [Display(Name="Hired")]
        public DateTimeOffset HireDate { get; set; }


        [Display(Name = "Pay Rate Per Hour")]
        public Decimal PayRate { get; set; }

    }
}
