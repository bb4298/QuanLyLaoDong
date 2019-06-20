using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class eNhanVien
    {
        string maNhanVien;
        string hoTen;
        DateTime ngaySinh;
        string gioiTinh;
        string diaChiLienHe;
        string loaiNhanVien;
        string maPhongBan;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChiLienHe { get => diaChiLienHe; set => diaChiLienHe = value; }
        public string LoaiNhanVien { get => loaiNhanVien; set => loaiNhanVien = value; }
        public string MaPhongBan { get => maPhongBan; set => maPhongBan = value; }

        public eNhanVien(string maNhanVien,string hoTen, DateTime ngaySinh, string gioiTinh, string diaChiLienHe, string loaiNhanVien,string maPhongBan)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChiLienHe = diaChiLienHe;
            LoaiNhanVien = loaiNhanVien;
            MaPhongBan = maPhongBan;
        }

        public eNhanVien()
        {

        }
    }
}
