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
using QuanLyLaoDong.FormTPB;
using DAL;
using BLL;
using QuanLyLaoDong.FormNVPDA;
using QuanLyLaoDong.FormNV;
using QuanLyLaoDong.Form_Chung;

namespace QuanLyLaoDong
{
    public partial class Form_Main : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db = new QLLD_DBDataContext();

        #region Biến dùng để ngăn form mở nhiều lần
        public static bool f_NV_HT = true;

        //form Thông tin cá nhân và đổi mật khẩu
        public static bool f_TTCN = true;
        public static bool f_DMK = true;


        //form tpb
        public static bool f_TPB_QLNV = true;
        public static bool f_TPB_PCNV = true;
        public static bool f_TPB_QLNC = true;
        public static bool f_TPB_CC = true;
        public static bool f_TPB_QLL = true;
        public static bool f_TPB_QLL_DTT = true;

        //form nv
        public static bool f_NV_XLLV = true;
        public static bool f_NV_LH = true;
        //tpb pda
        public static bool f_NVDA_QLCT = true;
        public static bool f_NVPDA_CC = true;
        public static bool f_NVPDA_QLNV = true;
        public static bool f_NVPDA_QLL = true;



        //form nv pda
        public static bool f_NVDA_DSNV = true;
        public static bool f_NVDA_DSCT = true;

        public static bool f_DSNV_N = true;
        public static bool f_DSCT_HT = true;

        #endregion

        NhanVienBLL nvbll;
        PhongBanBLL pbbll;
        public Form_Main()
        {
            InitializeComponent();
            nvbll = new NhanVienBLL();
            pbbll = new PhongBanBLL();
            string tenPhongBan = pbbll.layTenPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
            string tenNhanVien = nvbll.layTenNhanVien(FormDangNhap._tenDN, FormDangNhap._MK);
            lbXinChao.Text = "Xin chào: " + tenNhanVien;
            lbPhongBan.Text = "Phòng Ban: " + tenPhongBan;

            //biến ngăn mở form nhiều lần
            f_NV_HT = true;
            //form Thông tin cá nhân và đổi mật khẩu
            f_TTCN = true;
            f_DMK = true;


            //form tpb phòng ban thường
            f_TPB_QLNV = true;
            f_TPB_PCNV = true;
            f_TPB_QLNC = true;
            f_TPB_CC = true;
            f_TPB_QLL = true;
            f_TPB_QLL_DTT = true;

            //form nv phong ban thường
            f_NV_XLLV = true;
            f_NV_LH = true;
            

            //form tpb pda
            f_NVPDA_CC = true;
            f_DSNV_N = true;
            f_DSCT_HT = true;

            //form nv pda
            f_NVDA_DSNV = true;
            f_NVDA_DSCT = true;
            f_NVDA_QLCT = true;
            f_NVPDA_QLNV = true;
            f_NVPDA_QLL = true;

        }


        public void loadFormThongTin()
        {
            Form_ThongTinCaNhan form = new Form_ThongTinCaNhan();
            if (f_TTCN == true)
            {

                form.MdiParent = this;
                form.Show();

                f_TTCN = false;
            }

            else if (f_TTCN == false)
            {
               
                // form.MdiParent = this;
                form.Activate();
               // form.Focus();
               // form.ActiveControl.Focus();
               // tabbedView1.Controller.Activate();

            }
        }

        public void loadFormDoiMK()
        {
            Form_DoiMK form = new Form_DoiMK();
            if (f_DMK == true)
            {
                form.MdiParent = this;
                form.Show();

                f_DMK = false;
            }
            else if (f_DMK == false)
            {
                form.Activate();
            }
        }

       


