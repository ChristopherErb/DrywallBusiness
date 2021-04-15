using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Data
{
    public class Material
    {
        public int Screws { get; set; }
        public int TwelveBoard { get; set; }
        public int TenBoard { get; set; }
        public int EightBoard { get; set; }
        public int LightBlueMud { get; set; }
        public int AllBlackMud { get; set; }
        public String JobTitle { get; set; }
        public int ManagerId { get; set; }
        public Guid MatOwnerID { get; set; }

    }
}
