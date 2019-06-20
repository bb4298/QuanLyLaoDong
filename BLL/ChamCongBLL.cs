using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ChamCongBLL
    {
        QLLD_DBDataContext db;
        public ChamCongBLL()
        {
            db = new QLLD_DBDataContext();
        }

        public int layMaChamCongCaoNhat()
        {
            int ma = (from a in db.ChamCongs
                      orderby a.maChamCong descending
                      select a.maChamCong).FirstOrDefault();
            return ma;
        }

        public bool themChamCong(ChamCong cc)
        {
            if (!db.ChamCongs.Contains(cc))
            {
                db.ChamCongs.InsertOnSubmit(cc);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaChamCong(int maPC, int thang, int nam)
        {

            ChamCong b = new ChamCong();
            b = db.ChamCongs.Single(a => a.thang == thang && a.nam == nam && a.maPhanCong == maPC);
            if (b != null)
            {              
                db.ChamCongs.DeleteOnSubmit(b);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public int kiemTraChamCongDaCoDuLieu(int maPhanCong, int thang, int nam)
        {
            int temp = 0;
            foreach(ChamCong cc in db.ChamCongs)
            {
                if(cc.maChamCong == maPhanCong && cc.thang == thang && cc.nam == nam)
                {
                    if(cc.D1!= null || cc.D2!=null || cc.D3 != null || cc.D4 != null || cc.D5 != null || cc.D6 != null || cc.D7 != null || cc.D8 != null || cc.D9 != null || cc.D10 != null || cc.D11 != null || cc.D12 != null || cc.D13 != null || cc.D14 != null || cc.D15 != null || cc.D16 != null || cc.D17 != null || cc.D18 != null || cc.D19 != null || cc.D20 != null || cc.D21 != null || cc.D22 != null || cc.D23 != null || cc.D24 != null || cc.D25 != null || cc.D26 != null || cc.D27 != null)
                    {
                        temp = temp + 1;
                    }
                }                
            }
            return temp;
        }

        public int kiemTraThoiGian(string maNV, DateTime nbd, DateTime nkt)
        {
            int temp = 0;
            foreach (PhanCong pc in db.PhanCongs)
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
    }
}
