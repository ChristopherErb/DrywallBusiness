using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Models
{
    public class EmployeeEdit
    {
        public String Employee_Id { get; set; }
        public String Title { get; set; }
        public String FullName { get; set; }

        public decimal PayRate { get; set; }
    }
}
