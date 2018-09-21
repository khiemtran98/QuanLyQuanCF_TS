using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiMonDTO
    {
        private int maLoaiMon;
        private string tenLoaiMon;

        public int MaLoaiMon { get => maLoaiMon; set => maLoaiMon = value; }
        public string TenLoaiMon { get => tenLoaiMon; set => tenLoaiMon = value; }
    }
}
