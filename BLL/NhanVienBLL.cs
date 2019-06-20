using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NhanVienBLL
    {
        QLLD_DBDataContext db;
        public NhanVienBLL()
        {
            db = new QLLD_DBDataContext();
        }
  
        public string layTenNhanVien(string tenDN, string MK)
        {
            var mpb = (from a in db.NhanViens
                       join b in db.PhongBans on a.maPhongBan equals b.maPhongBan
                       join c in db.TaiKhoans on a.maNhanVien equals c.maNhanVien
                       where c.tenTaiKhoan == tenDN && c.matKhau == MK
                       select a.hoTen).FirstOrDefault();
            return mpb;
        }

        public string layMaNhanVien(string tenDN)
        {
            var mpb = (from a in db.NhanViens
                       join b in db.PhongBans on a.maPhongBan equals b.maPhongBan
                       join c in db.TaiKhoans on a.maNhanVien equals c.maNhanVien
                       where c.tenTaiKhoan == tenDN
                       select a.maNhanVien).FirstOrDefault();
            return mpb;
        }

        public NhanVien kiemTraDangNhap(string tenDN, string MK)
        {

            var tpb = (from s in db.NhanViens
                       join c in db.TaiKhoans on s.maNhanVien equals c.maNhanVien
                       where c.tenTaiKhoan == tenDN && c.matKhau == MK && s.trangThai =="L"
                       select s).FirstOrDefault();
            return tpb;
        }

        public string layMaPhongBanNhanVien(string tenDN)
        {
            string ma = (from a in db.NhanViens join b in db.PhongBans on a.maPhongBan equals b.maPhongBan
                                                join c in db.TaiKhoans on a.maNhanVien equals c.maNhanVien
                         where c.tenTaiKhoan == tenDN
                         select b.maPhongBan).FirstOrDefault();
            return ma;
        }

        /*  public bool kiemTraDN_MaHoa(string tenDN, string MK)
          {
              var tpb = (from s in db.NhanViens
                         join c in db.TaiKhoans on s.maNhanVien equals c.maNhanVien
                         where c.tenTaiKhoan == tenDN && c.matKhau == MK
                         select s).FirstOrDefault();
              if(tpb != null)
              {
                  return true;
              }
              else 
              return false;
          }*/

        public NhanVien kiemTraDangNhap_PhongBanThuong_TPB(string tenDN, string MK)
        {
            var tpb = (from a in db.NhanViens
                       join b in db.TaiKhoans on a.maNhanVien equals b.maNhanVien
                       join c in db.PhongBans on a.maPhongBan equals c.maPhongBan
                       where b.tenTaiKhoan == tenDN && b.matKhau == MK && a.loaiNhanVien == "TPB" && c.loaiPhongBan !="PDA"
                       select a).FirstOrDefault();
            return tpb;
        }

        public NhanVien kiemTraDangNhap_PhongBanThuong_NV(string tenDN, string MK)
        {
            var tpb = (from a in db.NhanViens
                       join b in db.TaiKhoans on a.maNhanVien equals b.maNhanVien
                       join c in db.PhongBans on a.maPhongBan equals c.maPhongBan
                       where b.tenTaiKhoan == tenDN && b.matKhau == MK && a.loaiNhanVien == "NV" && c.loaiPhongBan != "PDA"
                       select a).FirstOrDefault();
            return tpb;
        }

        public NhanVien kiemTraDangNhap_PhongDuAn_TPB(string tenDN, string MK)
        {
            var tpb = (from a in db.NhanViens
                       join b in db.TaiKhoans on a.maNhanVien equals b.maNhanVien
                       join c in db.PhongBans on a.maPhongBan equals c.maPhongBan
                       where b.tenTaiKhoan == tenDN && b.matKhau == MK && a.loaiNhanVien == "TPB" && c.loaiPhongBan == "PDA"
                       select a).FirstOrDefault();
            return tpb;
        }

        public NhanVien kiemTraDangNhap_PhongDuAn_NV(string tenDN, string MK)
        {
            var tpb = (from a in db.NhanViens
                       join b in db.TaiKhoans on a.maNhanVien equals b.maNhanVien
                       join c in db.PhongBans on a.maPhongBan equals c.maPhongBan
                       where b.tenTaiKhoan == tenDN && b.matKhau == MK && a.loaiNhanVien == "NV" && c.loaiPhongBan == "PDA"
                       select a).FirstOrDefault();
            return tpb;
        }

        public List<NhanVien> layDanhSachNhanVien(string maPB, string tenDN)
        {
            var dsnv = from u in db.TaiKhoans
                       join a in db.NhanViens on u.maNhanVien equals a.maNhanVien
                       join e in db.PhongBans on a.maPhongBan equals e.maPhongBan
                       where e.maPhongBan.CompareTo(maPB) == 0 && u.tenTaiKhoan.CompareTo(tenDN) != 0
                       select a;
            return dsnv.ToList();
        }

        public String loadThongTinLenTB(string tenTK)
        {
            string query = @"select * 
                             from dbo.NhanVien a join dbo.TaiKhoan c on a.maNhanVien=c.maNhanVien
                                                 join dbo.PhongBan b on a.maPhongBan=b.maPhongBan
                             where tenTaiKhoan = '" + tenTK +"'";
            return query;
        }

        public string maNhanVienCaoNhat()
        {
            /*MyDataContext dc = new MyDataContext();
            IQueryable<Employee> list = dc.Employees.Where(p => p.Name.StartsWith("S"));
            list = list.Take<Employee>(10);*/

            
            IQueryable<NhanVien> list = db.NhanViens.OrderByDescending(p=>p.maNhanVien);
            list = list.Take<NhanVien>(1);

            /*var sqlMaPB = @"select top(1)*
                               from dbo.NhanVien
                               order by maNhanVien desc";*/
            return list.ToString();
        }

        public bool themNhanVien(NhanVien nv)
        {
            if(!db.NhanViens.Contains(nv))
                {
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
                }
            return false;
        }

        public bool nghiViecVaLamLai(NhanVien nv, string maNV)
        {
            NhanVien nv1 = new NhanVien();
            nv1 = db.NhanViens.Where(a => a.maNhanVien == maNV).SingleOrDefault();
            if (nv1 != null)
            {
               // nv1.maNhanVien = nv.maNhanVien;
                nv1.hoTen = nv.hoTen;
                nv1.ngaySinh = nv.ngaySinh;
                nv1.loaiNhanVien = nv.loaiNhanVien;
                nv1.trangThai = nv.trangThai;
                nv1.gioiTinh = nv.gioiTinh;
                nv1.diaChiLienHe = nv.diaChiLienHe;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaNhanVien2(NhanVien nv, string maNV)
        {
            NhanVien nv1 = new NhanVien();
            nv1 = db.NhanViens.Where(a => a.maNhanVien == maNV).SingleOrDefault();
            if (nv1 != null)
            {
                //nv1.maNhanVien = nv.maNhanVien;
                nv1.hoTen = nv.hoTen;
                nv1.ngaySinh = nv.ngaySinh;
                nv1.loaiNhanVien = nv.loaiNhanVien;
               // nv1.trangThai = nv.trangThai;
                nv1.gioiTinh = nv.gioiTinh;
                nv1.diaChiLienHe = nv.diaChiLienHe;
                nv1.soDienThoai = nv.soDienThoai;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaNhanVien_PDA(NhanVien nv, string maNV)
        {
            NhanVien nv1 = new NhanVien();
            nv1 = db.NhanViens.Where(a => a.maNhanVien == maNV).SingleOrDefault();
            if (nv1 != null)
            {
                //nv1.maNhanVien = nv.maNhanVien;
                nv1.hoTen = nv.hoTen;
                nv1.ngaySinh = nv.ngaySinh;
                nv1.loaiNhanVien = nv.loaiNhanVien;
                // nv1.trangThai = nv.trangThai;
                nv1.gioiTinh = nv.gioiTinh;
                nv1.diaChiLienHe = nv.diaChiLienHe;
                nv1.soDienThoai = nv.soDienThoai;
                nv1.ngayBatDau = nv.ngayBatDau;
                nv1.ngayKetThuc = nv.ngayKetThuc;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaNhanVien(string maNV)
        {
            
            NhanVien nv1 = new NhanVien();
            if (nv1 != null)
            {
                nv1 = db.NhanViens.Single(a => a.maNhanVien == maNV);
                db.NhanViens.DeleteOnSubmit(nv1);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        //Tìm kiếm nhân viên form phân công
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

        //Tìm kiếm nhân viên form qly nhân viên
        public string timKiemNV_QLNV_TheoMa(string maPB, string trangThai, string maNV, string maTPB)
        {
            string tk = @"select b.maNhanVien,b.hoTen,b.ngaySinh,b.gioiTinh,b.diaChiLienHe,b.soDienThoai
                                        from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien=b.maNhanVien
					                                        join dbo.PhongBan c on b.maPhongBan=c.maPhongBan
                                        where c.maPhongBan='" + maPB + "' and b.trangThai ='" + trangThai + "' and b.maNhanVien like N'%" + maNV + "%' and b.maNhanVien != '"+maTPB+"' ";
            return tk;
        }

        public string timKiemNV_QLNV_TheoTen(string maPB, string trangThai,string tenNV, string maTPB)
        {
            string tk = @"select b.maNhanVien,b.hoTen,b.ngaySinh,b.gioiTinh,b.diaChiLienHe,b.soDienThoai
                                        from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien=b.maNhanVien
					                                        join dbo.PhongBan c on b.maPhongBan=c.maPhongBan
                                        where c.maPhongBan='" + maPB + "' and b.trangThai ='" + trangThai + "' and b.hoTen like N'%" + tenNV + "%' and b.maNhanVien != '" + maTPB + "' ";
            return tk;
        }

        public string timKiemNV_QLNV_TheoSDT(string maPB, string trangThai, string SDT, string maTPB)
        {
            string tk = @"select b.maNhanVien,b.hoTen,b.ngaySinh,b.gioiTinh,b.diaChiLienHe,b.soDienThoai
                                        from dbo.TaiKhoan a join dbo.NhanVien b on a.maNhanVien=b.maNhanVien
					                                        join dbo.PhongBan c on b.maPhongBan=c.maPhongBan
                                        where c.maPhongBan='" + maPB + "' and b.trangThai ='" + trangThai + "' and b.soDienThoai like N'%" + SDT + "%' and b.maNhanVien != '" + maTPB + "' ";
            return tk;
        }
    }
}
