using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BLL;
using System.Security.Cryptography;

namespace QuanLyLaoDong
{
    public partial class FormDangNhap : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBLL nvbll;
        public static string _tenDN;
        public static string _MK;
        public static string _MaPB;
        public static string _mkMH;
        public static string _maNhanVien;

        public FormDangNhap()
        {
            InitializeComponent();
            nvbll = new NhanVienBLL();
        }


        #region Mã hoá MK
        public string Md5hash(string matKhau)
        {
            byte[] passtohash = System.Text.ASCIIEncoding.Unicode.GetBytes(matKhau);
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(passtohash);
                return Convert.ToBase64String(hash);
            }
        }

        public string maHoaMK(string matKhau)
        {
            MD5 mh = MD5.Create();
            //Tạo MD5 

            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matKhau);

            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);

            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        #endregion

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            QLLD_DBDataContext db = new QLLD_DBDataContext();



            try
            {
                if (tbTaiKhoan.Text.Trim() == "" || tbMatKhau.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin !");
                    tbTaiKhoan.Focus();
                }
                else if(tbTaiKhoan.Text.Trim() != "" || tbMatKhau.Text.Trim() != "")
                {
                    /* //_mkMH = maHoaMK(tbMatKhau.Text);
                     _mkMH = Md5hash(tbMatKhau.Text).ToString();
                     #region Load dữ liệu
                     SqlConnection myCon = new SqlConnection();
                     myCon.ConnectionString = @"Data Source=DESKTOP-PTT6BR4\SQLEXPRESS;Initial Catalog=QuanLiLaoDong;Integrated Security=True";
                     myCon.Open();//không có dòng này thì adapter sẽ tự open
                     string tv = "abc";
                     string sqlMK = @"select b.tenTaiKhoan, b.matKhau
                             from dbo.NhanVien a join dbo.TaiKhoan b on a.maNhanVien=b.maNhanVien
                             where b.tenTaiKhoan = '" + tbTaiKhoan.Text + "' and b.matKhau ='" +tbMatKhau.Text+ "'";

                     SqlCommand cmd = new SqlCommand(sqlMK, myCon);
                     SqlDataReader dta = cmd.ExecuteReader();
                     if(dta.Read()==true)
                     {
                         //_tenDN = tbTaiKhoan.Text.Trim();
                       //  _MK = tbMatKhau.Text.Trim();
                         Form_Main form = new Form_Main();
                         this.Hide();
                         // form.ShowDialog();
                         form.ShowDialog();

                         this.Show();
                     }
                     else
                     {
                         XtraMessageBox.Show("Tài khoản hoặc mật khẩu không đúng, vui lòng nhập lại !");
                         tbTaiKhoan.Focus();
                     }

                    myCon.Close();
                     #endregion*/

                    //_mkMH = maHoaMK(tbMatKhau.Text);
                    // tbHashCode.Text = _mkMH;                              
                    //NhanVien nv = nvbll.kiemTraDangNhap(tbTaiKhoan.Text, "7165B6BA0908D1DA05F3B931A681A39B");

                    NhanVien nv = nvbll.kiemTraDangNhap(tbTaiKhoan.Text, tbMatKhau.Text);
                    if (nv != null)
                    {
                        _MaPB = nvbll.layMaPhongBanNhanVien(tbTaiKhoan.Text);
                        _maNhanVien = nvbll.layMaNhanVien(tbTaiKhoan.Text);

                        _tenDN = tbTaiKhoan.Text.Trim();
                        _MK = tbMatKhau.Text.Trim();
                        Form_Main form = new Form_Main();
                        this.Hide();
                        // form.ShowDialog();
                        form.ShowDialog();
                        
                        this.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Tài khoản hoặc mật khẩu không đúng, vui lòng nhập lại !");
                        tbTaiKhoan.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi:fdgd " + ex);
            }

        }



        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*try
            {
                if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;

                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex);
            }*/
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime(2019,3,10);
            DateTime dt2 = new DateTime(2019,3,5);
            TimeSpan time = dt1.Subtract(dt2);

            DateTime a = new DateTime(2019, 10, 15);//some datetime
            DateTime now = DateTime.Now;
            TimeSpan ts = now - a;
            int days = Math.Abs(ts.Days);

            tbHashCode.Text = days.ToString();
            
        }

        private void tbHashCode_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tbMatKhau_EditValueChanged(object sender, EventArgs e)
        {
            tbHashCode.Text = Md5hash(tbMatKhau.Text);
        }
    }
}
