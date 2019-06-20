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
    public partial class Form_NVPDA_RP_DanhSachCongTrinhHT : DevExpress.XtraEditors.XtraForm
    {
        public Form_NVPDA_RP_DanhSachCongTrinhHT()
        {
            InitializeComponent();
        }

        private void Form_NVPDA_RP_DanhSachCongTrinhHT_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_DSCT_HT = true;
        }
    }
}