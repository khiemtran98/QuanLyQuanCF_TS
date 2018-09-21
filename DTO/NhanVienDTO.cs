using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private int maNV;
        private string hoTen;
        private string matKhau;
        private DateTime ngaySinh;
        private int Phai;
        private string sDT;
        private DateTime ngayBatDau;
        private string diaChi;
        private int ca;
        private bool laAdmin;

        public int MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int Phai1 { get => Phai; set => Phai = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int Ca { get => ca; set => ca = value; }
        public bool LaAdmin { get => laAdmin; set => laAdmin = value; }
    }
}
