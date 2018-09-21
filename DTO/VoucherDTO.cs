using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VoucherDTO
    {
        private int maVoucher;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private decimal giaTri;
        private bool trangThai;

        public int MaVoucher { get => maVoucher; set => maVoucher = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public decimal GiaTri { get => giaTri; set => giaTri = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
