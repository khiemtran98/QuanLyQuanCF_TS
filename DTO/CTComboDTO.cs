using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTComboDTO
    {
        private int maCombo;
        private int maMon;
        private double donGia;

        public int MaCombo { get => maCombo; set => maCombo = value; }
        public int MaMon { get => maMon; set => maMon = value; }
        public double DonGia { get => donGia; set => donGia = value; }
    }
}
