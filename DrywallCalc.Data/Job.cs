using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Data
{
    public class Job
    {
        public string Address { get; set; }
        public String Title { get; set; }
        public String Owner { get; set; }
        public int CurrentJobId { get; set; }
        public DateTimeOffset Created { get; set; }

        [Key]
        public Guid JobOwnerId { get; set; }
    }
}
