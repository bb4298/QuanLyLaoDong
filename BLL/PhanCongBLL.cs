using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class PhanCongBLL
    {
        QLLD_DBDataContext db = new QLLD_DBDataContext();

        public bool ThemPhanCong(PhanCong pc)
        {
            if (!db.PhanCongs.Contains(pc))
            {
                db.PhanCongs.InsertOnSubmit(pc);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaPhanCong_DaTraLuong(PhanCong pc, int maPC)
        {
            PhanCong pc1 = new PhanCong();
            pc1 = db.PhanCongs.Where(a => a.maPhanCong == maPC).SingleOrDefault();
            if (pc1 != null)
            {
                //nv1.maNhanVien = nv.maNhanVien;
                pc1.trangThai = pc.trangThai;
                pc1.daTraLuong = pc.daTraLuong;    
                
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaPhanCong_DoiNgay(PhanCong nv, int maPC)
        {
            PhanCong nv1 = new PhanCong();
            nv1 = db.PhanCongs.Where(a => a.maPhanCong == maPC).SingleOrDefault();
            if (nv1 != null)
            {
                
                nv1.ngayBatDauLam = nv.ngayBatDauLam;
                nv1.ngayKetThuc = nv.ngayKetThuc;
                nv1.soNgayCong = nv.soNgayCong;
                // nv1.trangThai = nv.trangThai;
                nv1.tienLuong = nv.tienLuong;     
                
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaPhanCong(string maNV)
        {

            PhanCong nv1 = new PhanCong();
            if (nv1 != null)
            {
                nv1 = db.PhanCongs.Single(a => a.maNhanVien == maNV);
                db.PhanCongs.DeleteOnSubmit(nv1);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public int kiemTraPhanCongTonTai(string maNV, string maCT)
        {
            var kt = (from a in db.PhanCongs
                     where a.maNhanVien.CompareTo(maNV)==0 && a.maCongTrinh.CompareTo(maCT)==0
                     select a).Count();

            return kt;
        }

        public int kiemTraThoiGian(string maNV, DateTime nbd, DateTime nkt)
        {
            int temp = 0;
            foreach(PhanCong pc in db.PhanCongs)
            {
                if (pc.trangThai == "C" && maNV == pc.maNhanVien)
                {
                    if (nbd >= pc.ngayBatDauLam && nbd <= pc.ngayKetThuc || nkt >= pc.ngayBatDauLam && nkt <= pc.ngayKetThuc)
                    {
                        temp = temp + 1;
                    }
                    
                }               
                else //if(nbd >=  pc.ngayBatDauLam && nkt <= pc.ngayKetThuc)
                {
                    temp = temp;                   
                }
            }
            return temp;
        }


        public int kiemTraThoiGian_SuaNgay(int maPC, string maNV, DateTime nbd, DateTime nkt)
        {
            int temp = 0;
            foreach (PhanCong pc in db.PhanCongs)
            {
                if (pc.trangThai == "C" && maNV == pc.maNhanVien && maPC != pc.maPhanCong)
                {
                    if (nbd >= pc.ngayBatDauLam && nbd<= pc.ngayKetThuc || nkt>=pc.ngayBatDauLam && nkt <= pc.ngayKetThuc)
                    {
                        temp = temp + 1; 
                    }
                        
                }                                 
                else 
                {
                    temp = temp;
                }    
            }
            return temp;
        }

        public int kiemTraChiTietTrungKhop(int maPC, DateTime nbd, DateTime nkt)
        {
            int temp = 0;
            foreach (PhanCong pc in db.PhanCongs)
            {
                if(pc.maPhanCong==maPC && pc.ngayBatDauLam == nbd && pc.ngayKetThuc == nkt)
                {
                    temp = 0;
                }
                else
                {
                    temp = temp + 1;
                }
            }
            return temp;
        }

        public int kiemTraNhanVienChuaCo(string maNV)
        {
            int temp = 0;
            foreach (PhanCong pc in db.PhanCongs)
            {
                if (maNV == pc.maNhanVien)
                    temp = temp+1;                    
            }
            return temp;
        }

        public string loadThongTinPhanCong(string maNV, string maCT)
        {
            String query = @"select *
            from dbo.PhanCong
            where maNhanVien = '"+maNV+"' AND maCongTrinh = '"+maCT+"'";
            return query;
        }

        public bool suaPhanCong(PhanCong pc, int maPC)
        {
            PhanCong pc1 = new PhanCong();
            pc1 = db.PhanCongs.Where(a => a.maPhanCong == maPC).SingleOrDefault();
            if (pc != null)
            {
                pc1.maPhanCong = pc.maPhanCong;
                //pc1.maNhanVien = ct.te;
                pc1.soNgayCong = pc1.soNgayCong-1;
                pc1.tienLuong = pc1.tienLuong-500000;               
                pc1.trangThai = pc.trangThai;
                
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        

        public int layMaPhanCongCaoNhat()
        {
            int ma = (from a in db.PhanCongs
                      orderby a.maPhanCong descending
                      select a.maPhanCong).FirstOrDefault();
            return ma;
        }

        public int kiemTraCacPhanCongDuocTraLuong(string maCT)
        {
            int temp = 0;
            foreach (PhanCong pc in db.PhanCongs)
            {
                if(pc.maCongTrinh == maCT)
                {
                    if (pc.daTraLuong == "Chưa")
                    {
                        temp = temp + 1;
                    }
                    else
                    {
                        temp = temp;
                    }
                }
                
            }
            return temp;
        }
    }
}
