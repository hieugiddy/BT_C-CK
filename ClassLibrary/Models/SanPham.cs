using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    class SanPham
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string UnitCost { get; set; }
        public double Quantity { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
