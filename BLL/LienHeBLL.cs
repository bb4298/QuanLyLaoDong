using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class LienHeBLL
    {
        QLLD_DBDataContext db;
        public LienHeBLL()
        {
            db = new QLLD_DBDataContext();
        }

        public int layMaLienHeCaoNhat()
        {
            int ma = (from a in db.LienHes
                      orderby a.maLienHe descending
                      select a.maLienHe).FirstOrDefault();
            if(ma == null)
            {
                ma = 0;
            }else
            {
                ma = ma;
            }
            return ma;
        }

        public bool themLienHe(LienHe lh)
        {
            if (!db.LienHes.Contains(lh))
            {
                db.LienHes.InsertOnSubmit(lh);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaLienHe(LienHe lh, int maLH)
        {
            LienHe lh1 = new LienHe();
            lh1 = db.LienHes.Where(a => a.maLienHe == maLH).SingleOrDefault();
            if (lh1 != null)
            {
                
                lh1.tpbPhanHoi = lh.tpbPhanHoi;
                lh1.trangThai = lh.trangThai;                
                db.SubmitChanges();
                return true;
            }
            return false;
        }

    }
}
