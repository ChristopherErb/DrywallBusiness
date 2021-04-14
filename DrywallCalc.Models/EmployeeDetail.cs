using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Models
{
    public class EmployeeDetail
    {
        public Guid Employee_Id { get; set; }

       
        public String FullName { get; set; }

        
        public String Title { get; set; }

        public DateTimeOffset HireDate { get; set; }

      
        public Decimal PayRate { get; set; }
    }
}
