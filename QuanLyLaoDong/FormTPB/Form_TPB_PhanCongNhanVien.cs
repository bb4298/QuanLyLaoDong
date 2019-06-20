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
   
    public partial class Form_TPB_PhanCongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public static string _maNhanVien;
        public static string _maCongTrinh;
        // public static string _maTuTang;
        public static string _maPhanCong;
        public  decimal _luongCT_DangChon;
        public  DateTime _dateTime_NgayBatDau;
        public  DateTime _dateTime_NgayKetThuc;
        public  DateTime _dateTime_NgayKhoiCong;
        public  DateTime _dateTime_NgayHoanThanh;
        public decimal _luongDuKien;
        public int _maPC_CT;

        // biến cập nhật bảng chấm công

        public DateTime _CTCT_Goc_ngayKhoiCong;
        public DateTime _CTCT_Goc_ngayHoanThanh;

        public DateTime _CTCT_Goc_ngayBatDau;
        public DateTime _CTCT_Goc_ngayKetThuc;

        public DateTime _CTCT_Sua_ngayBatDau;
        public DateTime _CTCT_Sua_ngayKetThuc;

        //Biến thời gian lưu giá trị của dtp sau khi xác nhận

        public DateTime _dtpngayBatDau;
        public DateTime _dtp_ngayKetThuc;

        TimeSpan ts;
        QLLD_DBDataContext db;
        ChuoiKetNoi ckn;
        NhanVienBLL nvbll;
        CongTrinhBLL ctbll;
        PhongBanBLL pbbll;
        PhanCongBLL pcbll;
        ChamCongBLL ccbll;
        public Form_TPB_PhanCongNhanVien()
        {
            InitializeComponent();
            db = new QLLD_DBDataContext();
            ckn = new ChuoiKetNoi();
            nvbll = new NhanVienBLL();
            ctbll = new CongTrinhBLL();
            pbbll = new PhongBanBLL();
            pcbll = new PhanCongBLL();
            ccbll = new ChamCongBLL();
           
            dataGridViewCT.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewCT.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewCT.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        

       

        #region load Data lên datagridview
        public void loadDataNhanVien()
        {
            string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
            dataGridViewNV.DataSource = from u in db.TaiKhoans
                                       join a in db.NhanViens on u.maNhanVien equals a.maNhanVien
                                       join e in db.PhongBans on a.maPhongBan equals e.maPhongBan
                                       where e.maPhongBan.CompareTo(maPB) == 0 && u.tenTaiKhoan.CompareTo(FormDangNhap._tenDN) != 0 && a.trangThai =="L"
                                       select new
                                       {
                                           a.maNhanVien,
                                           a.hoTen,                                               
                                           a.gioiTinh,
                                           a.diaChiLienHe,
                                           a.soDienThoai
                                       };
           
        }

        public void loadDataCongTrinh()
        {           
            dataGridViewCT.DataSource = from a in db.CongTrinhs
                                       where a.trangThai == "DXD"
                                       select new
                                       {
                                           a.maCongTrinh,
                                           a.tenCongTrinh,
                                           a.diaDiemXayDung,
                                           a.luongCongTrinh,
                                           a.ngayCapPhep,
                                           a.ngayKhoiCong,
                                           a.ngayHoanThanh                                        
                                       };


        }

        public void loadCongTrinhDangLam(string maNhanVien)
        {
            dataGridViewCTDangThamGia.DataSource = from a in db.NhanViens
                                                   join b in db.PhanCongs on a.maNhanVien equals b.maNhanVien
                                                   join c in db.CongTrinhs on b.maCongTrinh equals c.maCongTrinh
                                        where a.maNhanVien == maNhanVien && c.trangThai =="DXD" && b.trangThai == "C"
                                        select new
                                        {
                                            b.maPhanCong,
                                            c.tenCongTrinh,
                                            b.ngayBatDauLam,
                                            b.ngayKetThuc,
                                            c.ngayHoanThanh
                                        };
            /*select c.tenCongTrinh
            from dbo.NhanVien a join dbo.PhanCong b on a.maNhanVien = b.maNhanVien
                                join dbo.CongTrinh c on b.maCongTrinh = c.maCongTrinh
            where a.maNhanVien = 'NV0011'*/

        }
        #endregion

        

        private void Form_TPB_PhanCongNhanVien_Load(object sender, EventArgs e)
        {
            loadDataNhanVien();
            loadDataCongTrinh();
            cbbTK_NV.Text = "Theo Tên NV";
            cbbTK_CT.Text = "Theo Tên CT";

        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             tbTenNV.Text = dataGridViewNV.CurrentRow.Cells[1].Value.ToString().Trim();
            _maNhanVien = dataGridViewNV.CurrentRow.Cells[0].Value.ToString().Trim();           
            loadCongTrinhDangLam(_maNhanVien);
            khoaControlCT();
            xoaTB_CT();
            groupControl5.Text = "Danh sách công trình nhân viên "+tbTenNV.Text+" đang tham gia";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTenCongTrinh.Text = dataGridViewCT.CurrentRow.Cells[1].Value.ToString().Trim();
            _maCongTrinh = dataGridViewCT.CurrentRow.Cells[0].Value.ToString().Trim();

            _dateTime_NgayKhoiCong = Convert.ToDateTime(dataGridViewCT.CurrentRow.Cells[5].Value);
            _dateTime_NgayHoanThanh = Convert.ToDateTime(dataGridViewCT.CurrentRow.Cells[6].Value);
            dtpBatDauLam.Value = _dateTime_NgayKhoiCong;
            dtpKetThuc.Value = _dateTime_NgayHoanThanh;
            _luongCT_DangChon = ctbll.layLuongCT_CongTrinhDangChon(dataGridViewCT.CurrentRow.Cells["maCongTrinh"].Value.ToString());
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTenCongTrinh.Text = dataGridViewCT.CurrentRow.Cells[1].Value.ToString().Trim();
            _maCongTrinh = dataGridViewCT.CurrentRow.Cells[0].Value.ToString().Trim();
            _dateTime_NgayKhoiCong = Convert.ToDateTime(dataGridViewCT.CurrentRow.Cells[5].Value);
            _dateTime_NgayHoanThanh = Convert.ToDateTime(dataGridViewCT.CurrentRow.Cells[6].Value);
            dtpBatDauLam.Value = _dateTime_NgayKhoiCong;
            dtpKetThuc.Value = _dateTime_NgayHoanThanh;

        }

        private void tbTenNV_EditValueChanged(object sender, EventArgs e)
        {
            if(tbTenCongTrinh.Text != "")
            {
                btnXacNhan.Enabled = true;
                btnHuy.Enabled = true;
                dtpBatDauLam.Enabled = true;
                dtpKetThuc.Enabled = true;
            }
        }

        private void tbTenCongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if(tbTenNV.Text != "")
            {
                btnXacNhan.Enabled = true;
                btnHuy.Enabled = true;
                dtpBatDauLam.Enabled = true;         
                //dtpKetThuc.Text = DateTime.Now.ToString();
                tbSoNgayCong.ResetText();
                tbLuongDuKien.ResetText();
                dtpKetThuc.Enabled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
           // dtpBatDauLam.Text = "";
          //  dtpKetThuc.Text="";
            tbSoNgayCong.ResetText();
            tbLuongDuKien.ResetText();
           // dtpBatDauLam.Value = DateTime.Now;
           // dtpKetThuc.Value = DateTime.Now;
            tbTenNV.Text = null;
            tbTenCongTrinh.Text = null;
            loadDataCongTrinh();
            loadDataNhanVien();
            dtpBatDauLam.Enabled = false;
            dtpKetThuc.Enabled = false;
            //dataGridViewCTDangThamGia.DataSource = "";
            loadCongTrinhDangLam("0");
            btnPhanCong.Enabled = false;
            btnHuy.Enabled = false;
            btnXacNhan.Enabled = false;
        }

        public static IEnumerable<DateTime> layDanhSachThangLam(DateTime From, DateTime To)
        {
            while (From <= To)
            {
                yield return From;
                From = From.AddMonths(1);
            }
        }

        public bool kiemTraNamNhuan(int pYear)
        {
            if ((pYear % 400 == 0) || (pYear % 4 == 0 && pYear % 100 != 0))
            {
                return true;
            }

            return false;
        }


        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            #region Phân Công

            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn phân công nhân viên vào công trình này không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                if (tbSoNgayCong.Text == "" || tbLuongDuKien.Text== "")
                {
                    XtraMessageBox.Show("Vui lòng chọn ngày bắt đầu và ngày kết thúc !");
                }
                else if(pcbll.kiemTraPhanCongTonTai(_maNhanVien,_maCongTrinh)>=1)
                {
                    XtraMessageBox.Show("Nhân viên đã được phân công vào công trình này ,không thể phân công hai lần !");
                }
                else if (pcbll.kiemTraThoiGian(_maNhanVien, dtpBatDauLam.Value, dtpKetThuc.Value) != 0)
                {
                    XtraMessageBox.Show("Lịch phân công bị trùng với công trình trước, vui lòng phân công lại !");
                }               
                else
                {
                    try
                    {
                        //loadMaPC();
                        int maPhanCong;
                        if (pcbll.layMaPhanCongCaoNhat() == null)
                        {
                            maPhanCong = 1;
                        }
                        else
                        {
                            maPhanCong = pcbll.layMaPhanCongCaoNhat() + 1;
                        }


                        //Thêm bảng phân công
                        PhanCong pc1 = new PhanCong();
                        pc1.maPhanCong = maPhanCong;
                        pc1.maNhanVien = _maNhanVien;
                        pc1.maCongTrinh = _maCongTrinh;
                        pc1.ngayBatDauLam = dtpBatDauLam.Value;
                        pc1.ngayKetThuc = dtpKetThuc.Value;
                        // pc1.soNgayCong = int.Parse(tbSoNgayCong.Text);
                        //pc1.tienLuong = float.Parse(tbLuongDuKien.Text);
                        pc1.soNgayCong = Convert.ToInt32(tbSoNgayCong.Text.Trim());
                        pc1.tienLuong = _luongDuKien;
                        pc1.trangThai = "C";
                        pc1.daTraLuong = "Chưa";

                        if (pcbll.ThemPhanCong(pc1))
                        {
                            XtraMessageBox.Show("Thêm nhân viên vào công trình thành công !");

                            foreach (DateTime x in layDanhSachThangLam(_dtpngayBatDau, _dtp_ngayKetThuc))
                            {
                                if (x.Month == 1 || x.Month == 3 || x.Month == 5 || x.Month == 7 || x.Month == 8 || x.Month == 10 || x.Month == 12)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = maPhanCong;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    ccbll.themChamCong(cc1);

                                }
                                else if (x.Month == 4 || x.Month == 6 || x.Month == 9 || x.Month == 11)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = maPhanCong;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                                else if (x.Month == 2)
                                {
                                    if (kiemTraNamNhuan(x.Year) == true)
                                    {
                                        ChamCong cc1 = new ChamCong();
                                        cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                        cc1.maPhanCong = maPhanCong;
                                        cc1.thang = x.Month;
                                        cc1.nam = x.Year;
                                        cc1.soNgayLam = 0;
                                        cc1.soNgayNghi = 0;
                                        cc1.luongThang = 0;
                                        cc1.D30 = "X";
                                        cc1.D31 = "X";
                                        ccbll.themChamCong(cc1);
                                    }
                                    if (kiemTraNamNhuan(x.Year) == false)
                                    {
                                        ChamCong cc1 = new ChamCong();
                                        cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                        cc1.maPhanCong = maPhanCong;
                                        cc1.thang = x.Month;
                                        cc1.nam = x.Year;
                                        cc1.soNgayLam = 0;
                                        cc1.soNgayNghi = 0;
                                        cc1.luongThang = 0;
                                        cc1.D29 = "X";
                                        cc1.D30 = "X";
                                        cc1.D31 = "X";
                                        ccbll.themChamCong(cc1);
                                    }
                                }

                                // textBox1.Text = pcbll.kiemTraPhanCongTonTai(_maNhanVien, _maCongTrinh).ToString();
                                tbTenCongTrinh.Text = null;
                                loadDataCongTrinh();
                                tbSoNgayCong.ResetText();
                                tbLuongDuKien.ResetText();
                                dtpBatDauLam.Enabled = false;
                                dtpKetThuc.Enabled = false;
                                loadCongTrinhDangLam(_maNhanVien);
                                btnXacNhan.Enabled = false;
                                btnPhanCong.Enabled = false;

                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại !");
                        }

                        
                    }


                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi: " + ex);
                    }
                }

            }
            else
            {
                dg = DialogResult.Cancel;
            }

            #endregion
        }

        private void dtpBatDauLam_ValueChanged(object sender, EventArgs e)
        {
            _dateTime_NgayBatDau = new DateTime();   
            _dateTime_NgayBatDau = dtpBatDauLam.Value;// Ngày bắt đâu làm
          //  DateTime FirstSunday = _dateTime_NgayBatDau.AddDays(7 - (double)_dateTime_NgayBatDau.DayOfWeek); // ngày chủ nhật đầu tiên
           // textBox2.Text = FirstSunday.ToString();

            _dateTime_NgayKetThuc = new DateTime();
            _dateTime_NgayKetThuc = dtpKetThuc.Value;// Ngày kết thúc
         
            ts = _dateTime_NgayKetThuc - _dateTime_NgayBatDau;
          
            int soNgayCong = Convert.ToInt32(ts.TotalDays) +1 ;
            _luongDuKien = soNgayCong * 500000;
            dtpKetThuc.Enabled = true;
     
          
        }

        private void dtpKetThuc_ValueChanged(object sender, EventArgs e)
        {
            _dateTime_NgayKetThuc = new DateTime();
            _dateTime_NgayKetThuc = dtpKetThuc.Value;
           
            ts = _dateTime_NgayKetThuc - _dateTime_NgayBatDau;           
            int soNgayCong = Convert.ToInt32(ts.TotalDays) +1 ;
            _luongDuKien = soNgayCong * 500000;
            
                if (_luongDuKien > 0)
                {
                    tbLuongDuKien.Text = Convert.ToString(_luongDuKien.ToString("#,###.## VND"));
                    //tbSoNgayCong.Text = Convert.ToString(ts.TotalDays);
                    tbSoNgayCong.Text = Convert.ToString(soNgayCong);
                }
                else
                {
                    XtraMessageBox.Show("Ngày kết thúc công trình của nhân viên phải sau ngày bắt đầu !");
                    // dtpKetThuc.Text = DateTime.Now.ToShortDateString();
                    dtpKetThuc.Value = _dateTime_NgayHoanThanh;
                }
            
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            _dtpngayBatDau = dtpBatDauLam.Value;
            _dtp_ngayKetThuc = dtpKetThuc.Value;

            dtpBatDauLam.Enabled = false;
            dtpKetThuc.Enabled = false;
            _dateTime_NgayKetThuc = new DateTime();
            _dateTime_NgayKetThuc = dtpKetThuc.Value;

            ts = _dateTime_NgayKetThuc - _dateTime_NgayBatDau;
            int soNgayCong = Convert.ToInt32(ts.TotalDays);
            _luongDuKien = soNgayCong * _luongCT_DangChon;
            if (DateTime.Compare(_dateTime_NgayBatDau, _dateTime_NgayKhoiCong) < 0)
            {
                XtraMessageBox.Show("Ngày bắt đầu làm việc của nhân viên không được nhỏ hơn ngày khởi công !");
                //dtpBatDauLam.Text = DateTime.Now.ToShortDateString();
                dtpBatDauLam.Value = _dateTime_NgayKhoiCong;
            }
            else if (DateTime.Compare(_dateTime_NgayKetThuc, _dateTime_NgayHoanThanh) > 0)
            {
                XtraMessageBox.Show("Ngày kết thúc làm việc của nhân viên không được lớn hơn ngày hoàn thành công trình !");
                //dtpBatDauLam.Text = DateTime.Now.ToShortDateString();
                dtpKetThuc.Value = _dateTime_NgayHoanThanh;
            }
            else if (pcbll.kiemTraThoiGian(_maNhanVien, dtpBatDauLam.Value, dtpKetThuc.Value) != 0)
            {
                XtraMessageBox.Show("Lịch phân công bị trùng với công trình trước, vui lòng phân công lại !");
                dtpBatDauLam.Enabled = true;
                dtpKetThuc.Enabled = true;
            }
            else
            {
               // if (_luongDuKien > 0)
                //{
                    tbLuongDuKien.Text = Convert.ToString(_luongDuKien.ToString("#,###.## VND"));
                    //tbSoNgayCong.Text = Convert.ToString(ts.TotalDays);
                    tbSoNgayCong.Text = Convert.ToString(soNgayCong);
                    btnXacNhan.Enabled = false;
                    btnPhanCong.Enabled = true;
               // }
              /*  else
                {
                    XtraMessageBox.Show("Ngày kết thúc công trình của nhân viên phải sau ngày bắt đầu !");
                    // dtpKetThuc.Text = DateTime.Now.ToShortDateString();
                    dtpKetThuc.Value = _dateTime_NgayHoanThanh;
                }*/
                
            }
        }

        private void tbTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            if (tbTimKiemNV.Text == "")
            {
                loadDataNhanVien();
            }
            else if (tbTimKiemNV.Text != "")
            {
                if (cbbTK_NV.Text == "Theo Tên NV")
                {
                    #region Tìm kiếm NV theo tên NV 
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = @ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open
                    string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                    string sqlTimKiem = @nvbll.timKiemNV_TheoTen(maPB, FormDangNhap._tenDN, tbTimKiemNV.Text);
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridViewNV.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
                else if(cbbTK_NV.Text == "Theo Mã NV")
                {
                    #region Tìm kiếm NV theo mã NV 
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = @ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open
                    string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                    string sqlTimKiem = @nvbll.timKiemNV_TheoMa(maPB, FormDangNhap._tenDN, tbTimKiemNV.Text);
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridViewNV.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
                else if (cbbTK_NV.Text == "Theo SDT")
                {
                    #region Tìm kiếm NV theo SDT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = @ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open
                    string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                    string sqlTimKiem = @nvbll.timKiemNV_TheoSDT(maPB, FormDangNhap._tenDN, tbTimKiemNV.Text);
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridViewNV.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }

            }
        }

        private void tbTimKiemCT_TextChanged(object sender, EventArgs e)
        {
            if (tbTimKiemCT.Text == "")
            {
                // loadDataNhanVien();
                loadDataCongTrinh();
            }
            else if (tbTimKiemCT.Text != "")
            {
                if (cbbTK_CT.Text == "Theo Tên CT")
                {
                    #region Tìm kiếm CT theo tên CT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_TheoTen(tbTimKiemCT.Text);
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridViewCT.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
                else if(cbbTK_CT.Text == "Theo Mã CT")
                {
                    #region Tìm kiếm CT theo mã CT 
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_TheoMa(tbTimKiemCT.Text);
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridViewCT.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
            }

        }

        private void dataGridViewCTDangThamGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _CTCT_Goc_ngayKhoiCong = ctbll.layNgayKhoiCong(Convert.ToInt32(dataGridViewCTDangThamGia.CurrentRow.Cells[0].Value));
            _CTCT_Goc_ngayHoanThanh = ctbll.layNgayHoanThanh(Convert.ToInt32(dataGridViewCTDangThamGia.CurrentRow.Cells[0].Value));

           // textBox2.Text = _CTCT_Goc_ngayKhoiCong.ToString();
           // textBox3.Text = _CTCT_Goc_ngayHoanThanh.ToString();

            _CTCT_Goc_ngayBatDau = Convert.ToDateTime(dataGridViewCTDangThamGia.CurrentRow.Cells["ngayBatDauLam1"].Value);
            _CTCT_Goc_ngayKetThuc = Convert.ToDateTime(dataGridViewCTDangThamGia.CurrentRow.Cells["ngayKetThuc1"].Value);

          // textBox2.Text = _CTCT_Goc_ngayBatDau.ToString();
          // textBox3.Text = _CTCT_Goc_ngayKetThuc.ToString();

            DateTime CTNBD = Convert.ToDateTime(dataGridViewCTDangThamGia.CurrentRow.Cells[2].Value);
            DateTime CTNKT = Convert.ToDateTime(dataGridViewCTDangThamGia.CurrentRow.Cells[3].Value);

            dtpCTNgayBatDau.Text = CTNBD.ToString();
            dtpCTNgayKetThuc.Text = CTNKT.ToString();

            btnCTSua.Enabled = true;
           // btnCTXoa.Enabled = true;
            // btnCTXacNhan.Enabled = true;
            _maPC_CT = Convert.ToInt32(dataGridViewCTDangThamGia.CurrentRow.Cells[0].Value);

        }

        private void dataGridViewCTDangThamGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewCTDangThamGia_CellContentClick(sender, e);
        }

        private void Form_TPB_PhanCongNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_TPB_PCNV = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnCTSua.Enabled = false;
            dtpCTNgayBatDau.Enabled = true;
            dtpCTNgayKetThuc.Enabled = true;
            btnCTXacNhan.Enabled = true;
            btnCTHuy.Enabled = true;
          //  btnCTLuu.Enabled = true;
          //  btnCTXoa.Enabled = false;
        }

        private void btnCTHuy_Click(object sender, EventArgs e)
        {
            btnCTSua.Enabled = false;
            btnCTXacNhan.Enabled = false;
          //  btnCTXoa.Enabled = false;
            btnCTHuy.Enabled = false;
            dtpCTNgayKetThuc.Enabled = false;
            dtpCTNgayBatDau.Enabled = false;
            btnCTLuu.Enabled = false;
            btnCTSua.Enabled = true;
            dtpCTNgayBatDau.Value = DateTime.Now;
            dtpCTNgayKetThuc.Value = DateTime.Now;
        }
        private void khoaControlCT()
        {
           // btnCTXoa.Enabled = false;
            btnCTXacNhan.Enabled = false;
            btnCTSua.Enabled = false;
            btnCTLuu.Enabled = false;
            btnCTHuy.Enabled = false;
            dtpCTNgayKetThuc.Enabled = false;
            dtpCTNgayBatDau.Enabled = false;
        }

        private void btnCTXacNhan_Click(object sender, EventArgs e)
        {
            _CTCT_Sua_ngayBatDau = dtpCTNgayBatDau.Value;
            _CTCT_Sua_ngayKetThuc = dtpCTNgayKetThuc.Value;

            //DateTime NBD = ctbll.layNgayBD_CT(dataGridViewCTDangThamGia.CurrentRow.Cells[3].Value.ToString());
            //DateTime NKT = ctbll.layNgayKT_CT(dataGridViewCTDangThamGia.CurrentRow.Cells[3].Value.ToString());


            DateTime NBD = dtpCTNgayBatDau.Value;
            DateTime NKT = dtpCTNgayKetThuc.Value;

            //textBox1.Text = NBD.ToString();
            // textBox2.Text = NKT.ToString();

            ts = NKT - NBD;
            int soNgayCong = Convert.ToInt32(ts.TotalDays);
            decimal luongCT = ctbll.layLuongCT_CongTrinh(dataGridViewCTDangThamGia.CurrentRow.Cells[1].Value.ToString());
            decimal luongDuKien = Convert.ToDecimal(soNgayCong)* luongCT;

           if (DateTime.Compare(dtpCTNgayBatDau.Value, _CTCT_Goc_ngayKhoiCong) < 0)
            {
                XtraMessageBox.Show("Ngày bắt đầu làm việc của nhân viên không được nhỏ hơn ngày khởi công !");
                //dtpBatDauLam.Text = DateTime.Now.ToShortDateString();
                dtpCTNgayBatDau.Value = NBD;
            }
            else if (DateTime.Compare(dtpCTNgayKetThuc.Value,_CTCT_Goc_ngayHoanThanh) > 0)
            {
                XtraMessageBox.Show("Ngày kết thúc làm việc của nhân viên không được lớn hơn ngày hoàn thành công trình !");
                //dtpBatDauLam.Text = DateTime.Now.ToShortDateString();
                dtpCTNgayKetThuc.Value = NKT;
            }
            else if (pcbll.kiemTraThoiGian_SuaNgay(Convert.ToInt32(dataGridViewCTDangThamGia.CurrentRow.Cells[0].Value),_maNhanVien, dtpCTNgayBatDau.Value, dtpCTNgayKetThuc.Value) != 0)
            {
                XtraMessageBox.Show("Lịch phân công bị trùng với công trình trước, vui lòng phân công lại !");
               // textBox1.Text = Convert.ToInt32(dataGridViewCTDangThamGia.CurrentRow.Cells[0].Value).ToString();
               // textBox2.Text = pcbll.kiemTraThoiGian_SuaNgay(Convert.ToInt32(dataGridViewCTDangThamGia.CurrentRow.Cells[0].Value), _maNhanVien, dtpCTNgayBatDau.Value, dtpCTNgayKetThuc.Value).ToString();
            }
            else if(_CTCT_Sua_ngayBatDau.Month == _CTCT_Goc_ngayBatDau.Month && _CTCT_Sua_ngayKetThuc.Month ==_CTCT_Goc_ngayKetThuc.Month  &&  _CTCT_Sua_ngayBatDau.Year == _CTCT_Goc_ngayBatDau.Year && _CTCT_Sua_ngayKetThuc.Year == _CTCT_Goc_ngayKetThuc.Year)
            {
                XtraMessageBox.Show("Chỉ sửa phân công khi có sự thay đổi về tháng, vui lòng phân công lại !");
            }
            else
            {
                if (luongDuKien > 0)
                {
                    //_CTCT_Sua_ngayBatDau = dtpCTNgayBatDau.Value;
                    //_CTCT_Sua_ngayKetThuc = dtpCTNgayKetThuc.Value;

                    tbCTLuongDuKien.Text = Convert.ToString(luongDuKien.ToString("#,###.## VND"));
                    //tbSoNgayCong.Text = Convert.ToString(ts.TotalDays);
                    tbCTSoNgayCong.Text = Convert.ToString(soNgayCong);
                    btnCTXacNhan.Enabled = false;
                    //btnPhanCong.Enabled = true;
                    btnCTLuu.Enabled = true;
                    dtpCTNgayBatDau.Enabled = false;
                    dtpCTNgayKetThuc.Enabled = false;

                }
                else
                {
                    XtraMessageBox.Show("Ngày kết thúc công trình của nhân viên phải sau ngày bắt đầu !");
                    // dtpKetThuc.Text = DateTime.Now.ToShortDateString();
                    dtpCTNgayKetThuc.Value = NKT;
                }

            }
            
        }

        public void xoaTB_CT()
        {
            dtpCTNgayBatDau.ResetText();
            dtpCTNgayKetThuc.ResetText();
            tbCTSoNgayCong.ResetText();
            tbCTLuongDuKien.ResetText();
        }

        /*private void dtpCTNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            _dateTime_NgayKetThuc = new DateTime();
            _dateTime_NgayKetThuc = dtpKetThuc.Value;
            DateTime NBD = dtpCTNgayBatDau.Value;
            DateTime NKT = dtpCTNgayKetThuc.Value;

            ts = NKT-NBD;
            int soNgayCong = Convert.ToInt32(ts.TotalDays) + 1;
            _luongDuKien = soNgayCong * ctbll.layLuongCT_CongTrinh(dataGridViewCTDangThamGia.CurrentRow.Cells[1].Value.ToString());

            if (_luongDuKien > 0)
            {
                tbCTLuongDuKien.Text = Convert.ToString(_luongDuKien.ToString("#,###.## VND"));
                //tbSoNgayCong.Text = Convert.ToString(ts.TotalDays);
                tbCTSoNgayCong.Text = Convert.ToString(soNgayCong);
            }
            else
            {
                XtraMessageBox.Show("Ngày kết thúc công trình của nhân viên phải sau ngày bắt đầu !");
                // dtpKetThuc.Text = DateTime.Now.ToShortDateString();
                dtpCTNgayKetThuc.Value = NBD;
            }
        }*/

        private void dtpCTNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCTLuu_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Chỉ thay đổi lịch khi nhân viên chưa đi làm vào tháng có sự thay đổi\n Bạn có muốn thay đổi lịch của nhân viên này không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                

                DateTime NBD = ctbll.layNgayBD_CT(dataGridViewCTDangThamGia.CurrentRow.Cells[1].Value.ToString());
                DateTime NKT = ctbll.layNgayKT_CT(dataGridViewCTDangThamGia.CurrentRow.Cells[1].Value.ToString());

                ts = NKT - NBD;
                int soNgayCong = Convert.ToInt32(ts.TotalDays);
                decimal luongCT = ctbll.layLuongCT_CongTrinh(dataGridViewCTDangThamGia.CurrentRow.Cells[1].Value.ToString());
                decimal luongDuKien = Convert.ToDecimal(soNgayCong) * luongCT;

                //kiểm tra bảng chấm công đã có dữ liệu chưa

                #region Kiểm tra bảng chấm công
                if (_CTCT_Sua_ngayBatDau.Month == _CTCT_Goc_ngayBatDau.Month && _CTCT_Sua_ngayBatDau.Year == _CTCT_Goc_ngayBatDau.Year   &&   _CTCT_Sua_ngayKetThuc.Month < _CTCT_Goc_ngayKetThuc.Month && _CTCT_Sua_ngayKetThuc.Year < _CTCT_Goc_ngayKetThuc.Year)
                {
                    foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayKetThuc.AddMonths(1),_CTCT_Goc_ngayKetThuc))
                    {
                        if(ccbll.kiemTraChamCongDaCoDuLieu(_maPC_CT,x.Month,x.Year)!= 0)
                        {
                            XtraMessageBox.Show("Nhân viên đã đi làm vào tháng này, không thể thay đổi lịch");
                          //  break;
                        }
                    }
                    
                }                
                else if(_CTCT_Sua_ngayBatDau.Month > _CTCT_Goc_ngayBatDau.Month && _CTCT_Sua_ngayBatDau.Year > _CTCT_Goc_ngayBatDau.Year  &&   _CTCT_Sua_ngayKetThuc.Month < _CTCT_Goc_ngayKetThuc.Month && _CTCT_Sua_ngayKetThuc.Year < _CTCT_Goc_ngayKetThuc.Year)
                {
                    foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayBatDau, _CTCT_Sua_ngayBatDau.AddMonths(-1)))
                    {
                        if (ccbll.kiemTraChamCongDaCoDuLieu(_maPC_CT, x.Month, x.Year) != 0)
                        {
                            XtraMessageBox.Show("Nhân viên đã đi làm vào tháng này, không thể thay đổi lịch");
                           // break;
                        }
                    }
                    foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayKetThuc.AddMonths(1), _CTCT_Goc_ngayKetThuc))
                    {
                        if (ccbll.kiemTraChamCongDaCoDuLieu(_maPC_CT, x.Month, x.Year) != 0)
                        {
                            XtraMessageBox.Show("Nhân viên đã đi làm vào tháng này, không thể thay đổi lịch");
                           // break;
                        }
                    }
                }
               
                else if (_CTCT_Sua_ngayBatDau.Month < _CTCT_Goc_ngayBatDau.Month && _CTCT_Sua_ngayBatDau.Year < _CTCT_Goc_ngayBatDau.Year &&   _CTCT_Sua_ngayKetThuc.Month < _CTCT_Goc_ngayKetThuc.Month && _CTCT_Sua_ngayKetThuc.Year < _CTCT_Goc_ngayKetThuc.Year)
                {                    
                    foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayKetThuc.AddMonths(1), _CTCT_Goc_ngayKetThuc))
                    {
                        if (ccbll.kiemTraChamCongDaCoDuLieu(_maPC_CT, x.Month, x.Year) != 0)
                        {
                            XtraMessageBox.Show("Nhân viên đã đi làm vào tháng này, không thể thay đổi lịch");
                          //  break;
                        }
                    }
                }
                else if (_CTCT_Sua_ngayBatDau.Month > _CTCT_Goc_ngayBatDau.Month && _CTCT_Sua_ngayBatDau.Year > _CTCT_Goc_ngayBatDau.Year &&   _CTCT_Sua_ngayKetThuc.Month > _CTCT_Goc_ngayKetThuc.Month && _CTCT_Sua_ngayKetThuc.Year > _CTCT_Goc_ngayKetThuc.Year)
                {
                    foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayBatDau, _CTCT_Sua_ngayBatDau.AddMonths(-1)))
                    {
                        if (ccbll.kiemTraChamCongDaCoDuLieu(_maPC_CT, x.Month, x.Year) != 0)
                        {
                            XtraMessageBox.Show("Nhân viên đã đi làm vào tháng này, không thể thay đổi lịch");
                           // break;
                        }
                    }    
                }
                else
                {
   
                }

                #endregion kiểm tra chấm công có dữ liệu

                //Sửa bảng phân công
                PhanCong pc1 = new PhanCong();
                pc1.maPhanCong = _maPC_CT;
                pc1.ngayBatDauLam = dtpCTNgayBatDau.Value;
                pc1.ngayKetThuc = dtpCTNgayKetThuc.Value;
                // pc1.soNgayCong = int.Parse(tbSoNgayCong.Text);
                //pc1.tienLuong = float.Parse(tbLuongDuKien.Text);
                pc1.soNgayCong = Convert.ToInt32(tbCTSoNgayCong.Text);
                pc1.tienLuong = luongDuKien;
                pc1.trangThai = "C";

                if (pcbll.suaPhanCong_DoiNgay(pc1, _maPC_CT))
                {
                    XtraMessageBox.Show("Thay đổi lịch thành công !");
                    loadCongTrinhDangLam(_maNhanVien);
                    dtpCTNgayBatDau.Value = DateTime.Now;
                    dtpCTNgayKetThuc.Value = DateTime.Now;
                    btnCTSua.Enabled = false;
                    //   btnCTXoa.Enabled = false;
                    btnCTHuy.Enabled = false;
                    btnCTLuu.Enabled = false;

                    #region Tổng Lưu bảng chấm công
                    if (_CTCT_Sua_ngayBatDau == _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc < _CTCT_Goc_ngayKetThuc)
                    {
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayKetThuc.AddMonths(1), _CTCT_Goc_ngayKetThuc))
                        {
                            ccbll.xoaChamCong(_maPC_CT, x.Month, x.Year);
                        }

                    }
                    else if (_CTCT_Sua_ngayBatDau > _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc == _CTCT_Goc_ngayKetThuc)
                    {
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayBatDau, _CTCT_Sua_ngayBatDau.AddMonths(-1)))
                        {
                            ccbll.xoaChamCong(_maPC_CT, x.Month, x.Year);
                        }
                    }
                    else if (_CTCT_Sua_ngayBatDau > _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc < _CTCT_Goc_ngayKetThuc)
                    {
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayBatDau, _CTCT_Sua_ngayBatDau.AddMonths(-1)))
                        {
                            ccbll.xoaChamCong(_maPC_CT, x.Month, x.Year);
                        }
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayKetThuc.AddMonths(1), _CTCT_Goc_ngayKetThuc))
                        {
                            ccbll.xoaChamCong(_maPC_CT, x.Month, x.Year);
                        }
                    }
                    else if (_CTCT_Sua_ngayBatDau < _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc > _CTCT_Goc_ngayKetThuc)
                    {
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayBatDau, _CTCT_Goc_ngayBatDau.AddMonths(-1)))
                        {
                            #region thêm bảng chấm công
                            if (x.Month == 1 || x.Month == 3 || x.Month == 5 || x.Month == 7 || x.Month == 8 || x.Month == 10 || x.Month == 12)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 4 || x.Month == 6 || x.Month == 9 || x.Month == 11)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                cc1.D31 = "X";
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 2)
                            {
                                if (kiemTraNamNhuan(x.Year) == true)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                                if (kiemTraNamNhuan(x.Year) == false)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D29 = "X";
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                            }
                            #endregion
                        }
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayKetThuc.AddMonths(1), _CTCT_Sua_ngayKetThuc))
                        {
                            #region thêm bảng chấm công
                            if (x.Month == 1 || x.Month == 3 || x.Month == 5 || x.Month == 7 || x.Month == 8 || x.Month == 10 || x.Month == 12)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 4 || x.Month == 6 || x.Month == 9 || x.Month == 11)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                cc1.D31 = "X";
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 2)
                            {
                                if (kiemTraNamNhuan(x.Year) == true)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                                if (kiemTraNamNhuan(x.Year) == false)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D29 = "X";
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                            }
                            #endregion
                        }
                    }
                    else if (_CTCT_Sua_ngayBatDau < _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc < _CTCT_Goc_ngayKetThuc)
                    {
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayBatDau, _CTCT_Goc_ngayBatDau.AddMonths(-1)))
                        {
                            #region thêm bảng chấm công
                            if (x.Month == 1 || x.Month == 3 || x.Month == 5 || x.Month == 7 || x.Month == 8 || x.Month == 10 || x.Month == 12)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 4 || x.Month == 6 || x.Month == 9 || x.Month == 11)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                cc1.D31 = "X";
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 2)
                            {
                                if (kiemTraNamNhuan(x.Year) == true)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                                if (kiemTraNamNhuan(x.Year) == false)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D29 = "X";
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                            }
                            #endregion
                        }
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayKetThuc.AddMonths(1), _CTCT_Goc_ngayKetThuc))
                        {
                            ccbll.xoaChamCong(_maPC_CT, x.Month, x.Year);
                        }
                    }
                    else if (_CTCT_Sua_ngayBatDau > _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc > _CTCT_Goc_ngayKetThuc)
                    {
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayBatDau, _CTCT_Sua_ngayBatDau.AddMonths(-1)))
                        {
                            ccbll.xoaChamCong(_maPC_CT, x.Month, x.Year);
                        }
                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayKetThuc.AddMonths(1), _CTCT_Sua_ngayKetThuc))
                        {
                            #region thêm bảng chấm công
                            if (x.Month == 1 || x.Month == 3 || x.Month == 5 || x.Month == 7 || x.Month == 8 || x.Month == 10 || x.Month == 12)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 4 || x.Month == 6 || x.Month == 9 || x.Month == 11)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                cc1.D31 = "X";
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 2)
                            {
                                if (kiemTraNamNhuan(x.Year) == true)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                                if (kiemTraNamNhuan(x.Year) == false)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D29 = "X";
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                            }
                            #endregion
                        }
                    }
                    else if (_CTCT_Sua_ngayBatDau == _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc > _CTCT_Goc_ngayKetThuc)
                    {

                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Goc_ngayKetThuc.AddMonths(1), _CTCT_Sua_ngayKetThuc))
                        {
                            #region thêm bảng chấm công
                            if (x.Month == 1 || x.Month == 3 || x.Month == 5 || x.Month == 7 || x.Month == 8 || x.Month == 10 || x.Month == 12)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 4 || x.Month == 6 || x.Month == 9 || x.Month == 11)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                cc1.D31 = "X";
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 2)
                            {
                                if (kiemTraNamNhuan(x.Year) == true)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                                if (kiemTraNamNhuan(x.Year) == false)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D29 = "X";
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                            }
                            #endregion
                        }
                    }
                    else if (_CTCT_Sua_ngayBatDau < _CTCT_Goc_ngayBatDau && _CTCT_Sua_ngayKetThuc == _CTCT_Goc_ngayKetThuc)
                    {

                        foreach (DateTime x in layDanhSachThangLam(_CTCT_Sua_ngayBatDau, _CTCT_Goc_ngayBatDau.AddMonths(-1)))
                        {
                            #region thêm bảng chấm công
                            if (x.Month == 1 || x.Month == 3 || x.Month == 5 || x.Month == 7 || x.Month == 8 || x.Month == 10 || x.Month == 12)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 4 || x.Month == 6 || x.Month == 9 || x.Month == 11)
                            {
                                ChamCong cc1 = new ChamCong();
                                cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                cc1.maPhanCong = _maPC_CT;
                                cc1.thang = x.Month;
                                cc1.nam = x.Year;
                                cc1.soNgayLam = 0;
                                cc1.soNgayNghi = 0;
                                cc1.luongThang = 0;
                                cc1.D31 = "X";
                                ccbll.themChamCong(cc1);
                            }
                            else if (x.Month == 2)
                            {
                                if (kiemTraNamNhuan(x.Year) == true)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                                if (kiemTraNamNhuan(x.Year) == false)
                                {
                                    ChamCong cc1 = new ChamCong();
                                    cc1.maChamCong = ccbll.layMaChamCongCaoNhat() + 1;
                                    cc1.maPhanCong = _maPC_CT;
                                    cc1.thang = x.Month;
                                    cc1.nam = x.Year;
                                    cc1.soNgayLam = 0;
                                    cc1.soNgayNghi = 0;
                                    cc1.luongThang = 0;
                                    cc1.D29 = "X";
                                    cc1.D30 = "X";
                                    cc1.D31 = "X";
                                    ccbll.themChamCong(cc1);
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion

                }

              //  #endregion








            }

        }

        private void btnCTXoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn xoá bản phân công này không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {

                //Xoá bảng phân công
                PhanCong pc1 = new PhanCong();
                pc1.maPhanCong = _maPC_CT;
                pc1.trangThai = "X";
             
                if(pcbll.suaPhanCong(pc1, _maPC_CT))
                {
                    XtraMessageBox.Show("Xoá phân công thành công !");
                    loadCongTrinhDangLam(_maNhanVien);
                }

            }

        }

        
    }
}