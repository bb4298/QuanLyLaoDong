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

namespace QuanLyLaoDong.FormNV
{
    public partial class Form_NV_XemLichLamViec : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db;
        ChuoiKetNoi ckn;
        CongTrinhBLL ctbll;

        decimal _luongCTDangChon;
        int _soNgayLam;

        public Form_NV_XemLichLamViec()
        {
            InitializeComponent();
            db = new QLLD_DBDataContext();
            ckn = new ChuoiKetNoi();
            ctbll = new CongTrinhBLL();

            cbbThang.Text = DateTime.Now.Month.ToString();
            cbbNam.Text = DateTime.Now.Year.ToString();

            //dataGridView1.Columns["luongCongTrinh"].DefaultCellStyle.Format = "###,## VND";
            
            cbbTK_CT.Text = "Theo Tên CT";
            cbbTrangThaiCT.Text = "CT Đang làm";
        }

        public void loadDataNamVaoCBB()
        {
            for (int i = 2000; i <= 3000; i++)
            {
                cbbNam.Items.Add(i);
            }

        }

        public void loadCT_DangLam_LenDTGV()
        {
            dataGridViewCT.DataSource = (from a in db.TaiKhoans
                                         join b in db.NhanViens on a.maNhanVien equals b.maNhanVien
                                         join c in db.PhanCongs on b.maNhanVien equals c.maNhanVien
                                         join d in db.CongTrinhs on c.maCongTrinh equals d.maCongTrinh
                                         where a.tenTaiKhoan == FormDangNhap._tenDN && c.trangThai == "C"
                                         select new
                                         {
                                             c.maPhanCong,
                                             d.maCongTrinh,
                                             d.tenCongTrinh,
                                             d.diaDiemXayDung,
                                             d.luongCongTrinh,
                                             d.ngayCapPhep,
                                             d.ngayKhoiCong,
                                             d.ngayHoanThanh
                                         });
        }

        public void loadCT_DaLam_LenDTGV()
        {
            dataGridViewCT.DataSource = (from a in db.TaiKhoans
                                         join b in db.NhanViens on a.maNhanVien equals b.maNhanVien
                                         join c in db.PhanCongs on b.maNhanVien equals c.maNhanVien
                                         join d in db.CongTrinhs on c.maCongTrinh equals d.maCongTrinh
                                         where a.tenTaiKhoan == FormDangNhap._tenDN && c.trangThai == "R"
                                         select new
                                         {
                                             c.maPhanCong,
                                             d.maCongTrinh,
                                             d.tenCongTrinh,
                                             d.diaDiemXayDung,
                                             d.luongCongTrinh,
                                             d.ngayCapPhep,
                                             d.ngayKhoiCong,
                                             d.ngayHoanThanh
                                         });
        }

        public DateTime layNBD(int maPC)
        {
            var nbd = (from a in db.CongTrinhs
                       join b in db.PhanCongs on a.maCongTrinh equals b. maCongTrinh
                       where b.maPhanCong == maPC
                       select b.ngayBatDauLam
                       ).FirstOrDefault();
            return Convert.ToDateTime(nbd);
        }

        public DateTime layNKT(int maPC)
        {
            var nbd = (from a in db.CongTrinhs
                       join b in db.PhanCongs on a.maCongTrinh equals b.maCongTrinh
                       where b.maPhanCong == maPC
                       select b.ngayKetThuc
                       ).FirstOrDefault();
            return Convert.ToDateTime(nbd);
        }

        public int soNgayLam(int maPC)
        {
            var nbd = (from a in db.CongTrinhs
                       join b in db.PhanCongs on a.maCongTrinh equals b.maCongTrinh
                       join c in db.ChamCongs on b.maPhanCong equals c.maPhanCong
                       where b.maPhanCong == maPC
                       select c.soNgayLam
                      ).Sum();
            
            return Convert.ToInt32(nbd);
        }

        public int tongLuong(int maPC)
        {
            var nbd = (from a in db.CongTrinhs
                       join b in db.PhanCongs on a.maCongTrinh equals b.maCongTrinh
                       join c in db.ChamCongs on b.maPhanCong equals c.maPhanCong
                       where b.maPhanCong == maPC
                       select c.luongThang
                      ).Sum();

            return Convert.ToInt32(nbd);
        }

        /*  public decimal tienLuong()
          {
              decimal tongLuong;
              tongLuong = _luongCTDangChon * _soNgayLam;
              return tongLuong;
          }*/