        private void Form_TPB_Load(object sender, EventArgs e)
        {
             //form Thông tin cá nhân và đổi mật khẩu

        btnThoat.Hide();
            NhanVien pbt_tpb = nvbll.kiemTraDangNhap_PhongBanThuong_TPB(FormDangNhap._tenDN, FormDangNhap._MK);
            NhanVien pbt_nv = nvbll.kiemTraDangNhap_PhongBanThuong_NV(FormDangNhap._tenDN, FormDangNhap._MK);
            NhanVien pda_tpb = nvbll.kiemTraDangNhap_PhongDuAn_TPB(FormDangNhap._tenDN, FormDangNhap._MK);
            NhanVien pda_nv = nvbll.kiemTraDangNhap_PhongDuAn_NV(FormDangNhap._tenDN, FormDangNhap._MK);

            if (pbt_tpb != null)
            {
                rbPage_PhongThuong_NV.Dispose();
                rbPage_PhongDuAn_TPB.Dispose();
                rbPage_PhongDuAn_NV.Dispose();
                Form_ThongTinCaNhan form = new Form_ThongTinCaNhan();
                form.MdiParent = this;
                form.Show();
                f_TTCN = false;
            }
            else if (pbt_nv != null)
            {
                rbPage_PhongThuong_TPB.Dispose();
                rbPage_PhongDuAn_TPB.Dispose();
                rbPage_PhongDuAn_NV.Dispose();
                Form_ThongTinCaNhan form = new Form_ThongTinCaNhan();
                form.MdiParent = this;
                form.Show();
                f_TTCN = false;
            }
            else if (pda_tpb != null)
            {
                rbPage_PhongThuong_TPB.Dispose();
                rbPage_PhongThuong_NV.Dispose();
                rbPage_PhongDuAn_NV.Dispose();
                Form_ThongTinCaNhan form = new Form_ThongTinCaNhan();
                form.MdiParent = this;
                form.Show();
                f_TTCN = false;
            }
            else if (pda_nv != null)
            {
                rbPage_PhongThuong_TPB.Dispose();
                rbPage_PhongThuong_NV.Dispose();
                rbPage_PhongDuAn_TPB.Dispose();
                Form_ThongTinCaNhan form = new Form_ThongTinCaNhan();
                form.MdiParent = this;
                form.Show();
                f_TTCN = false;
            }
            else
            {
                MessageBox.Show("Lỗi ");
            }

        }


        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.OK)
            {
                //Application.Exit();
                this.Close();
                
            }*/
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;


            }


        }

        private void btnThoat_Click(object sender, EventArgs e, FormClosingEventArgs ex)
        {
            /*Application.Exit();*/
            Form_Main_FormClosing(sender, ex);
        }

        private void btn_PhongThuong_TPB_ThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormThongTin();
        }

        private void btn_PhongThuong_TPB_DoiMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormDoiMK();
        }

        private void btn_PhongThuong_TPB_QuanLyNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_TPB_QLNV == true)
            {
                Form_TPB_QuanLyNhanVien form = new Form_TPB_QuanLyNhanVien();
                form.MdiParent = this;
                form.Show();

                f_TPB_QLNV = false;
            }
        }

        private void btn_PhongThuong_TPB_PhanCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(f_TPB_PCNV==true)
            {
                Form_TPB_PhanCongNhanVien form = new Form_TPB_PhanCongNhanVien();
                form.MdiParent = this;
                form.Show();

                f_TPB_PCNV = false;
            }
        }

        private void btn_PhongThuong_NV_ThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormThongTin();
        }

        private void btn_PhongThuong_NV_DoiMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormDoiMK();
        }

        private void btn_PDA_TPB_ThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormThongTin();
        }

        private void btn_PDA_TPB_DoiMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormDoiMK();
        }


        private void btn_PDA_TPB_QuanLyNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_TPB_QLNV == true)
            {
                Form_NVPDA_QuanLyNhanVien form = new Form_NVPDA_QuanLyNhanVien();
                form.MdiParent = this;
                form.Show();

                f_TPB_QLNV = false;
            }
        }

        private void btn_PDA_NV_QuanLyCongTrinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NVDA_QLCT == true)
            {
                Form_NVDA_QuanLyCongTrinh form = new Form_NVDA_QuanLyCongTrinh();
                form.MdiParent = this;
                form.Show();
                f_NVDA_QLCT = false;
            }
        }

      

        private void btn_PDA_NV_ThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormThongTin();
        }

        private void btn_PDA_NV_DoiMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFormDoiMK();
        }

        private void btn_PhongThuong_NV_XemLichLamViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NV_XLLV == true)
            {
                Form_NV_XemLichLamViec form = new Form_NV_XemLichLamViec();
                form.MdiParent = this;
                form.Show();
                f_NV_XLLV = false;
            }
        }

        private void btn_PDA_NV_ReportNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NVDA_DSNV== true)
            {
                Form_NVPDA_RpDanhSachNhanVien form = new Form_NVPDA_RpDanhSachNhanVien();
                form.MdiParent = this;
                form.Show();
                f_NVDA_DSNV = false;
            }
        }

        private void btn_PDA_NV_ReportCongTrinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NVDA_DSCT == true)
            {
                Form_NVPDA_RpDanhSachCongTrinh form = new Form_NVPDA_RpDanhSachCongTrinh();
                form.MdiParent = this;
                form.Show();
                f_NVDA_DSCT = false;
            }
        }

        private void btn_PhongThuong_TPB_ChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_TPB_CC == true)
            {
                Form_TPB_ChamCong form = new Form_TPB_ChamCong();
                form.MdiParent = this;
                form.Show();
                f_TPB_CC = false;
            }
        }

        private void btn_PDA_TPB_ChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_TPB_CC == true)
            {
                Form_NVPDA_ChamCong form = new Form_NVPDA_ChamCong();
                form.MdiParent = this;
                form.Show();
                f_TPB_CC = false;
            }
        }

        private void btn_PhongThuong_TPB_QuanLyLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_TPB_QLL == true)
            {
                Form_TPB_QuanLyLuong form = new Form_TPB_QuanLyLuong();
                form.MdiParent = this;
                form.Show();
                f_TPB_QLL = false;
            }
        }

        private void btn_PDA_TPB_QuanLyLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NVPDA_QLL == true)
            {
                Form_NVPDA_QuanLyLuong form = new Form_NVPDA_QuanLyLuong();
                form.MdiParent = this;
                form.Show();
                f_NVPDA_QLL = false;
            }
        }

        private void btn_PhongThuong_TPB_QuanLyLuong_DTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_TPB_QLL_DTT == true)
            {
                Form_TPB_QuanLyLuong_DTT form = new Form_TPB_QuanLyLuong_DTT();
                form.MdiParent = this;
                form.Show();
                f_TPB_QLL_DTT = false;
            }
            
        }

        private void btn_PhongThuong_NV_LienHe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NV_LH == true)
            {
                Form_LienHe form = new Form_LienHe();
                form.MdiParent = this;
                form.Show();
                f_NV_LH = false;
            }
            
        }

        private void btn_PDA_NV_LienHe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NV_LH == true)
            {
                Form_LienHe form = new Form_LienHe();
                form.MdiParent = this;
                form.Show();
                f_NV_LH = false;
            }
           
        }

        private void btn_PhongThuong_TPB_NhanLienHe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (f_NV_HT == true)
            {
                Form_NhanLienHe form = new Form_NhanLienHe();
                form.MdiParent = this;
                form.Show();
                f_NV_HT = false;
            }
            
        }

        private void btn_PDA_TPB_NhanLienHe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (f_NV_HT == true)
            {
                Form_NhanLienHe form = new Form_NhanLienHe();
                form.MdiParent = this;
                form.Show();
                f_NV_HT = false;
            }
            
        }

        private void btn_PDA_TPB_ReportNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NVDA_DSNV == true)
            {
                Form_NVPDA_RpDanhSachNhanVien form = new Form_NVPDA_RpDanhSachNhanVien();
                form.MdiParent = this;
                form.Show();
                f_NVDA_DSNV = false;
            }
        }

        private void btn_PDA_TPB_ReportCongTrinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_NVDA_DSCT == true)
            {
                Form_NVPDA_RpDanhSachCongTrinh form = new Form_NVPDA_RpDanhSachCongTrinh();
                form.MdiParent = this;
                form.Show();
                f_NVDA_DSCT = false;
            }
        }

        private void btn_PDA_TPB_ReportNhanVienNghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_DSNV_N == true)
            {
                Form_NVPDA_RP_DanhSachNhanVienDaNghi form = new Form_NVPDA_RP_DanhSachNhanVienDaNghi();
                form.MdiParent = this;
                form.Show();
                f_DSNV_N = false;
            }
        }

        private void btn_PDA_TPB_ReportCongTrinhHT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f_DSCT_HT == true)
            {
                Form_NVPDA_RP_DanhSachCongTrinhHT form = new Form_NVPDA_RP_DanhSachCongTrinhHT();
                form.MdiParent = this;
                form.Show();
                f_DSCT_HT = false;
            }
        }
    }
}