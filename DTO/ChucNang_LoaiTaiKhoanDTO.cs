using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucNang_LoaiTaiKhoanDTO
    {
        private int maChucNang;
        private int maLoaiTaiKhoan;

        public int MaChucNang { get => maChucNang; set => maChucNang = value; }
        public int MaLoaiTaiKhoan { get => maLoaiTaiKhoan; set => maLoaiTaiKhoan = value; }
    }
}
