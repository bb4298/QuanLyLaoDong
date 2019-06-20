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
using DAL;
using BLL;
using System.Data.SqlClient;

namespace QuanLyLaoDong.FormNVPDA
{
    public partial class Form_NVPDA_QuanLyLuong : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db;
        PhanCongBLL pcbll;
        CongTrinhBLL ctbll;
        ChuoiKetNoi ckn;

        string _maPB = FormDangNhap._MaPB;
        string _tenNhanVienDangChon;
        string _maNhanVienDangChon;

        public Form_NVPDA_QuanLyLuong()
        {
            InitializeComponent();
            cbbNam.Text = DateTime.Now.Year.ToString();
            cbbTK_NV.Text = "Theo Tên NV";
            dataGridView1.Columns["Column1"].DefaultCellStyle.Format = "###,## VND";
            db = new QLLD_DBDataContext();
            pcbll = new PhanCongBLL();
            ctbll = new CongTrinhBLL();
            ckn = new ChuoiKetNoi();
        }

        public void loadDataLuong(int nam,  string maPDA="PB005")
        {

            SqlConnection conn = new SqlConnection(ckn.chuoiKN());
            try
            {
                conn.Open();



                string sqlLoad = "select a.maNhanVien, a.hoTen, a.ngayBatDau,a.ngayKetThuc,COUNT(d.thang),sum(d.luongThang), d.daTraLuong from NhanVien a join ChamCong_PDA d on a.maNhanVien = d.maNhanVien join PhongBan c on a.maPhongBan = c.maPhongBan where d.nam = " + nam+ " and c.maPhongBan ='"+maPDA+"' group by a.maNhanVien, a.hoTen ,a.ngayBatDau, a.ngayKetThuc, d.daTraLuong";

                SqlDataAdapter dt = new SqlDataAdapter(sqlLoad, conn);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridView1.DataSource = tb;

                conn.Close();
                dataGridView1.Columns["Column2"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex);
            }
        }

        public void loadDataNamVaoCBB()
        {
            for (int i = 2000; i <= 3000; i++)
            {
                cbbNam.Items.Add(i);
            }

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            loadDataLuong(Convert.ToInt32(cbbNam.Text));
            btnXNTL.Enabled = true;
        }

        private void btnXNTL_Click(object sender, EventArgs e)
        {
            #region Xác nhận
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Xác nhận đã trả lương cho nhân viên, thao tác này không thể hoàn tác !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    foreach (ChamCong_PDA cc in db.ChamCong_PDAs)
                    {
                        if(cc.maNhanVien == _maNhanVienDangChon)
                        {
                            cc.daTraLuong = "Đã Trả Lương";
                            db.SubmitChanges();
                        }
                    }
                    XtraMessageBox.Show("Đã xác nhận !");

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi: " + ex);
                }

            }
            #endregion
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _maNhanVienDangChon = dataGridView1.CurrentRow.Cells["maNhanVien"].Value.ToString();
            tbTenNhanVien.Text = dataGridView1.CurrentRow.Cells["hoTen"].Value.ToString();
            if(dataGridView1.CurrentRow.Cells["daTraLuong"].Value.ToString()=="Chưa")
            {
                btnXNTL.Enabled = true;
            }
            else if(dataGridView1.CurrentRow.Cells["daTraLuong"].Value.ToString() == "Đã Trả Lương")
            {
                btnXNTL.Enabled = false;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void Form_NVPDA_QuanLyLuong_Load(object sender, EventArgs e)
        {
            loadDataNamVaoCBB();
       
        }

        private void Form_NVPDA_QuanLyLuong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_NVPDA_QLL = true;
        }

        private void tbTimKiemNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}