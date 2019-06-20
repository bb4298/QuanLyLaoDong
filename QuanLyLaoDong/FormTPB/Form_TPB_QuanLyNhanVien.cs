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
using System.Security.Cryptography;

namespace QuanLyLaoDong.FormTPB
{
    public partial class Form_TPB_QuanLyNhanVien : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db;
        //List<NhanVien> listnv;
        PhongBanBLL pbbll;
        NhanVienBLL nvbll;
        TaiKhoanBLL tkbll;
        PhanCongBLL pcbll;
        ChuoiKetNoi ckn;

        // public static string hi;
        public static int key = 0;
        public static string _maPhongBan;
        public static string _tenPhongBan;
        public static string _maNhanVien;
        public string _maTuTang;
        public string _trangThaiTimKiem;
     
        public Form_TPB_QuanLyNhanVien()
        {
            InitializeComponent();
            pbbll = new PhongBanBLL();
            nvbll = new NhanVienBLL();
            tkbll = new TaiKhoanBLL();
            pcbll = new PhanCongBLL();
            db = new QLLD_DBDataContext();
            ckn = new ChuoiKetNoi();
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            cbbTK_NV.Text = "Theo Tên NV";
            _trangThaiTimKiem = "L";
        }

        #region Load Data
        private void loadNhanVienDangLam()
        {

            
            //listnv = nvbll.layDanhSachNhanVien(_maPhongBan, FormDangNhap._tenDN);
            // dataGridView1.DataSource = listnv;
            
            dataGridView1.DataSource = from u in db.TaiKhoans
                                       join a in db.NhanViens on u.maNhanVien equals a.maNhanVien
                                       join e in db.PhongBans on a.maPhongBan equals e.maPhongBan
                                       where e.maPhongBan.CompareTo(FormDangNhap._MaPB) == 0 && u.tenTaiKhoan.CompareTo(FormDangNhap._tenDN) != 0 && a.trangThai.CompareTo("L")==0
                                       select new
                                       {
                                           a.maNhanVien,
                                           a.hoTen,
                                           a.ngaySinh,
                                           a.gioiTinh,
                                           a.diaChiLienHe,
                                           a.soDienThoai
                                       };



            btnLuu.Enabled = false;
            panel1.Hide();


        }

        private void loadNhanVienDaNghi()
        {    
            
            dataGridView1.DataSource = from u in db.TaiKhoans
                                       join a in db.NhanViens on u.maNhanVien equals a.maNhanVien
                                       join e in db.PhongBans on a.maPhongBan equals e.maPhongBan
                                       where e.maPhongBan.CompareTo(FormDangNhap._MaPB) == 0 && u.tenTaiKhoan.CompareTo(FormDangNhap._tenDN) != 0 && a.trangThai.CompareTo("N") == 0
                                       select new
                                       {
                                           a.maNhanVien,
                                           a.hoTen,
                                           a.ngaySinh,
                                           a.gioiTinh,
                                           a.diaChiLienHe,
                                           a.soDienThoai
                                       };

            
            

            btnLuu.Enabled = false;
            panel1.Hide();


        }

