using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiToppingDTO
    {
        private int maLoaiTopping;
        private string tenLoaiTopping;
        private bool trangThai;

        public int MaLoaiTopping { get => maLoaiTopping; set => maLoaiTopping = value; }
        public string TenLoaiTopping { get => tenLoaiTopping; set => tenLoaiTopping = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
