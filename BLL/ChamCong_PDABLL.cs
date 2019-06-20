using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ChamCong_PDABLL
    {
        QLLD_DBDataContext db;
        public ChamCong_PDABLL()
        {
            db = new QLLD_DBDataContext();
        }

        public int layMaChamCongCaoNhat()
        {
            int ma = (from a in db.ChamCong_PDAs
                      orderby a.maChamCong descending
                      select a.maChamCong).FirstOrDefault();
            return ma;
        }

        public bool themChamCong(ChamCong_PDA cc)
        {
            if (!db.ChamCong_PDAs.Contains(cc))
            {
                db.ChamCong_PDAs.InsertOnSubmit(cc);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaChamCong(string maNV, int thang, int nam)
        {

            ChamCong_PDA b = new ChamCong_PDA();
            b = db.ChamCong_PDAs.Single(a => a.thang == thang && a.nam == nam && a.maNhanVien == maNV);
            if (b != null)
            {
                db.ChamCong_PDAs.DeleteOnSubmit(b);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
