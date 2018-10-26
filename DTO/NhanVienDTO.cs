using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private int maNhanVien;
        private string hoTen;
        private string matKhau;
        private DateTime ngayBatDau;
        private bool laAdmin;

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public bool LaAdmin { get => laAdmin; set => laAdmin = value; }
    }
}
