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
    public partial class Form_NVPDA_RpDanhSachCongTrinh : DevExpress.XtraEditors.XtraForm
    {
        public Form_NVPDA_RpDanhSachCongTrinh()
        {
            InitializeComponent();
        }

        private void Form_NVPDA_RpDanhSachCongTrinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_NVDA_DSCT = true;
        }

        private void Form_NVPDA_RpDanhSachCongTrinh_Load(object sender, EventArgs e)
        {

        }
    }
}