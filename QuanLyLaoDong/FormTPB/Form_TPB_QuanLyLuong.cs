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
using System.Data.SqlClient;

namespace QuanLyLaoDong.FormTPB
{
    public partial class Form_TPB_QuanLyLuong : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db;
        PhanCongBLL pcbll;
        CongTrinhBLL ctbll;
        ChuoiKetNoi ckn;
        string _maPB = FormDangNhap._MaPB;
        string _tenNhanVienDangChon;
        int _maPhanCongDangChon;

        public Form_TPB_QuanLyLuong()
        {
            InitializeComponent();
            cbbTK_NV.Text = "Theo Tên NV";
            dataGridView1.Columns["Column1"].DefaultCellStyle.Format = "###,## VND";
            db = new QLLD_DBDataContext();
            pcbll = new PhanCongBLL();
            ctbll = new CongTrinhBLL();
            ckn = new ChuoiKetNoi();
            

        }

        public void loadDataCongTrinhVaoCBB(string _maPB)
        {
            cbbTenCongTrinh.DataSource = (from c in db.CongTrinhs
                                          where c.trangThai == "DXD"
                                          select c.tenCongTrinh
                                         );
        }

        public void loadDataLuong()
        {
           
            SqlConnection conn = new SqlConnection(ckn.chuoiKN());
            try
            {
                conn.Open();
                string sqlLoad = "select a.maNhanVien, b.maPhanCong, a.hoTen, c.tenCongTrinh, b.ngayBatDauLam,b.ngayKetThuc,COUNT(d.thang),sum(d.luongThang), b.daTraLuong from dbo.NhanVien a join dbo.PhanCong b on a.maNhanVien = b.maNhanVien join dbo.CongTrinh c on b.maCongTrinh = c.maCongTrinh join dbo.ChamCong d on b.maPhanCong = d.maPhanCong join dbo.PhongBan e on a.maPhongBan=e.maPhongBan where c.tenCongTrinh = N'" + cbbTenCongTrinh.Text+ "' and e.maPhongBan ='"+FormDangNhap._MaPB+"' group by b.maPhanCong,a.maNhanVien,a.hoTen  ,b.ngayBatDauLam,b.ngayKetThuc, c.tenCongTrinh, b.daTraLuong";
                SqlDataAdapter dt = new SqlDataAdapter(sqlLoad, conn);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridView1.DataSource = tb;

                conn.Close();

               

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex);
            }
        }

        private void Form_TPB_QuanLyLuong_Load(object sender, EventArgs e)
        {
            loadDataCongTrinhVaoCBB(_maPB);
            
        }

        private void Form_TPB_QuanLyLuong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_TPB_QLL = true;
        }

        private void cbbTenCongTrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpNgayBatDau.Value = ctbll.layNgayBD_CT(cbbTenCongTrinh.Text);
            dtpNgayKetThuc.Value = ctbll.layNgayKT_CT(cbbTenCongTrinh.Text);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            loadDataLuong();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbbTK_NV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            if (cbbTK_NV.Text == "")
            {
                loadDataLuong();
            }
            else if (cbbTK_NV.Text != "")
            {
                if (cbbTK_NV.Text == "Theo Tên NV")
                {
                    SqlConnection conn = new SqlConnection(ckn.chuoiKN());
                    try
                    {
                        conn.Open();
                        string sqlLoad = "select a.maNhanVien, b.maPhanCong, a.hoTen, c.tenCongTrinh, b.ngayBatDauLam,b.ngayKetThuc,COUNT(d.thang),sum(d.luongThang), b.daTraLuong from dbo.NhanVien a join dbo.PhanCong b on a.maNhanVien = b.maNhanVien join dbo.CongTrinh c on b.maCongTrinh = c.maCongTrinh join dbo.ChamCong d on b.maPhanCong = d.maPhanCong join dbo.PhongBan e on a.maPhongBan=e.maPhongBan where c.tenCongTrinh = N'" + cbbTenCongTrinh.Text + "' and e.maPhongBan ='" + FormDangNhap._MaPB + "' and a.hoTen like N'%" + tbTimKiemNV.Text + "%' group by b.maPhanCong,a.maNhanVien,a.hoTen  ,b.ngayBatDauLam,b.ngayKetThuc, c.tenCongTrinh, b.daTraLuong ";
                        SqlDataAdapter dt = new SqlDataAdapter(sqlLoad, conn);
                        DataTable tb = new DataTable();

                        dt.Fill(tb);
                        dataGridView1.DataSource = tb;
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("lỗi " + ex);
                    }
                }
                else if (cbbTK_NV.Text == "Theo Mã NV")
                {
                    SqlConnection conn = new SqlConnection(ckn.chuoiKN());
                    try
                    {
                        conn.Open();
                        string sqlLoad = "select a.maNhanVien, b.maPhanCong, a.hoTen, c.tenCongTrinh, b.ngayBatDauLam,b.ngayKetThuc,COUNT(d.thang),sum(d.luongThang), b.daTraLuong from dbo.NhanVien a join dbo.PhanCong b on a.maNhanVien = b.maNhanVien join dbo.CongTrinh c on b.maCongTrinh = c.maCongTrinh join dbo.ChamCong d on b.maPhanCong = d.maPhanCong join dbo.PhongBan e on a.maPhongBan=e.maPhongBan where c.tenCongTrinh = N'" + cbbTenCongTrinh.Text + "' and e.maPhongBan ='" + FormDangNhap._MaPB + "' and a.maNhanVien like N'%" + tbTimKiemNV.Text + "%' group by b.maPhanCong,a.maNhanVien,a.hoTen  ,b.ngayBatDauLam,b.ngayKetThuc, c.tenCongTrinh, b.daTraLuong ";
                        SqlDataAdapter dt = new SqlDataAdapter(sqlLoad, conn);
                        DataTable tb = new DataTable();

                        dt.Fill(tb);
                        dataGridView1.DataSource = tb;
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("lỗi " + ex);
                    }
                }
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTenNhanVien.Text = dataGridView1.CurrentRow.Cells["hoTen"].Value.ToString();
            _maPhanCongDangChon = Convert.ToInt32(dataGridView1.CurrentRow.Cells["maPhanCong"].Value);

            if (dataGridView1.CurrentRow.Cells["daTraLuong"].Value.ToString() == "Chưa")
            {
                btnXNTL.Enabled = true;
            }
            else if (dataGridView1.CurrentRow.Cells["daTraLuong"].Value.ToString() == "Đã Trả Lương")
            {
                btnXNTL.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            #region Xác nhận
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Xác nhận đã trả lương cho nhân viên, thao tác này không thể hoàn tác !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    PhanCong pc1 = new PhanCong();
                    pc1.maPhanCong = _maPhanCongDangChon;
                    pc1.trangThai = "X";
                    pc1.daTraLuong = "Đã Trả Lương";

                    if(pcbll.suaPhanCong_DaTraLuong(pc1,_maPhanCongDangChon))
                    {
                        XtraMessageBox.Show("Đã xác nhận !");
                        loadDataLuong();
                    }


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi: " + ex);
                }
           
            }
            #endregion
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbTenNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            btnXNTL.Enabled = true;
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}