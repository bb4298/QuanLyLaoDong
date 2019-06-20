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

namespace QuanLyLaoDong.FormTPB
{
    public partial class Form_TPB_ChamCong : DevExpress.XtraEditors.XtraForm
    {
        QLLD_DBDataContext db;
        ChuoiKetNoi ckn;
        CongTrinhBLL ctbll;
       // DataTable tb;
       // SqlDataAdapter dt;
        string _maPB = FormDangNhap._MaPB;
        decimal _luongCongTrinhDangChon;

        public Form_TPB_ChamCong()
        {
            InitializeComponent();
            db = new QLLD_DBDataContext();
            ckn = new ChuoiKetNoi();
            ctbll = new CongTrinhBLL();
            //tb = new DataTable();   
            cbbThang.Text = DateTime.Now.Month.ToString();
            cbbNam.Text = DateTime.Now.Year.ToString();
            cbbTK_NV.Text = "Theo Tên NV";
            dataGridView1.Columns["luongThang"].DefaultCellStyle.Format = "###,## VND";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;

        }

        public void loadDataCongTrinhVaoCBB( string _maPB)
        {
            cbbTenCongTrinh.DataSource = (from c in db.CongTrinhs 
                                            where c.trangThai =="DXD"
                                            select c.tenCongTrinh
                                         );
        }
        public void loadDataNamVaoCBB()
        {
            for(int i =2000;i<=3000;i++)
            {
                cbbNam.Items.Add(i);
            }
            
        }
        public void loadDataChamCong(string tenCT, int thang, int nam)
        {
            
                SqlConnection conn = new SqlConnection(ckn.chuoiKN());
                try
                {
                    conn.Open();
                    string sqlLoad = "select d.maChamCong, d.maPhanCong,a.maNhanVien, a.hoTen, a.soDienThoai, b.ngayBatDauLam, b.ngayKetThuc, d.soNgayLam, d.soNgayNghi, d.luongThang, d.D1, d.D2, d.D3, d.D4, d.D5, d.D6, d.D7, d.D8, d.D9, d.D10, d.D11, d.D12, d.D13, d.D14, d.D15, d.D16, d.D17, d.D18, d.D19, d.D20, d.D21, d.D22, d.D23, d.D24, d.D25, d.D26, d.D27, d.D28, d.D29, d.D30, d.D31 from NhanVien a join PhanCong b on a.maNhanVien=b.maNhanVien join CongTrinh c on b.maCongTrinh=c.maCongTrinh join ChamCong d on b.maPhanCong=d.maPhanCong join PhongBan e on a.maPhongBan=e.maPhongBan where c.trangThai = 'DXD' and d.thang= " + thang+"and d.nam = "+nam+" and c.tenCongTrinh= N'"+tenCT+"' and e.maPhongBan='"+FormDangNhap._MaPB+"' ";
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

       
       

        public bool kiemTraNamNhuan(int pYear)
        {
            if ((pYear % 400 == 0) || (pYear % 4 == 0 && pYear % 100 != 0))
            {
                return true;
            }

            return false;
        }

        private void Form_TPB_ChamCong_Load(object sender, EventArgs e)
        {         
         
            loadDataCongTrinhVaoCBB(_maPB);
            
            loadDataNamVaoCBB();
            
            cbbNam.Text = DateTime.Now.Year.ToString();
            //loadDLCC();


        }

        

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = true;
            if (Convert.ToInt32(cbbThang.Text) == 1 || Convert.ToInt32(cbbThang.Text) == 3 || Convert.ToInt32(cbbThang.Text) == 5 || Convert.ToInt32(cbbThang.Text) == 7 || Convert.ToInt32(cbbThang.Text) == 8 || Convert.ToInt32(cbbThang.Text) == 10 || Convert.ToInt32(cbbThang.Text) == 12)
            {
                dataGridView1.Columns["D31"].ReadOnly = false;
                dataGridView1.Columns["D30"].ReadOnly = false;
                dataGridView1.Columns["D29"].ReadOnly = false;
                loadDataChamCong(cbbTenCongTrinh.Text, Convert.ToInt32(cbbThang.Text), Convert.ToInt32(cbbNam.Text));

            }
            else if(Convert.ToInt32(cbbThang.Text) == 4 || Convert.ToInt32(cbbThang.Text) == 6 || Convert.ToInt32(cbbThang.Text) == 9 || Convert.ToInt32(cbbThang.Text) == 11)
            {
                dataGridView1.Columns["D31"].ReadOnly = true;
                dataGridView1.Columns["D29"].ReadOnly = false;
                dataGridView1.Columns["D30"].ReadOnly = false;

                loadDataChamCong(cbbTenCongTrinh.Text, Convert.ToInt32(cbbThang.Text), Convert.ToInt32(cbbNam.Text));
            }
            else if(Convert.ToInt32(cbbThang.Text) == 2)
            {
                if(kiemTraNamNhuan(Convert.ToInt32(cbbNam.Text))==true)
                {
                    dataGridView1.Columns["D29"].ReadOnly = false;
                    dataGridView1.Columns["D31"].ReadOnly = true;
                    dataGridView1.Columns["D30"].ReadOnly = true;
                    // dataGridView1.Columns["D29"].Visible = true;

                    loadDataChamCong(cbbTenCongTrinh.Text, Convert.ToInt32(cbbThang.Text), Convert.ToInt32(cbbNam.Text));
                }
                else if(kiemTraNamNhuan(Convert.ToInt32(cbbNam.Text)) == false)
                {
                    dataGridView1.Columns["D31"].ReadOnly = true;
                    dataGridView1.Columns["D30"].ReadOnly = true;
                    dataGridView1.Columns["D29"].ReadOnly = true;
                    loadDataChamCong(cbbTenCongTrinh.Text, Convert.ToInt32(cbbThang.Text), Convert.ToInt32(cbbNam.Text));
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ckn.chuoiKN());
            try
            {
                conn.Open();
                //dt.Update(tb);
                for (int i=0; i<dataGridView1.Rows.Count; i++)
                {

                    int soNgayLam = 0;
                    int soNgayNghi = 0;
                    decimal luongThang = 0;

                    #region kiểm tra ngày công
                    //d1
                    if (dataGridView1.Rows[i].Cells["D1"].Value.Equals("C")|| dataGridView1.Rows[i].Cells["D1"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if(!dataGridView1.Rows[i].Cells["D1"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D1"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D1"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d2
                    if (dataGridView1.Rows[i].Cells["D2"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D2"].Value.Equals("c") )
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D2"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D2"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D2"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d3
                    if (dataGridView1.Rows[i].Cells["D3"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D3"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D3"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D3"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D3"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d4
                    if (dataGridView1.Rows[i].Cells["D4"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D4"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D4"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D4"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D4"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d5
                    if (dataGridView1.Rows[i].Cells["D5"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D5"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D5"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D5"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D5"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d6
                    if (dataGridView1.Rows[i].Cells["D6"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D6"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D6"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D6"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D6"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d7
                    if (dataGridView1.Rows[i].Cells["D7"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D7"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D7"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D7"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D7"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d8
                    if (dataGridView1.Rows[i].Cells["D8"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D8"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D8"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D8"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D8"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d9
                    if (dataGridView1.Rows[i].Cells["D9"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D9"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D9"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D9"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D9"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d10
                    if (dataGridView1.Rows[i].Cells["D10"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D10"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D10"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D10"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D10"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d11
                    if (dataGridView1.Rows[i].Cells["D11"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D11"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D11"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D11"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D11"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d12
                    if (dataGridView1.Rows[i].Cells["D12"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D12"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D12"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D12"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D12"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d13
                    if (dataGridView1.Rows[i].Cells["D13"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D13"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D13"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D13"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D13"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d14
                    if (dataGridView1.Rows[i].Cells["D14"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D14"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D14"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D14"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D14"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d15
                    if (dataGridView1.Rows[i].Cells["D15"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D15"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D15"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D15"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D15"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d16
                    if (dataGridView1.Rows[i].Cells["D16"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D16"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D16"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D16"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D16"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d17
                    if (dataGridView1.Rows[i].Cells["D17"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D17"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D17"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D17"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D17"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d18
                    if (dataGridView1.Rows[i].Cells["D18"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D18"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D18"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D18"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D18"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d19
                    if (dataGridView1.Rows[i].Cells["D18"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D18"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D19"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D19"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D19"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                   
                    //d20
                    if (dataGridView1.Rows[i].Cells["D20"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D20"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D20"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D20"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D20"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d21
                    if (dataGridView1.Rows[i].Cells["D21"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D21"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D21"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D21"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D21"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d22
                    if (dataGridView1.Rows[i].Cells["D22"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D22"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D22"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D22"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D22"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d23
                    if (dataGridView1.Rows[i].Cells["D23"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D23"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D23"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D23"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D23"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d24
                    if (dataGridView1.Rows[i].Cells["D24"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D24"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D24"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D24"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D24"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d25
                    if (dataGridView1.Rows[i].Cells["D25"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D25"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D25"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D25"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D25"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d26
                    if (dataGridView1.Rows[i].Cells["D26"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D26"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D26"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D26"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D26"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d27
                    if (dataGridView1.Rows[i].Cells["D27"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D27"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D27"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D27"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D27"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d28
                    if (dataGridView1.Rows[i].Cells["D28"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D28"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D28"].Value.Equals("C") || !dataGridView1.Rows[i].Cells["D28"].Value.Equals("c") || !dataGridView1.Rows[i].Cells["D28"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d29
                    if (dataGridView1.Rows[i].Cells["D29"].Value.Equals("X") || dataGridView1.Rows[i].Cells["D29"].Value.Equals("x"))
                    {
                        soNgayLam = soNgayLam;
                    }
                    else if (dataGridView1.Rows[i].Cells["D29"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D29"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D29"].Value.Equals("C") && !dataGridView1.Rows[i].Cells["D29"].Value.Equals("c") && !dataGridView1.Rows[i].Cells["D29"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }
                    //d30
                    if (dataGridView1.Rows[i].Cells["D30"].Value.Equals("X") || dataGridView1.Rows[i].Cells["D30"].Value.Equals("x"))
                    {
                        soNgayLam = soNgayLam;
                    }
                    else if (dataGridView1.Rows[i].Cells["D30"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D30"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D30"].Value.Equals("C") && !dataGridView1.Rows[i].Cells["D30"].Value.Equals("c") && !dataGridView1.Rows[i].Cells["D30"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    //d31
                    if (dataGridView1.Rows[i].Cells["D31"].Value.Equals("X") || dataGridView1.Rows[i].Cells["D31"].Value.Equals("x"))
                    {
                        soNgayLam = soNgayLam;
                    }
                    else if (dataGridView1.Rows[i].Cells["D31"].Value.Equals("C") || dataGridView1.Rows[i].Cells["D31"].Value.Equals("c"))
                    {
                        soNgayLam = soNgayLam + 1;
                    }
                    else if (!dataGridView1.Rows[i].Cells["D31"].Value.Equals("C") && !dataGridView1.Rows[i].Cells["D31"].Value.Equals("c") && !dataGridView1.Rows[i].Cells["D31"].Value.Equals("x"))
                    {
                        soNgayNghi = soNgayNghi + 1;
                    }

                    #endregion



                    luongThang = soNgayLam * _luongCongTrinhDangChon;


                    string sqlSua = "update ChamCong set soNgayLam =" + soNgayLam + ",soNgayNghi =" + soNgayNghi + ",luongThang =" + luongThang + ", D1='" +dataGridView1.Rows[i].Cells["D1"].Value.ToString().ToUpper()+"', D2='" + dataGridView1.Rows[i].Cells["D2"].Value.ToString().ToUpper() + "', D3='" + dataGridView1.Rows[i].Cells["D3"].Value.ToString().ToUpper() + "', D4='" + dataGridView1.Rows[i].Cells["D4"].Value.ToString().ToUpper() + "', D5='" + dataGridView1.Rows[i].Cells["D5"].Value.ToString().ToUpper() + "', D6='" + dataGridView1.Rows[i].Cells["D6"].Value.ToString().ToUpper() + "', D7='" + dataGridView1.Rows[i].Cells["D7"].Value.ToString().ToUpper() + "', D8='" + dataGridView1.Rows[i].Cells["D8"].Value.ToString().ToUpper() + "', D9='" + dataGridView1.Rows[i].Cells["D9"].Value.ToString().ToUpper() + "', D10='" + dataGridView1.Rows[i].Cells["D10"].Value.ToString().ToUpper() + "', D11='" + dataGridView1.Rows[i].Cells["D11"].Value.ToString().ToUpper() + "', D12='" + dataGridView1.Rows[i].Cells["D12"].Value.ToString().ToUpper() + "', D13='" + dataGridView1.Rows[i].Cells["D13"].Value.ToString().ToUpper() + "', D14='" + dataGridView1.Rows[i].Cells["D14"].Value.ToString().ToUpper() + "', D15='" + dataGridView1.Rows[i].Cells["D15"].Value.ToString().ToUpper() + "', D16='" + dataGridView1.Rows[i].Cells["D16"].Value.ToString().ToUpper() + "', D17='" + dataGridView1.Rows[i].Cells["D17"].Value.ToString().ToUpper() + "', D18='" + dataGridView1.Rows[i].Cells["D18"].Value.ToString().ToUpper() + "', D19='" + dataGridView1.Rows[i].Cells["D19"].Value.ToString().ToUpper() + "', D20='" + dataGridView1.Rows[i].Cells["D20"].Value.ToString().ToUpper() + "', D21='" + dataGridView1.Rows[i].Cells["D21"].Value.ToString().ToUpper() + "', D22='" + dataGridView1.Rows[i].Cells["D22"].Value.ToString().ToUpper() + "', D23='" + dataGridView1.Rows[i].Cells["D23"].Value.ToString().ToUpper() + "', D24='" + dataGridView1.Rows[i].Cells["D24"].Value.ToString().ToUpper() + "', D25='" + dataGridView1.Rows[i].Cells["D25"].Value.ToString().ToUpper() + "', D26='" + dataGridView1.Rows[i].Cells["D26"].Value.ToString().ToUpper() + "', D27='" + dataGridView1.Rows[i].Cells["D27"].Value.ToString().ToUpper() + "', D28='" + dataGridView1.Rows[i].Cells["D28"].Value.ToString().ToUpper() + "', D29='" + dataGridView1.Rows[i].Cells["D29"].Value.ToString().ToUpper() + "', D30='" + dataGridView1.Rows[i].Cells["D30"].Value.ToString().ToUpper() + "', D31='" + dataGridView1.Rows[i].Cells["D31"].Value.ToString().ToUpper() + "' where maChamCong = "+ dataGridView1.Rows[i].Cells["maChamCong"].Value + " ";
                    SqlCommand cmd = new SqlCommand(sqlSua, conn);
                    int kq = (int)cmd.ExecuteNonQuery();
         
                }

                XtraMessageBox.Show("Cập nhật thành công !");
                conn.Close();

                btnXacNhan_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex);
            }
        }

        private void Form_TPB_ChamCong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_TPB_CC = true;
        }

        private void cbbTenCongTrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            _luongCongTrinhDangChon = ctbll.layLuongCT_CongTrinh(cbbTenCongTrinh.Text);
           
            dtpNgayBatDau.Value = ctbll.layNgayBD_CT(cbbTenCongTrinh.Text);
            dtpNgayKetThuc.Value = ctbll.layNgayKT_CT(cbbTenCongTrinh.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            if(cbbTK_NV.Text == "")
            {
                loadDataChamCong(cbbTenCongTrinh.Text, Convert.ToInt32(cbbThang.Text), Convert.ToInt32(cbbNam.Text));
            }
            else if(cbbTK_NV.Text != "")
            {
                if (cbbTK_NV.Text == "Theo Tên NV")
                {
                    SqlConnection conn = new SqlConnection(ckn.chuoiKN());
                    try
                    {
                        conn.Open();
                        string sqlLoad = "select d.maChamCong, d.maPhanCong,a.maNhanVien, a.hoTen, a.soDienThoai, b.ngayBatDauLam, b.ngayKetThuc, d.soNgayLam, d.soNgayNghi, d.luongThang, d.D1, d.D2, d.D3, d.D4, d.D5, d.D6, d.D7, d.D8, d.D9, d.D10, d.D11, d.D12, d.D13, d.D14, d.D15, d.D16, d.D17, d.D18, d.D19, d.D20, d.D21, d.D22, d.D23, d.D24, d.D25, d.D26, d.D27, d.D28, d.D29, d.D30, d.D31 from NhanVien a join PhanCong b on a.maNhanVien=b.maNhanVien join CongTrinh c on b.maCongTrinh=c.maCongTrinh join ChamCong d on b.maPhanCong=d.maPhanCong join PhongBan e on a.maPhongBan=e.maPhongBan where c.trangThai = 'DXD' and d.thang= " + Convert.ToInt32(cbbThang.Text) + "and d.nam = " + Convert.ToInt32(cbbNam.Text) + " and c.tenCongTrinh= N'" + cbbTenCongTrinh.Text + "' and e.maPhongBan='" + FormDangNhap._MaPB + "' and a.hoTen like N'%"+tbTimKiemNV.Text+"%' ";
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
                else if(cbbTK_NV.Text == "Theo Mã NV")
                {
                    SqlConnection conn = new SqlConnection(ckn.chuoiKN());
                    try
                    {
                        conn.Open();
                        string sqlLoad = "select d.maChamCong, d.maPhanCong,a.maNhanVien, a.hoTen, a.soDienThoai, b.ngayBatDauLam, b.ngayKetThuc, d.soNgayLam, d.soNgayNghi, d.luongThang, d.D1, d.D2, d.D3, d.D4, d.D5, d.D6, d.D7, d.D8, d.D9, d.D10, d.D11, d.D12, d.D13, d.D14, d.D15, d.D16, d.D17, d.D18, d.D19, d.D20, d.D21, d.D22, d.D23, d.D24, d.D25, d.D26, d.D27, d.D28, d.D29, d.D30, d.D31 from NhanVien a join PhanCong b on a.maNhanVien=b.maNhanVien join CongTrinh c on b.maCongTrinh=c.maCongTrinh join ChamCong d on b.maPhanCong=d.maPhanCong join PhongBan e on a.maPhongBan=e.maPhongBan where c.trangThai = 'DXD' and d.thang= " + Convert.ToInt32(cbbThang.Text) + "and d.nam = " + Convert.ToInt32(cbbNam.Text) + " and c.tenCongTrinh= N'" + cbbTenCongTrinh.Text + "' and e.maPhongBan='" + FormDangNhap._MaPB + "'and a.maNhanVien like N'%" + tbTimKiemNV.Text + "%' ";
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
                else if(cbbTK_NV.Text == "Theo SDT")
                {
                    SqlConnection conn = new SqlConnection(ckn.chuoiKN());
                    try
                    {
                        conn.Open();
                        string sqlLoad = "select d.maChamCong, d.maPhanCong,a.maNhanVien, a.hoTen, a.soDienThoai, b.ngayBatDauLam, b.ngayKetThuc, d.soNgayLam, d.soNgayNghi, d.luongThang, d.D1, d.D2, d.D3, d.D4, d.D5, d.D6, d.D7, d.D8, d.D9, d.D10, d.D11, d.D12, d.D13, d.D14, d.D15, d.D16, d.D17, d.D18, d.D19, d.D20, d.D21, d.D22, d.D23, d.D24, d.D25, d.D26, d.D27, d.D28, d.D29, d.D30, d.D31 from NhanVien a join PhanCong b on a.maNhanVien=b.maNhanVien join CongTrinh c on b.maCongTrinh=c.maCongTrinh join ChamCong d on b.maPhanCong=d.maPhanCong join PhongBan e on a.maPhongBan=e.maPhongBan where c.trangThai = 'DXD' and d.thang= " + Convert.ToInt32(cbbThang.Text) + "and d.nam = " + Convert.ToInt32(cbbNam.Text) + " and c.tenCongTrinh= N'" + cbbTenCongTrinh.Text + "' and e.maPhongBan='" + FormDangNhap._MaPB + "' and a.soDienThoai like N'%" + tbTimKiemNV.Text + "%' ";
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
    }
}