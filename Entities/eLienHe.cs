using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class eLienHe
    {
        string hoTen;
        string email;
        
        string noiDung;

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Email { get => email; set => email = value; }
       
        public string NoiDung { get => noiDung; set => noiDung = value; }

        public eLienHe(string hoTen, string email, string noiDung)
        {
            HoTen = hoTen;
            Email = email;          
            NoiDung = noiDung;

        }
        public eLienHe()
        {

        }
    }
}
