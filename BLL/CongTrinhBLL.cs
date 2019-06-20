using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class CongTrinhBLL
    {
        QLLD_DBDataContext db = new QLLD_DBDataContext();

        public List<CongTrinh> layDanhSachCongTrinhDangXayDung()
        {
            var dsct = from a in db.CongTrinhs                      
                       where a.trangThai == "DXD"
                       select a;
            return dsct.ToList();
        }

        public List<CongTrinh> layDanhSachCongTrinhDaHoanThanh()
        {
            var dsct = from a in db.CongTrinhs
                       where a.trangThai == "HT"
                       select a/*new
                       {
                           a.maCongTrinh,
                           a.tenCongTrinh,
                           a.diaDiemXayDung,
                           a.ngayCapPhep,
                           a.ngayKhoiCong,
                           a.ngayHoanThanh,
                       }*/;
            return dsct.ToList();
        }

        public string maCongTrinhCaoNhat()
        {
            /*MyDataContext dc = new MyDataContext();
            IQueryable<Employee> list = dc.Employees.Where(p => p.Name.StartsWith("S"));
            list = list.Take<Employee>(10);*/


            IQueryable<CongTrinh> list = db.CongTrinhs.OrderByDescending(p => p.maCongTrinh);
            list = list.Take<CongTrinh>(1);

            /*var sqlMaPB = @"select top(1)*
                               from dbo.NhanVien
                               order by maNhanVien desc";*/
            return list.ToString();
        }


        public bool themCongTrinh(CongTrinh ct)
        {
            if (!db.CongTrinhs.Contains(ct))
            {
                db.CongTrinhs.InsertOnSubmit(ct);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool hoanThanhCongTrinh(CongTrinh ct, string maCT)
        {
            CongTrinh ct1 = new CongTrinh();
            ct1 = db.CongTrinhs.Where(a => a.maCongTrinh == maCT).SingleOrDefault();
            if (ct1 != null)
            {
                ct1.maCongTrinh = ct.maCongTrinh;
                ct1.tenCongTrinh = ct.tenCongTrinh;
                ct1.diaDiemXayDung = ct.diaDiemXayDung;
                ct1.ngayCapPhep = ct.ngayCapPhep;
                ct1.ngayKhoiCong = ct.ngayKhoiCong;
                ct1.ngayHoanThanh = ct.ngayHoanThanh;
                ct1.trangThai = "HT";
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaCongTrinh(CongTrinh ct, string maCT)
        {
            CongTrinh ct1 = new CongTrinh();
            ct1 = db.CongTrinhs.Where(a => a.maCongTrinh == maCT).SingleOrDefault();
            if (ct1 != null)
            {
                //ct1.maCongTrinh = ct.maCongTrinh;
                ct1.tenCongTrinh = ct.tenCongTrinh;
                ct1.diaDiemXayDung = ct.diaDiemXayDung;
                ct1.luongCongTrinh = ct.luongCongTrinh;
                ct1.ngayCapPhep = ct.ngayCapPhep;
                ct1.ngayKhoiCong = ct.ngayKhoiCong;
                ct1.ngayHoanThanh = ct.ngayHoanThanh;
                db.SubmitChanges();               
                return true;
            }
            return false;
        }

        public bool xoaCongTrinh(string maCT)
        {

            CongTrinh ct1 = new CongTrinh();
            if (ct1 != null)
            {
                ct1 = db.CongTrinhs.Single(a => a.maCongTrinh == maCT);
                db.CongTrinhs.DeleteOnSubmit(ct1);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public string layTrangThai(string maCT)
        {
            var mct = (from a in db.CongTrinhs                      
                       where a.maCongTrinh == maCT
                       select a.trangThai).FirstOrDefault();
            return mct;
        }


        //Tìm kiếm công trình form phân công

        public string timKiemCT_TheoTen(string tenCT)
        {
            string tk = @"select maCongTrinh,tenCongTrinh,diaDiemXayDung,luongCongTrinh,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.CongTrinh
                                    where trangThai = 'DXD' and tenCongTrinh  like N'%" + tenCT + "%'";
            return tk;
        }

        public string timKiemCT_TheoMa(string maCT)
        {
            string tk = @"select maCongTrinh,tenCongTrinh,diaDiemXayDung,luongCongTrinh,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.CongTrinh
                                    where trangThai = 'DXD' and maCongTrinh  like N'%" + maCT + "%'";
            return tk;
        }

        public string timKiemCT_TheoDiaDiem(string maCT)
        {
            string tk = @"select maCongTrinh,tenCongTrinh,diaDiemXayDung,luongCongTrinh,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.CongTrinh
                                    where trangThai = 'DXD' and diaDiemXayDung  like N'%" + maCT + "%'";
            return tk;
        }

        //Tìm kiếm công trình form xem lịch
        

        public string timKiemCT_XL_TheoTen(string tenCT, string tenDN,string TrangThai)
        {
            string tk = @"select c.maPhanCong,d.maCongTrinh,tenCongTrinh,diaDiemXayDung,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien= b.maNhanVien
                                                        join dbo.PhanCong c on b.maNhanVien = c.maNhanVien
                                                        join dbo.CongTrinh d on c.maCongTrinh = d.maCongTrinh
                                    where a.tenTaiKhoan = '" + tenDN +"' and c.trangThai= '"+TrangThai+"' and d.tenCongTrinh  like N'%" + tenCT + "%'";
            return tk;
        }

        public string timKiemCT_XL_TheoMa(string tenCT, string tenDN, string TrangThai)
        {
            string tk = @"select c.maPhanCong,d.maCongTrinh,tenCongTrinh,diaDiemXayDung,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien= b.maNhanVien
                                                        join dbo.PhanCong c on b.maNhanVien = c.maNhanVien
                                                        join dbo.CongTrinh d on c.maCongTrinh = d.maCongTrinh
                                    where a.tenTaiKhoan = '" + tenDN + "' and c.trangThai= '" + TrangThai + "' and d.maCongTrinh  like N'%" + tenCT + "%'";
            return tk;
        }

        public string timKiemCT_XL_TheoDiaDiem(string tenCT, string tenDN, string TrangThai)
        {
            string tk = @"select c.maPhanCong,d.maCongTrinh,tenCongTrinh,diaDiemXayDung,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien= b.maNhanVien
                                                        join dbo.PhanCong c on b.maNhanVien = c.maNhanVien
                                                        join dbo.CongTrinh d on c.maCongTrinh = d.maCongTrinh
                                   where a.tenTaiKhoan = '" + tenDN + "' and c.trangThai= '" + TrangThai + "' and d.diaDiemXayDung  like N'%" + tenCT + "%'";
            return tk;
        }

        //tìm kiếm công trình form QLCT

        public string timKiemCT_QLCT_TheoTen(string tenCT, string trangThai)
        {
            string tk = @"select maCongTrinh,tenCongTrinh,diaDiemXayDung,luongCongTrinh,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.CongTrinh
                                    where trangThai = '"+trangThai+"' and tenCongTrinh  like N'%" + tenCT + "%'";
            return tk;
        }

        public string timKiemCT_QLCT_TheoMa(string maCT, string trangThai)
        {
            string tk = @"select maCongTrinh,tenCongTrinh,diaDiemXayDung,luongCongTrinh,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.CongTrinh
                                    where trangThai = '" + trangThai + "' and maCongTrinh  like N'%" + maCT + "%'";
            return tk;
        }

        public string timKiemCT_QLCT_TheoDiaDiem(string diaDiem, string trangThai)
        {
            string tk = @"select maCongTrinh,tenCongTrinh,diaDiemXayDung,luongCongTrinh,ngayCapPhep,ngayKhoiCong,ngayHoanThanh   
                                    from dbo.CongTrinh
                                    where trangThai = '" + trangThai + "' and diaDiemXayDung  like N'%" + diaDiem + "%'";
            return tk;
        }

        public string layMaCongTrinh(string TenCT)
        {
            var mct = (from a in db.CongTrinhs                    
                       where a.tenCongTrinh == TenCT
                       select a.maCongTrinh).FirstOrDefault();
            return mct;
        }

        public DateTime layNgayBD_CT(string tenCT)
        {
            var nbd = (from a in db.CongTrinhs
                       where a.tenCongTrinh == tenCT
                       select a.ngayKhoiCong).FirstOrDefault();
            return Convert.ToDateTime(nbd);
        }

        public DateTime layNgayKT_CT(string tenCT)
        {
            var nkt = (from a in db.CongTrinhs
                       where a.tenCongTrinh == tenCT
                       select a.ngayHoanThanh).FirstOrDefault();
            return Convert.ToDateTime(nkt);
        }

        public decimal layLuongCT_CongTrinh(string tenCT)
        {
            var lct = (from a in db.CongTrinhs
                       where a.tenCongTrinh == tenCT
                       select a.luongCongTrinh).FirstOrDefault();
            return Convert.ToDecimal(lct);
        }

        public decimal layLuongCT_CongTrinhDangChon(string maCT)
        {
            var lct = (from a in db.CongTrinhs
                       where a.maCongTrinh == maCT
                       select a.luongCongTrinh).FirstOrDefault();
            return Convert.ToDecimal(lct);
        }

        public DateTime layNgayKhoiCong(int maPC)
        {
            var lct = (from a in db.PhanCongs join b in db.CongTrinhs on a.maCongTrinh equals b.maCongTrinh
                       where a.maPhanCong == maPC
                       select b.ngayKhoiCong).FirstOrDefault();
            return Convert.ToDateTime(lct);
        }

        public DateTime layNgayHoanThanh(int maPC)
        {
            var lct = (from a in db.PhanCongs
                       join b in db.CongTrinhs on a.maCongTrinh equals b.maCongTrinh
                       where a.maPhanCong == maPC
                       select b.ngayHoanThanh).FirstOrDefault();
            return Convert.ToDateTime(lct);
        }
      
        public int kiemTraTenCongTrinhTonTai(string tenCT)
        {
            int temp = 0;
            foreach (CongTrinh ct in db.CongTrinhs)
            {
                if(ct.tenCongTrinh == tenCT)
                {
                    temp = temp + 1;                    
                }                
            }
            return temp;
        }
    }
}
