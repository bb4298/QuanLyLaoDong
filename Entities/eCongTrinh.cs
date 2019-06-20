using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class eCongTrinh
    {

        string maCongTrinh;
        string tenCongTrinh;
        string diaDiemXayDung;
        DateTime ngayCapPhep;
        DateTime ngayKhoiCong;
        DateTime ngayHoanThanh;
        string trangThai;

        public string MaCongTrinh { get => maCongTrinh; set => maCongTrinh = value; }
        public string TenCongTrinh { get => tenCongTrinh; set => tenCongTrinh = value; }
        public string DiaDiemXayDung { get => diaDiemXayDung; set => diaDiemXayDung = value; }
        public DateTime NgayCapPhep { get => ngayCapPhep; set => ngayCapPhep = value; }
        public DateTime NgayKhoiCong { get => ngayKhoiCong; set => ngayKhoiCong = value; }
        public DateTime NgayHoanThanh { get => ngayHoanThanh; set => ngayHoanThanh = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }

        public eCongTrinh(string maCongTrinh, string tenCongTrinh, string diaDiemXayDung, DateTime ngayCapPhep, DateTime ngayKhoiCong, DateTime ngayHoanThanh, string trangThai)
        {
            MaCongTrinh = maCongTrinh;
            TenCongTrinh = tenCongTrinh;
            DiaDiemXayDung = diaDiemXayDung;
            NgayCapPhep = ngayCapPhep;
            NgayKhoiCong = ngayKhoiCong;
            NgayHoanThanh = ngayHoanThanh;
            TrangThai = trangThai;
        }
        public eCongTrinh()
        {

        }
    }
}
