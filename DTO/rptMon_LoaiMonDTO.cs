using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class rptMon_LoaiMonDTO
    {
        int maMon;
        string tenMon;
        string tenLoaiMon;
        double giaTien;

        public int MaMon { get => maMon; set => maMon = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public string TenLoaiMon { get => tenLoaiMon; set => tenLoaiMon = value; }
        public double GiaTien { get => giaTien; set => giaTien = value; }
    }
}
