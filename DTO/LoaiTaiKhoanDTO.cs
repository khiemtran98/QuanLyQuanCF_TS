using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiTaiKhoanDTO
    {
        private int maLoaiTaiKhoan;
        private string tenLoaiTaiKhoan;
        private bool trangThai;

        public int MaLoaiTaiKhoan { get => maLoaiTaiKhoan; set => maLoaiTaiKhoan = value; }
        public string TenLoaiTaiKhoan { get => tenLoaiTaiKhoan; set => tenLoaiTaiKhoan = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
