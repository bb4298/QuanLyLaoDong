using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyLaoDong.FormNVPDA
{
    public partial class Form_NVPDA_RpDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public Form_NVPDA_RpDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void Form_NVPDA_RpDanhSachNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_NVDA_DSNV = true;
        }

        private void Form_NVPDA_RpDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            
        }
    }
}