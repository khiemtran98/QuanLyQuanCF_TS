using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTChamCongDTO
    {
        private int maNV;
        private DateTime ngayLam;
        private int maChamCong;
        private bool tinHCong;

        public int MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public int MaChamCong { get => maChamCong; set => maChamCong = value; }
        public bool TinHCong { get => tinHCong; set => tinHCong = value; }
    }
}
