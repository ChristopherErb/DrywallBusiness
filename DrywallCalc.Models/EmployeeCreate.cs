using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Models
{
    class EmployeeCreate
    {
       [Required]
       [MinLength(2, ErrorMessage ="Please enter the first and last name")]
        [MaxLength(100, ErrorMessage = "Please Enter a shorter name")]
        public String FullName { get; set; }
       
        public String Title { get; set; }
       
        public DateTimeOffset HireDate { get; set; }
       
        public Decimal PayRate { get; set; }
    }
}
