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
namespace QuanLyLaoDong.FormTPB
{
    public partial class Form_DoiMK : DevExpress.XtraEditors.XtraForm
    {
        ChuoiKetNoi ckn;
        public Form_DoiMK()
        {
            ckn = new ChuoiKetNoi();
            InitializeComponent();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = @ckn.chuoiKN();
            myCon.Open();//không có dòng này thì adapter sẽ tự open
            
            string sqlMK = @"select matKhau
                            from dbo.NhanVien a join dbo.TaiKhoan b on a.maNhanVien=b.maNhanVien
                            where tenTaiKhoan ='" + FormDangNhap._tenDN + "'";

            string sqlDoiMK = @"update TaiKhoan set matKhau = N'"  + tbMatKhauMoi.Text + "' where tenTaiKhoan = '" + FormDangNhap._tenDN + "'";
            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlMK, myCon);
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            string MK = myTable.Rows[0]["matKhau"].ToString().Trim();

            //  SqlCommand cmd = new SqlCommand(sqlMK, myCon);
            // int a = int.Parse(cmd.ExecuteScalar().ToString());
            // int kq = (int)cmd.ExecuteNonQuery();

            #region Chuối Regex để kiểm tra
                string reMK = @"^([A-Z]){1}([\w_\.!@#$%^&*()]+){5,31}$";
                Regex rgMK = new Regex(reMK);
            #endregion
            try
            {
                if(tbMatKhauCu.Text == "" || tbMatKhauMoi.Text ==""|| tbNhapLaiMK.Text == "")
                {
                    XtraMessageBox.Show("Chưa nhập đủ dữ liệu, vui lòng nhập lại !");
                }
                else
                {
                    if(tbMatKhauCu.Text != MK)
                    {
                        XtraMessageBox.Show("Mật khẩu cũ không đúng, vui lòng nhập lại !");
                    }
                    else
                    {
                        if(tbMatKhauMoi.Text != tbNhapLaiMK.Text)
                        {
                            XtraMessageBox.Show("Mật khẩu mới không trùng, vui lòng nhập lại !");
                        }
                        else
                        {
                            if (!rgMK.IsMatch(tbMatKhauMoi.Text))
                            {
                                XtraMessageBox.Show("Nhập sai thông tin ! \n Mật khẩu bao gồm ký tự chữ cái hoa, thường, chử số, ký tự đặc biệt, dấu chấm bắt đầu với ký tự in hoa, độ dài từ 6 đến 32 ký tự \n Vui lòng nhập lại !");
                            }
                            else
                            {
                                SqlCommand cmd2 = new SqlCommand(sqlDoiMK, myCon);
                                int kq = (int)cmd2.ExecuteNonQuery();
                                if (kq > 0)
                                {
                                    XtraMessageBox.Show("Sửa thành công !");

                                    myCon.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi " + ex);
            }
            myCon.Close();
        }

        private void Form_TPB_DoiMK_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_DMK = true;
        }

        private void Form_TPB_DoiMK_Load(object sender, EventArgs e)
        {

        }
    }
}