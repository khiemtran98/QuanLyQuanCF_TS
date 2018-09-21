using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        private int maNhaCungCap;
        private string tenNhaCungCap;
        private string diaChi;
        private string sDT;

        public int MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }
        public string TenNhaCungCap { get => tenNhaCungCap; set => tenNhaCungCap = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
    }
}
