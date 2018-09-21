using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChamCongDTO
    {
        private int maChamCong;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;

        public int MaChamCong { get => maChamCong; set => maChamCong = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
    }
}
