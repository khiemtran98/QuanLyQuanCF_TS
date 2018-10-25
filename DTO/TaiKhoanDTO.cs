using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        public TaiKhoanDTO()
        {
            hinh = "";
        }

        private int maTaiKhoan;
        private string hoTen;
        private string matKhau;
        private DateTime ngayBatDau;
        private int loaiTaiKhoan;
        private string hinh;
        private bool trangthai;

        public int MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
        public string Hinh { get => hinh; set => hinh = value; }
        public bool TrangThai { get => trangthai; set => trangthai = value; }
    }
}
