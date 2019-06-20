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
namespace QuanLyLaoDong.Form_Chung
{
    public partial class Form_NhanLienHe : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db;
        LienHeBLL lhbll;
        public Form_NhanLienHe()
        {
            InitializeComponent();
            db = new QLLD_DBDataContext();
            lhbll = new LienHeBLL();
        }

        public void loadLienHeLenDTGV()
        {
            dataGridView1.DataSource = (from a in db.LienHes
                                        join b in db.NhanViens on a.maNhanVien equals b.maNhanVien
                                        join c in db.PhongBans on b.maPhongBan equals c.maPhongBan
                                        where c.maPhongBan == FormDangNhap._MaPB
                                        select new
                                        {
                                            a.maLienHe,
                                            a.maNhanVien,
                                            b.hoTen,
                                            a.email,
                                            a.noiDung,
                                            a.ngayGui,
                                            a.tpbPhanHoi,
                                            a.trangThai
                                        }
                );
        }

        private void Form_NhanLienHe_Load(object sender, EventArgs e)
        {
            loadLienHeLenDTGV();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaHoTro.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if(dataGridView1.CurrentRow.Cells["trangThai"].Value.ToString()=="Đã Xử Lý")
            {
                btnXacNhan.Enabled = false;
                tbNoiDungPhanHoi.Enabled = false;
            }
            else if(dataGridView1.CurrentRow.Cells["trangThai"].Value.ToString() == "Chưa Xử Lý")
            {
                btnXacNhan.Enabled = true;
                tbNoiDungPhanHoi.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            #region Gửi thông tin hỗ trợ đén tpb

            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Xác nhận phản hồi thông tin đến nhân viên, thao tác này không thể hoàn tác !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    if (tbNoiDungPhanHoi.Text == "")
                    {
                        XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                    }
                    else
                    {


                        //Thêm bảng công trinh
                        LienHe lh1 = new LienHe();
                        lh1.maLienHe = Convert.ToInt32(tbMaHoTro.Text);
                        lh1.tpbPhanHoi = tbNoiDungPhanHoi.Text;
                        lh1.trangThai = "Đã Xử Lý";


                        if (lhbll.suaLienHe(lh1, Convert.ToInt32(tbMaHoTro.Text)))
                        {

                            XtraMessageBox.Show("Phản hồi thành công !");

                            loadLienHeLenDTGV();
                            tbNoiDungPhanHoi.Enabled = false;
                            btnXacNhan.Enabled = false;
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

        private void Form_NhanLienHe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_NV_HT = true;
        }
    }
}