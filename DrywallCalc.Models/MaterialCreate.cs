using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Models
{
    public class MaterialCreate
    {
        [Required]
        public String JobTitle { get; set; }
        public int ManagerId { get; set; }

    }
}
