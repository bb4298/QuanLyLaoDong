using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoanBLL
    {
        QLLD_DBDataContext db = new QLLD_DBDataContext();
        public bool themTaiKhoan(TaiKhoan tk)
        {
            if (!db.TaiKhoans.Contains(tk))
            {
                db.TaiKhoans.InsertOnSubmit(tk);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaTaiKhoan(string tenTK)
        {

            TaiKhoan nv1 = new TaiKhoan();
            if (nv1 != null)
            {
                nv1 = db.TaiKhoans.Single(a => a.tenTaiKhoan == tenTK);
                db.TaiKhoans.DeleteOnSubmit(nv1);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public string layTenTaiKhoan(string maNV)
        {

            var mpb = (from a in db.NhanViens
                       join b in db.TaiKhoans on a.maNhanVien equals b.maNhanVien                     
                       where a.maNhanVien.CompareTo(maNV)==0
                       select b.tenTaiKhoan).FirstOrDefault();
            return mpb;
        }

        public int kiemTraTaiKhoanTonTai(string tenTK)
        {
            int temp = 0;
            foreach (TaiKhoan tk in db.TaiKhoans)
            {
                if(tk.tenTaiKhoan == tenTK)
                {
                    temp = temp + 1;
                }
            }
            return temp;
        }
    }
}
