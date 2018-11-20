using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class rptNhaCungCap_PhieuNhapDTO
    {
        int maPhieuNhap;
        private DateTime ngayLap;
        string tenNhaCungCap;
        double tongTien;

        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        
        public double TongTien { get => tongTien; set => tongTien = value; }
        public string TenNhaCungCap { get => tenNhaCungCap; set => tenNhaCungCap = value; }
    }
}
