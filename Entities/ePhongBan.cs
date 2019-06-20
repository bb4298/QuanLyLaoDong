using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class ePhongBan
    {
        string maPhongBan;
        string tenPhongBan;

        public string MaPhongBan { get => maPhongBan; set => maPhongBan = value; }
        public string TenPhongBan { get => tenPhongBan; set => tenPhongBan = value; }

        public ePhongBan(string maPhongBan, string tenPhongBan)
        {
            MaPhongBan = maPhongBan;
            TenPhongBan = tenPhongBan;
        }

        public ePhongBan()
        {

        }
    }
}
