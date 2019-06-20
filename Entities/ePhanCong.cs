using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class ePhanCong
    {
        string maNhanVien;
        string maCongTrinh;
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        int soNgayCong;
        float tienLuong;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaCongTrinh { get => maCongTrinh; set => maCongTrinh = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public int SoNgayCong { get => soNgayCong; set => soNgayCong = value; }
        public float TienLuong { get => tienLuong; set => tienLuong = value; }

        public ePhanCong(string maNhanVien, string maCongTrinh, DateTime ngayBatDau, DateTime ngayKetThuc, int soNgayCong, float tienLuong)
        {
            MaNhanVien = maNhanVien;
            MaCongTrinh = maCongTrinh;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            SoNgayCong = soNgayCong;
            TienLuong = tienLuong;
        }

        public ePhanCong()
        {

        }
    }
}
