using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class eTaiKhoan
    {
        string tenTaiKhoan;
        string matKhau;
        string maNhanVien;

        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }

        public eTaiKhoan(string tenTaiKhoan, string matKhau, string maNhanVien)
        {
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            MaNhanVien = MaNhanVien;
        }

        public eTaiKhoan()
        {

        }

    }
}
