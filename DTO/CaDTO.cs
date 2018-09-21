using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CaDTO
    {
        private int maCa;
        private TimeSpan thoiGianBatDau;
        private TimeSpan thoiGianKetThuc;
        private double luong;

        public int MaCa { get => maCa; set => maCa = value; }
        public TimeSpan ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public TimeSpan ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
        public double Luong { get => luong; set => luong = value; }
    }
}