        public void loadDataChamCong(int thang, int nam)
        {

            SqlConnection conn = new SqlConnection(ckn.chuoiKN());
            try
            {
                conn.Open();
                string sqlLoad = "select d.maChamCong, d.maPhanCong, a.hoTen, b.ngayBatDauLam, b.ngayKetThuc, d.soNgayLam, d.soNgayNghi, d.luongThang, d.D1, d.D2, d.D3, d.D4, d.D5, d.D6, d.D7, d.D8, d.D9, d.D10, d.D11, d.D12, d.D13, d.D14, d.D15, d.D16, d.D17, d.D18, d.D19, d.D20, d.D21, d.D22, d.D23, d.D24, d.D25, d.D26, d.D27, d.D28, d.D29, d.D30, d.D31 from NhanVien a join PhanCong b on a.maNhanVien = b.maNhanVien join CongTrinh c on b.maCongTrinh = c.maCongTrinh join ChamCong d on b.maPhanCong = d.maPhanCong join PhongBan e on a.maPhongBan = e.maPhongBan where c.trangThai = 'DXD' and d.thang = "+thang+" and d.nam = "+nam+" and a.maNhanVien = '"+FormDangNhap._maNhanVien+"' and c.tenCongTrinh = N'" + tbTenCT.Text + "' and e.maPhongBan = '" + FormDangNhap._MaPB + "'";
                SqlDataAdapter dt = new SqlDataAdapter(sqlLoad, conn);
                DataTable tb = new DataTable();

                dt.Fill(tb);
                dataGridView1.DataSource = tb;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("lỗi " + e);
            }

        }

        public void loadCT_TheoCBB()
        {
            if (cbbTrangThaiCT.Text == "CT Đang Làm")
            {
                loadCT_DangLam_LenDTGV();
            }
            else if (cbbTrangThaiCT.Text == "CT Đã Làm")
            {
                loadCT_DaLam_LenDTGV();
            }
        }


        private void Form_NV_XemLichLamViec_Load(object sender, EventArgs e)
        {
            loadCT_TheoCBB();
            loadDataNamVaoCBB();
        }

        private void dataGridViewCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            tbTenCT.Text = dataGridViewCT.CurrentRow.Cells[2].Value.ToString();
            dtpNBD.Text = layNBD(Convert.ToInt32(dataGridViewCT.CurrentRow.Cells[0].Value)).ToString();
            dtpNKT.Text = layNKT(Convert.ToInt32(dataGridViewCT.CurrentRow.Cells[0].Value)).ToString();
            tbsoNgayLam.Text = soNgayLam(Convert.ToInt32(dataGridViewCT.CurrentRow.Cells[0].Value)).ToString();
            tbTienLuong.Text = tongLuong(Convert.ToInt32(dataGridViewCT.CurrentRow.Cells[0].Value)).ToString("###,## VND");
            /*_luongCTDangChon = ctbll.layLuongCT_CongTrinh(tbTenCT.Text);
            _soNgayLam = soNgayLam(Convert.ToInt32(dataGridViewCT.CurrentRow.Cells[0].Value));
            textBox1.Text = _soNgayLam.ToString();
            
            tbTienLuong.Text = (_luongCTDangChon*_soNgayLam).ToString("###,## VND");*/
            

        }

        private void dataGridViewCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewCT_CellContentClick(sender, e);
        }

        private void cbbTrangThaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCT_TheoCBB();
            loadDataChamCong(0,0);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbbTK_CT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbTimKiemCT_TextChanged(object sender, EventArgs e)
        {
            if(tbTimKiemCT.Text == null)
            {
                loadCT_TheoCBB();
            }
            else if(cbbTK_CT.Text == "Theo Mã CT")
            {
                #region Tìm kiếm CT theo mã CT
                SqlConnection myCon = new SqlConnection();
                myCon.ConnectionString = ckn.chuoiKN();
                myCon.Open();//không có dòng này thì adapter sẽ tự open

                string sqlTimKiem = ctbll.timKiemCT_XL_TheoMa(tbTimKiemCT.Text,FormDangNhap._tenDN,"C");
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                DataTable myTable = new DataTable();
                myAdapter.Fill(myTable);
                dataGridViewCT.DataSource = myTable;
                myCon.Close();
                #endregion
            }
            else if(cbbTK_CT.Text == "Theo Tên CT")
            {
                #region Tìm kiếm CT theo tên CT
                SqlConnection myCon = new SqlConnection();
                myCon.ConnectionString = ckn.chuoiKN();
                myCon.Open();//không có dòng này thì adapter sẽ tự open

                string sqlTimKiem = ctbll.timKiemCT_XL_TheoTen(tbTimKiemCT.Text, FormDangNhap._tenDN, "C");
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                DataTable myTable = new DataTable();
                myAdapter.Fill(myTable);
                dataGridViewCT.DataSource = myTable;
                myCon.Close();
                #endregion
            }
            else if (cbbTK_CT.Text == "Theo Địa Điểm")
            {
                #region Tìm kiếm CT theo tên CT
                SqlConnection myCon = new SqlConnection();
                myCon.ConnectionString = ckn.chuoiKN();
                myCon.Open();//không có dòng này thì adapter sẽ tự open

                string sqlTimKiem = ctbll.timKiemCT_XL_TheoDiaDiem(tbTimKiemCT.Text, FormDangNhap._tenDN, "C");
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                DataTable myTable = new DataTable();
                myAdapter.Fill(myTable);
                dataGridViewCT.DataSource = myTable;
                myCon.Close();
                #endregion
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            loadDataChamCong(Convert.ToInt32(cbbThang.Text), Convert.ToInt32(cbbNam.Text));
        }

        private void Form_NV_XemLichLamViec_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_NV_XLLV = true;
        }
    }
}