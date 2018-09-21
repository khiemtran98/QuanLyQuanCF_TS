using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ComboDTO
    {
        private int maCombo;
        private string tenCombo;
        private double giaBan;
        private bool trangThai;

        public int MaCombo { get => maCombo; set => maCombo = value; }
        public string TenCombo { get => tenCombo; set => tenCombo = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
