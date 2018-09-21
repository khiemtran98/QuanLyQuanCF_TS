using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CongThucDTO
    {
        private int maNguyenLieu;
        private int maMon;

        public int MaNguyenLieu { get => maNguyenLieu; set => maNguyenLieu = value; }
        public int MaMon { get => maMon; set => maMon = value; }
    }
}
