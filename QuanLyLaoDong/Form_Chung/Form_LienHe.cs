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
using BLL;
using DAL;
using System.Text.RegularExpressions;

namespace QuanLyLaoDong.Form_Chung
{
    public partial class Form_LienHe : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db;
        LienHeBLL lhbll;
        public Form_LienHe()
        {
            InitializeComponent();
            db = new QLLD_DBDataContext();
            lhbll = new LienHeBLL();
        }

        public void xoaAllTB()
        {
            tbEmail.Text = "";
            tbNoiDung.Text = "";
        }

        public void loadHoTroLenDTGV()
        {
            dataGridView1.DataSource = (from a in db.LienHes
                                        where a.maNhanVien == FormDangNhap._maNhanVien
                                        select new
                                        {
                                            a.maLienHe,
                                            a.maNhanVien,
                                            a.email,
                                            a.noiDung,
                                            a.ngayGui,
                                            a.tpbPhanHoi,
                                            a.trangThai
                                        });
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            #region Gửi thông tin hỗ trợ đén tpb

            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Thông tin sẽ được gửi đên trưởng phòng ban, sau khi bạn xác nhận !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    if (tbEmail.Text == "" || tbNoiDung.Text == "")
                    {
                        XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                    }
                    else
                    {
                        

                        //Thêm bảng công trinh
                        LienHe lh1 = new LienHe();
                        lh1.maLienHe = lhbll.layMaLienHeCaoNhat() + 1;
                        lh1.email = tbEmail.Text.Trim();
                        lh1.noiDung = tbNoiDung.Text.Trim();
                        lh1.ngayGui = DateTime.Now;
                        lh1.maNhanVien = FormDangNhap._maNhanVien;
                        lh1.tpbPhanHoi = "";
                        lh1.trangThai = "Chưa Xử Lý";
                        

                        if (lhbll.themLienHe(lh1))
                        {
                           
                            XtraMessageBox.Show("Thêm thành công !");
                            xoaAllTB();
                            loadHoTroLenDTGV();
                        }
                        else
                        {
                            XtraMessageBox.Show("Bị trùng mã liên hệ, vui lòng nhập mã khác !");
                        }
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                dg = DialogResult.Cancel;
            }

            #endregion
        }

        private void Form_LienHe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_NV_LH = true;
        }

        private void Form_LienHe_Load(object sender, EventArgs e)
        {
            loadHoTroLenDTGV();
        }
    }
}