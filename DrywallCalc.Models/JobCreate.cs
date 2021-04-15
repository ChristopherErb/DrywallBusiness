using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Models
{
    public class JobCreate
    {
        [Required]
        public String Title { get; set; }
        public String Owner { get; set; }

    }
}
