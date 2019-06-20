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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DAL;
using BLL;

namespace QuanLyLaoDong
{
    public partial class Form_ThongTinCaNhan : DevExpress.XtraEditors.XtraForm
    {
        ChuoiKetNoi ckn;
        NhanVienBLL nvbll;
        public static int kq;
        public Form_ThongTinCaNhan()
        {
            ckn = new ChuoiKetNoi();
            InitializeComponent();
            nvbll = new NhanVienBLL();
        }

        private void FormTBPXemThongTin_Load(object sender, EventArgs e)
        {

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

            #region Load dữ liệu lên TB
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = ckn.chuoiKN();

            myCon.Open();

            SqlDataAdapter myAdapter = new SqlDataAdapter(nvbll.loadThongTinLenTB(FormDangNhap._tenDN), myCon);
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            //textBox1.Text = myTable.Rows[indexer]["username"].ToString(); 
            //textBox2.Text = myTable.Rows[indexer]["password"].ToString();
      
            tbMaNV.Text = myTable.Rows[0]["maNhanVien"].ToString().Trim();
            tbTenNV.Text = myTable.Rows[0]["hoTen"].ToString().Trim();
            dateTimePicker1.Text = myTable.Rows[0]["ngaySinh"].ToString();
            cbbGioiTinh.Text = myTable.Rows[0]["gioiTinh"].ToString();
            tbDiaChi.Text = myTable.Rows[0]["diaChiLienHe"].ToString();
            tbSDT.Text = myTable.Rows[0]["soDienThoai"].ToString();
            tbLoaiNV.Text = myTable.Rows[0]["loaiNhanVien"].ToString();
            tbPhongBan.Text = myTable.Rows[0]["maPhongBan"].ToString();
            tbTenPhongBan.Text = myTable.Rows[0]["tenPhongBan"].ToString().Trim();

            myCon.Close();
            #endregion
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           // tbTenNV.Enabled = true;
            dateTimePicker1.Enabled = true;           
            cbbGioiTinh.Enabled = true;
            tbDiaChi.Enabled = true;
            tbSDT.Enabled = true;

            btnSua.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            tbTenNV.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            FormTBPXemThongTin_Load(sender, e);
            tbTenNV.Enabled = false;
            dateTimePicker1.Enabled = false;           
            cbbGioiTinh.Enabled = false;
            tbDiaChi.Enabled = false;
            tbSDT.Enabled = false;
            btnSua.Enabled = true;

            btnSua.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            try
            {
                SqlConnection myCon = new SqlConnection();
                myCon.ConnectionString = ckn.chuoiKN();
                myCon.Open();//không có dòng này thì adapter sẽ tự open

               
                string sqlSua = @"update NhanVien set hoTen=N'" + tbTenNV.Text + "',ngaySinh=N'" + dateTimePicker1.Text + "',gioiTinh=N'" + cbbGioiTinh.Text + "',diaChiLienHe=N'" + tbDiaChi.Text + "',soDienThoai='" + tbSDT.Text + "' where maNhanVien='" + tbMaNV.Text+"'  ";

                SqlCommand cmd = new SqlCommand(sqlSua, myCon);

                #region Chuỗi regex để kiểm tra
                string reTen = @"^[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴ]+[a-zĐaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+(\s+[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴĐ]+[a-zaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+)+$";
                Regex rgTen = new Regex(reTen);

                string reGT = @"^[TPB]+[0-9]{4}$";
                Regex rgGT = new Regex(reGT);
                #endregion

                if (!rgTen.IsMatch(tbTenNV.Text))
                {
                    XtraMessageBox.Show("Tên nhân viên viết hoa chữ đầu không bao gồm số , vui lòng nhập lại !");
                }               
                else
                {
                    kq = (int)cmd.ExecuteNonQuery();
                }
                
                if (kq > 0)
                {
                    XtraMessageBox.Show("Sửa thành công !");
                    FormTBPXemThongTin_Load(sender, e);
                    tbTenNV.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    cbbGioiTinh.Enabled = false;
                    //tbGioiTinh.Enabled = false;
                    tbSDT.Enabled = false;
                    tbDiaChi.Enabled = false;
                    myCon.Close();

                    btnSua.Focus();
                }
                else
                {
                    XtraMessageBox.Show("Sửa thất bại !");
                    myCon.Close();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lối "+ex);
            }    
        }

        private void Form_TPB_ThongTinCaNhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_TTCN = true;
        }
    }
}