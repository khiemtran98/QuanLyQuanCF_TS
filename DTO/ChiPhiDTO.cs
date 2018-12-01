using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiPhiDTO
    {
        private int thang;
        private double chiPhi;

        public int Thang { get => thang; set => thang = value; }
        public double ChiPhi { get => chiPhi; set => chiPhi = value; }
    }
}
