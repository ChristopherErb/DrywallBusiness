using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrywallCalc.Data
{
    public class Employee
    {
        [Key]
        public Guid Employee_Id { get; set; }

        [Required]
        public String FullName { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public DateTimeOffset HireDate { get; set; }

        [Required]
        public Decimal PayRate { get; set; }
    }
}