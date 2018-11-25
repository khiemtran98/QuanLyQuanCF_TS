using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class PhieuNhapBUS
    {
        // Lấy toàn bộ phiếu nhập
        public static List<PhieuNhapDTO> GetEntireInputMaterial()
        {
            return PhieuNhapDAO.GetEntireInputMeterial();
        }

        // Lấy phiếu nhập theo Khoảng thời gian start->end
        public static List<PhieuNhapDTO> GetListInputByTime(DateTime dateFrom, DateTime dateEnd)
        {
            return PhieuNhapDAO.GetListInputByTime(dateFrom, dateEnd);
        }

        // Lấy phiếu nhập theo mốc thời gian
        public static List<PhieuNhapDTO> GetListInputTimeline(DateTime dateOnly)
        {
            return PhieuNhapDAO.GetListInputTimeline(dateOnly);
        }

        public static bool isActive(int maPhieuNhap)
        {
            return PhieuNhapDAO.isActive(maPhieuNhap);
        }
    }
}