        private void loadMaNV()
        {
            #region Lấy mã NV bằng Connection String 
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = ckn.chuoiKN();
            myCon.Open();//không có dòng này thì adapter sẽ tự open

            string sqlMaPB = @"select top(1) *
                               from dbo.NhanVien
                               order by maNhanVien desc";


            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlMaPB, myCon);
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            _maTuTang = myTable.Rows[0]["maNhanVien"].ToString().Trim();
            #endregion
        }

        // Hàm tăng mã nhân viên khi add thêm NV
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

        #endregion
        private void Form_TPB_ThongTinNV_Load(object sender, EventArgs e)
        {
            _maPhongBan = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK).ToString();
            _tenPhongBan = pbbll.layTenPhongBan(FormDangNhap._tenDN, FormDangNhap._MK).ToString();

            
            tbMaPhongBan.Text = _maPhongBan;
            tbTenPB.Text = _tenPhongBan;

            btnDSNhanVienLam.Enabled = false;
            loadNhanVienDangLam();
            //dataGridView1.RowHeadersVisible = false;
           // dataGridView1.AllowUserToResizeRows = false;
        }


        #region Xử lí trạng thái button
        private void voHieuTB()
        {
            tbMaNV.Enabled = false;
            tbTenNV.Enabled = false;
            dateTimePicker1.Enabled = false;
           // cbbLoaiNV.Enabled = false;
            cbbGioiTinh.Enabled = false;
            tbDiaChi.Enabled = false;
            tbSDT.Enabled = false;
        }
        private void kichHoatTB()
        {
           
            tbMaNV.Enabled = true;
            tbTenNV.Enabled = true;
            dateTimePicker1.Enabled = true;
          //  cbbLoaiNV.Enabled = true;
            tbDiaChi.Enabled = true;
            cbbGioiTinh.Enabled = true;
            tbSDT.Enabled = true;
        }

        private void xoaAllTB()
        {
            tbSDT.Text = null;
            tbMaNV.Text = null;
            tbTenNV.Text = null;
            dateTimePicker1.Text = null;
            cbbGioiTinh.Text = null;
            tbDiaChi.Text = null;

           // cbbLoaiNV.Text = null;
        }
        #endregion
        
        #region Load Dtgr Lên textbox 
        private void loadCell()
        {   
                tbMaNV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                tbTenNV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cbbGioiTinh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbDiaChi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
                tbSDT.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                //tbMaPhongBan.Text = _maPhongBan;
                //tbTenPB.Text = _tenPhongBan;
                voHieuTB();
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnNghiViec.Enabled = true;
                panel1.Hide();

        }
    
        #endregion

        #region Mã hoá mật khẩu
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
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion

        #region Thêm 
        private void btnThem_Click(object sender, EventArgs e)
        {

            key = 1;

            tbMaPhongBan.Text = _maPhongBan;
            tbTenPB.Text = _tenPhongBan;

            panel1.Show();
            xoaAllTB();

            kichHoatTB();

            loadMaNV();
            tbMaNV.Text = NextID(_maTuTang, "NV").ToString();

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            tbTenNV.Focus();

            dataGridView1.Enabled = false;

            tbMaNV.Enabled = false;
        }
        #endregion

        #region Button lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (key == 1)
            {
                #region Lưu nút thêm.

                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn thêm nhân viên không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        // Kiểm tra dữ liệu
                        if (tbMaNV.Text == "" || tbTenNV.Text == ""  || cbbGioiTinh.Text == "")
                        {
                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                        }
                        else if (tbMK.Text.CompareTo(tbMK2.Text) != 0)
                        {
                            XtraMessageBox.Show("Xác nhận mật khẩu không trùng khớp, vui lòng nhập lại !");
                        }
                        else
                        {
                            #region Chuỗi regex để kiểm tra
                            string reMa = @"^[NV]+[0-9]{4}$";
                            Regex rgMa = new Regex(reMa);

                            string reTen = @"^[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴ]+[a-zĐaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+(\s+[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴĐ]+[a-zaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+)+$";
                            Regex rgTen = new Regex(reTen);

                            string reGT = @"^[TPB]+[0-9]{4}$";
                            Regex rgGT = new Regex(reGT);

                            string reTK = @"^[A-Za-z0-9_\.]{6,32}$";
                            Regex rgTK = new Regex(reTK);

                            string reMK = @"^([A-Z]){1}([\w_\.!@#$%^&*()]+){5,31}$";
                            Regex rgMK = new Regex(reMK);

                            string reSDT = @"^[0-9]{10,11}$";
                            Regex rgSDT = new Regex(reSDT);
                            #endregion

                            DateTime now = DateTime.Now;
                            TimeSpan ts = now - dateTimePicker1.Value;
                            int ngayTuoi = Convert.ToInt32(ts.TotalDays);
                            int namTuoi = ngayTuoi / 365;

                            if (!rgMa.IsMatch(tbMaNV.Text))
                            {
                                XtraMessageBox.Show("Mã nhân viên phải có kí tự NV ở đầu và gồm 7 kí tự , vui lòng nhập lại !");
                            }
                            else if (!rgTen.IsMatch(tbTenNV.Text))
                            {
                                XtraMessageBox.Show("Tên nhân viên viết hoa chữ đầu không bao gồm số, ít nhất 2 chữ , vui lòng nhập lại !");
                            }
                            else if (!rgTK.IsMatch(tbTenTK.Text))
                            {
                                XtraMessageBox.Show("Nhập sai thông tin ! \n Tên tài khoản chứa các ký tự chữ cái hoa, thường, chữ số, dấu . và dấu gạch dưới, độ dài 6 đến 32 ký tự");
                            }
                            else if (!rgMK.IsMatch(tbMK.Text))
                            {
                                XtraMessageBox.Show("Nhập sai thông tin ! \n Mật khẩu bao gồm ký tự chữ cái, chử số, ký tự đặc biệt, dấu chấm bắt đầu với ký tự in hoa, độ dài từ 6 đến 32 ký tự \n Vui lòng nhập lại !");
                            }
                            else if (!rgSDT.IsMatch(tbSDT.Text))
                            {
                                XtraMessageBox.Show("Số điện thoại gồm 10 hoặc 11 chữ số, không có kí tự , vui lòng nhập lại !");
                            }
                            else if (namTuoi<18)
                            {
                                XtraMessageBox.Show("Nhân viên này chưa đủ 18 tuổi !");
                            }
                            else if (tkbll.kiemTraTaiKhoanTonTai(tbTenTK.Text) != 0)
                            {
                                XtraMessageBox.Show("Tên tài khoản đã tồn tại, vui lòng đặt tên khác !");
                            }
                            else
                            {


                                string mk = tbMK.Text;
                                string mkMaHoa = maHoaMK(mk);

                                #region Thêm NV
                                //Thêm bảng NV
                                NhanVien nv1 = new NhanVien();
                                nv1.maNhanVien = tbMaNV.Text;
                                nv1.hoTen = tbTenNV.Text;
                                nv1.ngaySinh = dateTimePicker1.Value;
                                nv1.gioiTinh = cbbGioiTinh.Text;
                                nv1.diaChiLienHe = tbDiaChi.Text;
                                // nv1.loaiNhanVien = cbbLoaiNV.Text;
                                nv1.loaiNhanVien ="NV";
                                nv1.trangThai = "L";
                                nv1.maPhongBan = tbMaPhongBan.Text;
                                nv1.soDienThoai = tbSDT.Text;

                                //Thêm bảng Tài Khoản
                                TaiKhoan tk1 = new TaiKhoan();
                                tk1.maNhanVien = tbMaNV.Text;
                                tk1.matKhau = tbMK.Text;
                                tk1.tenTaiKhoan = tbTenTK.Text;


                                if (nvbll.themNhanVien(nv1) && tkbll.themTaiKhoan(tk1))
                                {
                                    XtraMessageBox.Show("Thêm thành công !");

                                    #region Chỉnh trạng thái control sau khi thêm thành công
                                    btnThem.Enabled = true;
                                    btnHuy.Enabled = false;
                                    loadNhanVienDangLam();
                                    voHieuTB();
                                    xoaAllTB();
                                    btnThem.Enabled = true;
                                    tbTenTK.Text = null;
                                    tbMK.Text = null;
                                    tbMK2.Text = null;
                                    dataGridView1.Enabled = true;
                                    #endregion
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bị trùng mã nhân viên, vui lòng nhập mã khác !");
                                }
                                #endregion
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
                #region Lưu nút sửa
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn sửa thông tin nhân vien này không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        string reSDT = @"^[0-9]{10,11}$";
                        Regex rgSDT = new Regex(reSDT);
                        #endregion

                        DateTime now = DateTime.Now;
                        TimeSpan ts = now - dateTimePicker1.Value;
                        int ngayTuoi = Convert.ToInt32(ts.TotalDays);
                        int namTuoi = ngayTuoi / 365;

                        if (tbMaNV.Text == "" || tbTenNV.Text == "" || cbbGioiTinh.Text == "" || tbDiaChi.Text == "")
                        {
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                          
                        }
                        else if (!rgSDT.IsMatch(tbSDT.Text))
                        {
                            XtraMessageBox.Show("Số điện thoại gồm 10 hoặc 11 chữ số, không có kí tự , vui lòng nhập lại !");
                         
                        }
                        else if (namTuoi < 18)
                        {
                            XtraMessageBox.Show("Nhân viên này chưa đủ 18 tuổi !");
                         
                        }
                        else
                        {
                            _maNhanVien = tbMaNV.Text.Trim();
                            NhanVien nv1 = new NhanVien();
                            // nv1 = db.NhanViens.Where(a => a.maNhanVien == tbMaNV.Text).SingleOrDefault();
                            nv1.maNhanVien = tbMaNV.Text;
                            nv1.hoTen = tbTenNV.Text;
                            nv1.ngaySinh = dateTimePicker1.Value;
                            //nv1.loaiNhanVien = cbbLoaiNV.Text;
                            nv1.loaiNhanVien = "NV";
                           // nv1.trangThai = "L";
                            nv1.gioiTinh = cbbGioiTinh.Text;
                            nv1.diaChiLienHe = tbDiaChi.Text;
                            nv1.soDienThoai = tbSDT.Text;
                            // db.SubmitChanges();
                            if (nvbll.suaNhanVien2(nv1, _maNhanVien))
                            {
                                XtraMessageBox.Show("Sửa thành công !");
                                voHieuTB();
                                xoaAllTB();
                                btnThem.Enabled = true;
                                loadNhanVienDangLam();

                            }
                            else
                            {
                                XtraMessageBox.Show("Bị trùng mã nhân viên, vui lòng nhập mã khác !");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi: " + ex);
                    }
                    btnSua.Enabled = false;
                    btnNghiViec.Enabled = false;
                   // btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                }

                #endregion
            }
        }
     

        #region Btn Huỷ
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xoaAllTB();
            voHieuTB();
            panel1.Hide();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnNghiViec.Enabled = false;
            dataGridView1.Enabled = true;
        }
        #endregion

        #region Btn Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            key = 2;

            kichHoatTB();

            tbMaNV.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            cbbGioiTinh.Enabled = false;
            btnNghiViec.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            cbbGioiTinh.Enabled = true;

            tbTenNV.Enabled = false;




        }
        #endregion

        #region Btn nghỉ việc
        private void btnNghiViec_Click(object sender, EventArgs e)
        {
            if (btnNghiViec.Text == "Nghỉ việc")
            {
                #region Cho nghỉ việc
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn cho nhân viên này nghỉ việc không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (tbMaNV.Text == "" || tbTenNV.Text == "" || cbbGioiTinh.Text == "" || tbDiaChi.Text == "")
                        {

                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                        }
                        else
                        {
                            _maNhanVien = tbMaNV.Text.Trim();
                            NhanVien nv1 = new NhanVien();
                            // nv1 = db.NhanViens.Where(a => a.maNhanVien == tbMaNV.Text).SingleOrDefault();
                            nv1.maNhanVien = tbMaNV.Text;
                            nv1.hoTen = tbTenNV.Text;
                            nv1.ngaySinh = dateTimePicker1.Value;
                            //nv1.loaiNhanVien = cbbLoaiNV.Text;
                            nv1.loaiNhanVien = "NV";
                            nv1.trangThai = "N";
                            nv1.gioiTinh = cbbGioiTinh.Text;
                            nv1.diaChiLienHe = tbDiaChi.Text;

                            // db.SubmitChanges();
                            if (nvbll.nghiViecVaLamLai(nv1, _maNhanVien))
                            {
                                XtraMessageBox.Show("Đã cho nhân viên nghỉ việc !");
                                voHieuTB();
                                xoaAllTB();
                                btnThem.Enabled = true;
                                loadNhanVienDangLam();

                            }
                            else
                            {
                                XtraMessageBox.Show("Bị trùng mã nhân viên, vui lòng nhập mã khác !");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi: " + ex);
                    }
                    btnSua.Enabled = false;
                    btnNghiViec.Enabled = false;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                }

                #endregion
            }
            if (btnNghiViec.Text == "Làm lại")
            {
                #region Cho làm lại
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn cho nhân viên này đi làm lại không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (tbMaNV.Text == "" || tbTenNV.Text == "" || cbbGioiTinh.Text == "" || tbDiaChi.Text == "")
                        {

                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                        }
                        else
                        {
                            _maNhanVien = tbMaNV.Text.Trim();
                            NhanVien nv1 = new NhanVien();
                            // nv1 = db.NhanViens.Where(a => a.maNhanVien == tbMaNV.Text).SingleOrDefault();
                            nv1.maNhanVien = tbMaNV.Text;
                            nv1.hoTen = tbTenNV.Text;
                            nv1.ngaySinh = dateTimePicker1.Value;
                            //nv1.loaiNhanVien = cbbLoaiNV.Text;
                            nv1.loaiNhanVien = "NV";
                            nv1.trangThai = "L";
                            nv1.gioiTinh = cbbGioiTinh.Text;
                            nv1.diaChiLienHe = tbDiaChi.Text;

                            // db.SubmitChanges();
                            if (nvbll.nghiViecVaLamLai(nv1, _maNhanVien))
                            {
                                XtraMessageBox.Show("Đã cho nhân viên đi làm lại !");
                                voHieuTB();
                                xoaAllTB();
                                btnThem.Enabled = true;
                                loadNhanVienDaNghi();

                            }
                            else
                            {
                                XtraMessageBox.Show("Bị trùng mã nhân viên, vui lòng nhập mã khác !");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi: " + ex);
                    }
                    btnSua.Enabled = false;
                    btnNghiViec.Enabled = false;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                }

                #endregion
            }
        }
        #endregion


        private void Form_TPB_QuanLyNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_TPB_QLNV = true;
        }      
      
      

        private void btnDSNhanVienNghi_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;
            _trangThaiTimKiem = "N";
            loadNhanVienDaNghi();
            btnDSNhanVienLam.Enabled = true;
            btnDSNhanVienNghi.Enabled = false;
            btnNghiViec.Text = "Làm lại";
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            // dataGridViewNVLam.Enabled = false;
            voHieuTB();
            xoaAllTB();
            btnNghiViec.Enabled = false;
        }

        private void btnDSNhanVienLam_Click(object sender, EventArgs e)
        {
            _trangThaiTimKiem = "L";
            btnThem.Enabled = true;
            loadNhanVienDangLam();
            btnDSNhanVienLam.Enabled = false;
            btnDSNhanVienNghi.Enabled = true;
            btnNghiViec.Text = "Nghỉ việc";
            voHieuTB();
            xoaAllTB();
            btnHuy.Enabled = false;
            btnNghiViec.Enabled = false;
        }

        private void tbTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            if(_trangThaiTimKiem == "L")
            {
                if(tbTimKiemNV.Text == null)
                {
                    loadNhanVienDangLam();
                }
                else if(tbTimKiemNV.Text!= null)
                {
                    if(cbbTK_NV.Text=="Theo Mã NV")
                    {
                        #region Tìm kiếm NV theo tên NV 
                        SqlConnection myCon = new SqlConnection();
                        myCon.ConnectionString = @ckn.chuoiKN();
                        myCon.Open();//không có dòng này thì adapter sẽ tự open
                        string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                        string sqlTimKiem = @nvbll.timKiemNV_QLNV_TheoMa(maPB,"L", tbTimKiemNV.Text, FormDangNhap._maNhanVien);
                        SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                        DataTable myTable = new DataTable();
                        myAdapter.Fill(myTable);
                        dataGridView1.DataSource = myTable;
                        myCon.Close();
                        #endregion
                    }
                    else if(cbbTK_NV.Text == "Theo Tên NV")
                    {
                        #region Tìm kiếm NV theo tên NV 
                        SqlConnection myCon = new SqlConnection();
                        myCon.ConnectionString = @ckn.chuoiKN();
                        myCon.Open();//không có dòng này thì adapter sẽ tự open
                        string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                        string sqlTimKiem = @nvbll.timKiemNV_QLNV_TheoTen(maPB,"L", tbTimKiemNV.Text, FormDangNhap._maNhanVien);
                        SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                        DataTable myTable = new DataTable();
                        myAdapter.Fill(myTable);
                        dataGridView1.DataSource = myTable;
                        myCon.Close();
                        #endregion
                    }
                    else if (cbbTK_NV.Text == "Theo SDT")
                    {
                        #region Tìm kiếm NV theo tên NV 
                        SqlConnection myCon = new SqlConnection();
                        myCon.ConnectionString = @ckn.chuoiKN();
                        myCon.Open();//không có dòng này thì adapter sẽ tự open
                        string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                        string sqlTimKiem = @nvbll.timKiemNV_QLNV_TheoSDT(maPB, "L", tbTimKiemNV.Text, FormDangNhap._maNhanVien);
                        SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                        DataTable myTable = new DataTable();
                        myAdapter.Fill(myTable);
                        dataGridView1.DataSource = myTable;
                        myCon.Close();
                        #endregion
                    }
                }
            }
            else if(_trangThaiTimKiem == "N")
            {
                if (tbTimKiemNV.Text == null)
                {
                    loadNhanVienDaNghi();
                }
                else if (tbTimKiemNV.Text != null)
                {
                    if (cbbTK_NV.Text == "Theo Mã NV")
                    {
                        #region Tìm kiếm NV theo tên NV 
                        SqlConnection myCon = new SqlConnection();
                        myCon.ConnectionString = @ckn.chuoiKN();
                        myCon.Open();//không có dòng này thì adapter sẽ tự open
                        string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                        string sqlTimKiem = @nvbll.timKiemNV_QLNV_TheoMa(maPB, "N", tbTimKiemNV.Text,FormDangNhap._maNhanVien);
                        SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                        DataTable myTable = new DataTable();
                        myAdapter.Fill(myTable);
                        dataGridView1.DataSource = myTable;
                        myCon.Close();
                        #endregion
                    }
                    else if (cbbTK_NV.Text == "Theo Tên NV")
                    {
                        #region Tìm kiếm NV theo tên NV 
                        SqlConnection myCon = new SqlConnection();
                        myCon.ConnectionString = @ckn.chuoiKN();
                        myCon.Open();//không có dòng này thì adapter sẽ tự open
                        string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                        string sqlTimKiem = @nvbll.timKiemNV_QLNV_TheoTen(maPB, "N", tbTimKiemNV.Text, FormDangNhap._maNhanVien);
                        SqlDataAdapter myAdapter = new SqlDataAdapter(sqlTimKiem, myCon);
                        DataTable myTable = new DataTable();
                        myAdapter.Fill(myTable);
                        dataGridView1.DataSource = myTable;
                        myCon.Close();
                        #endregion
                    }
                    else if (cbbTK_NV.Text == "Theo SDT")
                    {
                        #region Tìm kiếm NV theo tên NV 
                        SqlConnection myCon = new SqlConnection();
                        myCon.ConnectionString = @ckn.chuoiKN();
                        myCon.Open();//không có dòng này thì adapter sẽ tự open
                        string maPB = pbbll.layMaPhongBan(FormDangNhap._tenDN, FormDangNhap._MK);
                        string sqlTimKiem = @nvbll.timKiemNV_QLNV_TheoSDT(maPB, "N", tbTimKiemNV.Text, FormDangNhap._maNhanVien);
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            loadCell();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            loadCell();
        }
    }
}