using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class TimKiem
    {
        QLLD_DBDataContext db;
        public TimKiem()
        {
            db = new QLLD_DBDataContext();
        }


        //Tìm kiếm nhân viên form quản lí ngày công
        public string timKiemNV_TheoMa(string maPB, string tenDN, string maNV)
        {
            string tk = @"select b.maNhanVien,b.hoTen,b.gioiTinh,b.diaChiLienHe,b.soDienThoai
                                        from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien=b.maNhanVien
					                                        join dbo.PhongBan c on b.maPhongBan=c.maPhongBan
                                        where c.maPhongBan='" + maPB + "' and a.tenTaiKhoan !='" + tenDN + "' and b.maNhanVien like N'%" + maNV + "%' and b.trangThai='L' ";
            return tk;
        }

        public string timKiemNV_TheoTen(string maPB, string tenDN, string tenNV)
        {
            string tk = @"select b.maNhanVien,b.hoTen,b.gioiTinh,b.diaChiLienHe,b.soDienThoai
                                        from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien=b.maNhanVien
					                                        join dbo.PhongBan c on b.maPhongBan=c.maPhongBan
                                        where c.maPhongBan='" + maPB + "' and a.tenTaiKhoan !='" + tenDN + "' and b.hoTen like N'%" + tenNV + "%' and b.trangThai='L' ";
            return tk;
        }

        public string timKiemNV_TheoSDT(string maPB, string tenDN, string SDT)
        {
            string tk = @"select b.maNhanVien,b.hoTen,b.gioiTinh,b.diaChiLienHe,b.soDienThoai
                                        from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien=b.maNhanVien
					                                        join dbo.PhongBan c on b.maPhongBan=c.maPhongBan
                                        where c.maPhongBan='" + maPB + "' and a.tenTaiKhoan !='" + tenDN + "' and b.soDienThoai like N'%" + SDT + "%' and b.trangThai='L' ";
            return tk;
        }

    }
}
