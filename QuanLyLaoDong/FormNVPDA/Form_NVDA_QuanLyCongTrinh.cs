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
using BLL;
using DAL;
using System.Text.RegularExpressions;

namespace QuanLyLaoDong.FormNVPDA
{
    public partial class Form_NVDA_QuanLyCongTrinh : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db = new QLLD_DBDataContext();
        CongTrinhBLL ctbll;
        PhongBanBLL pbbll;
        PhanCongBLL pcbll;
        ChuoiKetNoi ckn;
      //  List<CongTrinh> listct;
        public static int key = 0;
        public static int _huy = 0;
        public static string _maCongTrinh;
        public static string _trangThai;
        public string _maTuTang;
        public string _maCT_DangChon;

        public string _trangThaiCongTrinh;
        // public static 

        public Form_NVDA_QuanLyCongTrinh()
        {
            InitializeComponent();
            ctbll = new CongTrinhBLL();
            pbbll = new PhongBanBLL();
            pcbll = new PhanCongBLL();
            ckn = new ChuoiKetNoi();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "###,##";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";

            cbbTK_NV.Text = "Theo Tên CT";
            _trangThaiCongTrinh = "TC";
        }

        private void loadMaCT()
        {
            #region Lấy mã CT bằng Connection String 
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = @ckn.chuoiKN();
            myCon.Open();//không có dòng này thì adapter sẽ tự open

            string sqlMaPB = @"select top(1) *
                               from dbo.CongTrinh
                               order by maCongTrinh desc";
            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlMaPB, myCon);
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            _maTuTang = myTable.Rows[0]["maCongTrinh"].ToString().Trim();
            #endregion
        }

        private string NextID(string maTuTang, string prefixID)
        {
            if (maTuTang == "")
            {
                return prefixID + "0001";  // fixwidth default
            }
            int nextID = int.Parse(maTuTang.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = maTuTang.Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;

        }

        #region Load Data lên Dtgv
        private void loadDataThiCong()
        {
            //string maPhongBan = FormDangNhap._MaPB;
            //listct = ctbll.layDanhSachCongTrinhDangXayDung(maPhongBan);
            //listct = ctbll.layDanhSachCongTrinhDangXayDung();
           // dataGridView1.DataSource = listct;
           dataGridView1.DataSource = (from a in db.CongTrinhs
                                        where a.trangThai == "DXD"
                                        select new {
                                            a.maCongTrinh,
                                            a.tenCongTrinh,
                                            a.diaDiemXayDung,
                                            a.luongCongTrinh,
                                            a.ngayCapPhep,
                                            a.ngayKhoiCong,
                                            a.ngayHoanThanh
                                                 });
        }

        private void loadDataHoanThanh()
        {
           // listct = ctbll.layDanhSachCongTrinhDaHoanThanh();
            //dataGridView1.DataSource = listct;
            dataGridView1.DataSource = from a in db.CongTrinhs
                                       where a.trangThai == "HT"
                                       select new
                                       {
                                           a.maCongTrinh,
                                           a.tenCongTrinh,
                                           a.diaDiemXayDung,
                                           a.luongCongTrinh,
                                           a.ngayCapPhep,
                                           a.ngayKhoiCong,
                                           a.ngayHoanThanh,
                                       };
        }
        #endregion

        private void loadCell()
        {
            tbMaCongTrinh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            tbTenCongTrinh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            tbDiaDiemXayDung.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbLuongCT.Text = String.Format(dataGridView1.CurrentRow.Cells[3].Value.ToString(), "###,##");
            dtpNgayCapPhep.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtpNgayKhoiCong.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtpNgayHoanThanh.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        #region Xử lí trạng thái button
        private void voHieuTB()
        {
            panelQuanLy.Enabled = false;
        }
        private void kichHoatTB()
        {
            panelQuanLy.Enabled = true;
        }

        private void xoaAllTB()
        {
            tbMaCongTrinh.Text = null;
            tbTenCongTrinh.Text = null;
            tbDiaDiemXayDung.Text = null;
            dtpNgayCapPhep.Text = null;
            dtpNgayKhoiCong.Text = null;
            dtpNgayHoanThanh.Text = null;
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadCell();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            _maCT_DangChon = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick( sender,  e);
        }


        private void btnXemThiCong_Click(object sender, EventArgs e)
        {
            _trangThaiCongTrinh = "TC";
            loadDataThiCong();
            btnXemThiCong.Enabled = false;
            btnXemHoanThanh.Enabled = true;
            btnThem.Enabled = true;
            btnHoanThanh.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;


        }

        private void btnXemHoanThanh_Click(object sender, EventArgs e)
        {
            _trangThaiCongTrinh = "HT";
            loadDataHoanThanh();
            btnXemThiCong.Enabled = true;
            btnXemHoanThanh.Enabled = false;
            btnHoanThanh.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;
            btnSua.Enabled = false;
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            key = 1;
            _huy = 1;
            btnThem.Enabled = false;
            dataGridView1.Enabled = false;
            xoaAllTB();
            kichHoatTB();
            tbMaCongTrinh.Enabled = false;

            loadMaCT();
            tbMaCongTrinh.Text = NextID(_maTuTang, "CT");
            tbTenCongTrinh.Focus();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnHoanThanh.Enabled = false;
            dtpNgayKhoiCong.Enabled = false;
            dtpNgayHoanThanh.Enabled = false;
           // pannelThongTin.Enabled = false;
            tbMaCongTrinh.Focus();
        }

        private void Form_NVDA_QuanLyCongTrinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_NVDA_QLCT = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn xoá công trình không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                // var nv = db.NhanViens.Single(a => a.maNhanVien == tbMaNV.Text);
                // var tk = db.TaiKhoans.Single(a => a.maNhanVien == tbMaNV.Text);
                // db.NhanViens.DeleteOnSubmit(nv);
                // db.TaiKhoans.DeleteOnSubmit(tk);
                // db.SubmitChanges();
                try
                {
                    _maCongTrinh = tbMaCongTrinh.Text;
                    _trangThai = ctbll.layTrangThai(_maCongTrinh);
                    if (ctbll.xoaCongTrinh(_maCongTrinh))
                    {
                        XtraMessageBox.Show("Xoá thành công !");
                        if (_trangThai.CompareTo("DXD")==0)
                        {
                            xoaAllTB();
                            loadDataThiCong();
                            btnSua.Enabled = false;
                            btnXoa.Enabled = false;
                        }
                        else
                        {
                            xoaAllTB();
                            loadDataHoanThanh();
                            btnXoa.Enabled = false;
                            btnSua.Enabled = false;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Bị trùng mã nhân viên, vui lòng nhập mã khác !");
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
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (key == 1)
            {
                #region Lưu nút thêm.

                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn thêm công trình không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (tbMaCongTrinh.Text == "" || tbTenCongTrinh.Text == "" || tbDiaDiemXayDung.Text == "")
                        {
                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                        }
                        else
                        {
                            //Chuỗi regex để kiểm tra
                            string reMa = @"^[CT]+[0-9]{4}$";
                            Regex rgMa = new Regex(reMa);

                            string reLuong = @"^[0-9]{1,10}$";
                            Regex rgLuong = new Regex(reLuong);

                            if (!rgMa.IsMatch(tbMaCongTrinh.Text))
                            {
                                XtraMessageBox.Show("Mã công trình phải có kí tự CT ở đầu và gồm 7 kí tự , vui lòng nhập lại !");
                            }
                            else if (Convert.ToDecimal(tbLuongCT.Text)<0 || !rgLuong.IsMatch(tbLuongCT.Text))
                            {
                                XtraMessageBox.Show("Lương công trình phải lớn hơn 0 và phải là số , vui lòng nhập lại !");
                            }
                            else if (ctbll.kiemTraTenCongTrinhTonTai(tbTenCongTrinh.Text)!=0)
                            {
                                XtraMessageBox.Show("Tên công trình bị trùng , vui lòng nhập lại !");
                            }
                            else
                            {
                                //Thêm bảng công trinh
                                CongTrinh ct1 = new CongTrinh();
                                ct1.maCongTrinh = tbMaCongTrinh.Text.Trim();
                                ct1.tenCongTrinh = tbTenCongTrinh.Text.Trim();
                                ct1.diaDiemXayDung = tbDiaDiemXayDung.Text.Trim();
                                ct1.luongCongTrinh = Convert.ToDecimal(tbLuongCT.Text);
                                ct1.ngayCapPhep = dtpNgayCapPhep.Value;
                                ct1.ngayKhoiCong = dtpNgayKhoiCong.Value;
                                ct1.ngayHoanThanh = dtpNgayHoanThanh.Value;
                                ct1.trangThai = "DXD";

                                if (ctbll.themCongTrinh(ct1))
                                {
                                    btnXemHoanThanh.Enabled = true;
                                    XtraMessageBox.Show("Thêm thành công !");
                                    key = 0;
                                    #region Chỉnh trạng thái control sau khi thêm thành công
                                    dataGridView1.Enabled = true;
                                    voHieuTB();
                                    xoaAllTB();
                                    
                                    loadDataThiCong();
                                    btnLuu.Enabled = false;
                                    btnHuy.Enabled = false;
                                    btnThem.Enabled = true;
                                   
                                    #endregion
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bị trùng mã công trình, vui lòng nhập mã khác !");

                                    
                                }

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
            else if (key == 2)
            {
                #region Lưu nút sửa.

                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn thay đổi thông tin công trình này không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (tbMaCongTrinh.Text == "" || tbTenCongTrinh.Text == "" || tbDiaDiemXayDung.Text == "")
                        {
                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                        }
                        else
                        {
                            //Chuỗi regex để kiểm tra
                            string reMa = @"^[CT]+[0-9]{4}$";
                            Regex rgMa = new Regex(reMa);
                            string reLuong = @"^[0-9]{1,10}$";
                            Regex rgLuong = new Regex(reLuong);


                            if (!rgMa.IsMatch(tbMaCongTrinh.Text))
                            {
                                XtraMessageBox.Show("Mã nhân viên phải có kí tự CT ở đầu và gồm 7 kí tự , vui lòng nhập lại !");
                            }
                            else if (Convert.ToDecimal(tbLuongCT.Text) < 0 || !rgLuong.IsMatch(tbLuongCT.Text))
                            {
                                XtraMessageBox.Show("Lương công trình phải lớn hơn 0 và phải là số , vui lòng nhập lại !");
                            }
                            else
                            {

                                _maCongTrinh = tbMaCongTrinh.Text;
                                _trangThai = ctbll.layTrangThai(tbMaCongTrinh.Text.Trim());
                                ////thêm bảng công trinh
                                CongTrinh ct1 = new CongTrinh();
                                ct1.maCongTrinh = tbMaCongTrinh.Text.Trim();
                                ct1.tenCongTrinh = tbTenCongTrinh.Text.Trim();
                                ct1.diaDiemXayDung = tbDiaDiemXayDung.Text.Trim();
                                ct1.luongCongTrinh = Convert.ToDecimal(tbLuongCT.Text);
                                ct1.ngayCapPhep = dtpNgayCapPhep.Value;
                                ct1.ngayKhoiCong = dtpNgayKhoiCong.Value;
                                ct1.ngayHoanThanh = dtpNgayHoanThanh.Value;
                                ct1.trangThai = "DXD";

                                if (ctbll.suaCongTrinh(ct1,_maCongTrinh))
                                {
                                    XtraMessageBox.Show("Lưu thành công !");
                                    key = 0;

                                    #region Chỉnh trạng thái control sau khi sửa thành công
                                    if (_trangThai.CompareTo("DXD")==0)
                                    {
                                        
                                        voHieuTB();
                                        xoaAllTB();
                                        loadDataThiCong();
                                        btnLuu.Enabled = false;
                                        btnHuy.Enabled = false;
                                        btnThem.Enabled = true;
                                        btnXemThiCong.Enabled = false;                                        
                                        dataGridView1.Enabled = true;
                                        btnXemHoanThanh.Enabled = true;
                                    }
                                    else
                                    {
                                        
                                        voHieuTB();
                                        xoaAllTB();
                                        loadDataHoanThanh();
                                        btnLuu.Enabled = false;
                                        btnHuy.Enabled = false;
                                        btnThem.Enabled = false;
                                        btnXemThiCong.Enabled = true;
                                        btnXemHoanThanh.Enabled = false;
                                        dataGridView1.Enabled = true;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bị trùng mã công trình, vui lòng nhập mã khác !");                                  
                                }

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
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            key = 0;
            _maCongTrinh = tbMaCongTrinh.Text;
            _trangThai = ctbll.layTrangThai(_maCongTrinh);

            if (_huy == 1)
            {
                btnThem.Enabled = true;
                dataGridView1.Enabled = true;
                xoaAllTB();
                voHieuTB();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXemHoanThanh.Enabled = true;
                loadDataThiCong();

                pannelThongTin.Enabled = true;
            }
            else if (_trangThai.CompareTo("HT") == 0)
            {
                btnThem.Enabled = true;
                dataGridView1.Enabled = true;
                xoaAllTB();
                voHieuTB();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXemHoanThanh.Enabled = false;
                btnXemThiCong.Enabled = true;
                loadDataThiCong();

                //pannelThongTin.Enabled = true;
            }
            else if((_trangThai.CompareTo("DXD") == 0))
            {
                btnThem.Enabled = true;
                dataGridView1.Enabled = true;
                xoaAllTB();
                voHieuTB();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXemHoanThanh.Enabled = true;
                btnXemThiCong.Enabled = false;
                loadDataHoanThanh();

                //pannelThongTin.Enabled = true;
            }
            

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {


            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn đưa công trình này vào danh sách !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    if (pcbll.kiemTraCacPhanCongDuocTraLuong(_maCT_DangChon) != 0)
                    {
                        //textBox1.Text = pcbll.kiemTraCacPhanCongDuocTraLuong(_maCT_DangChon).ToString();
                        XtraMessageBox.Show("Lương chưa được thanh toán cho tất cả nhân viên, vui lòng thanh toán trước khi hoàn thành công trình");
                    }
                    else
                    {
                        _maCongTrinh = tbMaCongTrinh.Text;
                        CongTrinh ct1 = new CongTrinh();
                        //ct1 = db.CongTrinhs.Where(a => a.maCongTrinh == tbMaCongTrinh.Text).SingleOrDefault();                    
                        ct1.maCongTrinh = tbMaCongTrinh.Text;
                        ct1.tenCongTrinh = tbTenCongTrinh.Text;
                        ct1.diaDiemXayDung = tbDiaDiemXayDung.Text;
                        ct1.ngayCapPhep = dtpNgayCapPhep.Value;
                        ct1.ngayKhoiCong = dtpNgayKhoiCong.Value;
                        ct1.ngayHoanThanh = dtpNgayHoanThanh.Value;
                        ct1.trangThai = "HT";
                        // db.SubmitChanges();
                        if (ctbll.hoanThanhCongTrinh(ct1, _maCongTrinh))
                        {
                            XtraMessageBox.Show("Công trình đã được thêm vào danh sách hoàn thành !");
                        }
                        loadDataThiCong();
                        voHieuTB();
                        xoaAllTB();
                        btnThem.Enabled = true;
                        dataGridView1.Enabled = true;
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
        }

        private void Form_NVDA_QuanLyCongTrinh_Load(object sender, EventArgs e)
        {
            loadDataThiCong();
            btnXemThiCong.Enabled = false;
            btnHoanThanh.Enabled = true;
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            key = 2;
            kichHoatTB();
            btnSua.Enabled = false;
            btnHoanThanh.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnXemHoanThanh.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            dataGridView1.Enabled = false;
            tbMaCongTrinh.Enabled = false;
            tbTenCongTrinh.Enabled = false;

        }

        private void dtpNgayCapPhep_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayKhoiCong.Enabled = true;
        }

        private void dtpNgayKhoiCong_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan ts;
            DateTime ngayCapPhep = new DateTime();   //YYYY-MM-DD                                                             // DateTime dateTime_NgayKetThuc = new DateTime();
            ngayCapPhep = dtpNgayCapPhep.Value;

            DateTime ngayKhoiCong = new DateTime();   //YYYY-MM-DD                                                             // DateTime dateTime_NgayKetThuc = new DateTime();
            ngayKhoiCong = dtpNgayKhoiCong.Value;
           
            ts = ngayKhoiCong-ngayCapPhep;
            int tongNgay = Convert.ToInt32(ts.TotalDays);
           // textBox1.Text = tongNgay.ToString();
            if (tongNgay<0)
            {
                XtraMessageBox.Show("Ngày khởi công không được nhỏ hơn ngày cấp phép !");
                dtpNgayKhoiCong.ResetText();
            }
            else
            {
                dtpNgayHoanThanh.Enabled = true;
            }
        }

        private void dtpNgayHoanThanh_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan ts;
            DateTime ngayHoanThanh = new DateTime();   //YYYY-MM-DD                                                             // DateTime dateTime_NgayKetThuc = new DateTime();
            ngayHoanThanh = dtpNgayHoanThanh.Value;

            DateTime ngayKhoiCong = new DateTime();   //YYYY-MM-DD                                                             // DateTime dateTime_NgayKetThuc = new DateTime();
            ngayKhoiCong = dtpNgayKhoiCong.Value;

            ts = ngayHoanThanh-ngayKhoiCong;
            int tongNgay = Convert.ToInt32(ts.TotalDays);
            if (tongNgay < 0)
            {
                XtraMessageBox.Show("Ngày hoàn thành không được nhỏ hơn ngày khởi công !");
                dtpNgayHoanThanh.ResetText();
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            if(_trangThaiCongTrinh == "TC")
            {
                if(cbbTK_NV.Text=="Theo Tên CT")
                {
                    #region Tìm kiếm CT theo tên CT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_QLCT_TheoTen(tbTimKiemCT.Text,"DXD");
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
                else if(cbbTK_NV.Text == "Theo Mã CT")
                {
                    #region Tìm kiếm CT theo mã CT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_QLCT_TheoMa(tbTimKiemCT.Text,"DXD");
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
                else if (cbbTK_NV.Text == "Theo Địa Điểm")
                {
                    #region Tìm kiếm CT theo dia diẻm CT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_QLCT_TheoDiaDiem(tbTimKiemCT.Text, "DXD");
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
            }
            if(_trangThaiCongTrinh == "HT")
            {
                if (cbbTK_NV.Text == "Theo Tên CT")
                {
                    #region Tìm kiếm CT theo tên CT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_QLCT_TheoTen(tbTimKiemCT.Text, "HT");
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
                else if (cbbTK_NV.Text == "Theo Mã CT")
                {
                    #region Tìm kiếm CT theo mã CT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_QLCT_TheoMa(tbTimKiemCT.Text, "HT");
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
                else if (cbbTK_NV.Text == "Theo Địa Điểm")
                {
                    #region Tìm kiếm CT theo dia diẻm CT
                    SqlConnection myCon = new SqlConnection();
                    myCon.ConnectionString = ckn.chuoiKN();
                    myCon.Open();//không có dòng này thì adapter sẽ tự open

                    string sqlTimKiem = ctbll.timKiemCT_QLCT_TheoDiaDiem(tbTimKiemCT.Text, "HT");
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                    myCon.Close();
                    #endregion
                }
            }
        }
    }
}