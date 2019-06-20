using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PhongBanBLL
    {
        QLLD_DBDataContext db;
        public PhongBanBLL()
        {
            db =   new QLLD_DBDataContext();
        }
        public string layMaPhongBan(string tenDN, string MK)
        {

            var mpb = (from a in db.NhanViens
                       join b in db.PhongBans on a.maPhongBan equals b.maPhongBan
                       join c in db.TaiKhoans on a.maNhanVien equals c.maNhanVien
                       where c.tenTaiKhoan == tenDN && c.matKhau == MK
                       select b.maPhongBan).FirstOrDefault();
            return mpb;
        }

        public string layTenPhongBan(string tenDN, string MK)
        {

            var mpb = (from a in db.NhanViens
                       join b in db.PhongBans on a.maPhongBan equals b.maPhongBan
                       join c in db.TaiKhoans on a.maNhanVien equals c.maNhanVien
                       where c.tenTaiKhoan == tenDN && c.matKhau == MK
                       select b.tenPhongBan).FirstOrDefault();
            return mpb;
        }

    }
}
