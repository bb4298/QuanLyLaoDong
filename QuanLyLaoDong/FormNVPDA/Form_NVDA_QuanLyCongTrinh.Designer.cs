namespace QuanLyLaoDong.FormNVPDA
{
    partial class Form_NVDA_QuanLyCongTrinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnHoanThanh = new DevExpress.XtraEditors.SimpleButton();
            this.panelQuanLy = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLuongCT = new DevExpress.XtraEditors.TextEdit();
            this.tbMaCongTrinh = new DevExpress.XtraEditors.TextEdit();
            this.dtpNgayHoanThanh = new System.Windows.Forms.DateTimePicker();
            this.tbTenCongTrinh = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayKhoiCong = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayCapPhep = new System.Windows.Forms.DateTimePicker();
            this.tbDiaDiemXayDung = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.controlThaoTac = new DevExpress.XtraEditors.GroupControl();
            this.panelThaoTac = new System.Windows.Forms.Panel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.controlThongTin = new DevExpress.XtraEditors.GroupControl();
            this.pannelThongTin = new System.Windows.Forms.Panel();
            this.btnXemHoanThanh = new DevExpress.XtraEditors.SimpleButton();
            this.btnXemThiCong = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maCongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenCongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaDiemXayDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.luongCongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayCapPhep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayKhoiCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayHoanThanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbTK_NV = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTimKiemCT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.panelQuanLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLuongCT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaCongTrinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenCongTrinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDiaDiemXayDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlThaoTac)).BeginInit();
            this.controlThaoTac.SuspendLayout();
            this.panelThaoTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlThongTin)).BeginInit();
            this.controlThongTin.SuspendLayout();
            this.pannelThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.panelQuanLy);
            this.groupControl1.Controls.Add(this.controlThaoTac);
            this.groupControl1.Controls.Add(this.controlThongTin);
            this.groupControl1.Location = new System.Drawing.Point(81, 12);
            this.groupControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1195, 287);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "                                                                                 " +
    "                                                  Quản Lý Công Trình";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnHoanThanh);
            this.groupControl2.Location = new System.Drawing.Point(402, 141);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(156, 141);
            this.groupControl2.TabIndex = 54;
            this.groupControl2.Text = "Xác nhận";
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnHoanThanh.Appearance.Options.UseFont = true;
            this.btnHoanThanh.Enabled = false;
            this.btnHoanThanh.Location = new System.Drawing.Point(15, 41);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(124, 86);
            this.btnHoanThanh.TabIndex = 15;
            this.btnHoanThanh.Text = "Hoàn Thành";
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // panelQuanLy
            // 
            this.panelQuanLy.Controls.Add(this.label5);
            this.panelQuanLy.Controls.Add(this.tbLuongCT);
            this.panelQuanLy.Controls.Add(this.tbMaCongTrinh);
            this.panelQuanLy.Controls.Add(this.dtpNgayHoanThanh);
            this.panelQuanLy.Controls.Add(this.tbTenCongTrinh);
            this.panelQuanLy.Controls.Add(this.label4);
            this.panelQuanLy.Controls.Add(this.label3);
            this.panelQuanLy.Controls.Add(this.dtpNgayKhoiCong);
            this.panelQuanLy.Controls.Add(this.label2);
            this.panelQuanLy.Controls.Add(this.dtpNgayCapPhep);
            this.panelQuanLy.Controls.Add(this.tbDiaDiemXayDung);
            this.panelQuanLy.Controls.Add(this.label8);
            this.panelQuanLy.Controls.Add(this.label1);
            this.panelQuanLy.Controls.Add(this.label6);
            this.panelQuanLy.Enabled = false;
            this.panelQuanLy.Location = new System.Drawing.Point(5, 29);
            this.panelQuanLy.Name = "panelQuanLy";
            this.panelQuanLy.Size = new System.Drawing.Size(1180, 110);
            this.panelQuanLy.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(440, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Mức lương:";
            // 
            // tbLuongCT
            // 
            this.tbLuongCT.Location = new System.Drawing.Point(532, 43);
            this.tbLuongCT.Name = "tbLuongCT";
            this.tbLuongCT.Size = new System.Drawing.Size(233, 22);
            this.tbLuongCT.TabIndex = 59;
            // 
            // tbMaCongTrinh
            // 
            this.tbMaCongTrinh.Location = new System.Drawing.Point(127, 11);
            this.tbMaCongTrinh.Name = "tbMaCongTrinh";
            this.tbMaCongTrinh.Size = new System.Drawing.Size(233, 22);
            this.tbMaCongTrinh.TabIndex = 52;
            // 
            // dtpNgayHoanThanh
            // 
            this.dtpNgayHoanThanh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayHoanThanh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHoanThanh.Location = new System.Drawing.Point(929, 77);
            this.dtpNgayHoanThanh.Name = "dtpNgayHoanThanh";
            this.dtpNgayHoanThanh.Size = new System.Drawing.Size(233, 23);
            this.dtpNgayHoanThanh.TabIndex = 57;
            this.dtpNgayHoanThanh.ValueChanged += new System.EventHandler(this.dtpNgayHoanThanh_ValueChanged);
            // 
            // tbTenCongTrinh
            // 
            this.tbTenCongTrinh.Location = new System.Drawing.Point(127, 47);
            this.tbTenCongTrinh.Name = "tbTenCongTrinh";
            this.tbTenCongTrinh.Size = new System.Drawing.Size(233, 22);
            this.tbTenCongTrinh.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(385, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Địa điểm xây dựng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tên công trình:";
            // 
            // dtpNgayKhoiCong
            // 
            this.dtpNgayKhoiCong.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKhoiCong.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKhoiCong.Location = new System.Drawing.Point(929, 43);
            this.dtpNgayKhoiCong.Name = "dtpNgayKhoiCong";
            this.dtpNgayKhoiCong.Size = new System.Drawing.Size(233, 23);
            this.dtpNgayKhoiCong.TabIndex = 56;
            this.dtpNgayKhoiCong.ValueChanged += new System.EventHandler(this.dtpNgayKhoiCong_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã công trình:";
            // 
            // dtpNgayCapPhep
            // 
            this.dtpNgayCapPhep.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayCapPhep.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayCapPhep.Location = new System.Drawing.Point(929, 8);
            this.dtpNgayCapPhep.Name = "dtpNgayCapPhep";
            this.dtpNgayCapPhep.Size = new System.Drawing.Size(233, 23);
            this.dtpNgayCapPhep.TabIndex = 55;
            this.dtpNgayCapPhep.Value = new System.DateTime(2018, 10, 21, 22, 21, 26, 0);
            this.dtpNgayCapPhep.ValueChanged += new System.EventHandler(this.dtpNgayCapPhep_ValueChanged);
            // 
            // tbDiaDiemXayDung
            // 
            this.tbDiaDiemXayDung.Location = new System.Drawing.Point(532, 10);
            this.tbDiaDiemXayDung.Name = "tbDiaDiemXayDung";
            this.tbDiaDiemXayDung.Size = new System.Drawing.Size(233, 22);
            this.tbDiaDiemXayDung.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(803, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 43;
            this.label8.Text = "Ngày khởi công:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(807, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ngày cấp phép:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(790, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "Ngày hoàn thành:";
            // 
            // controlThaoTac
            // 
            this.controlThaoTac.Controls.Add(this.panelThaoTac);
            this.controlThaoTac.Location = new System.Drawing.Point(564, 141);
            this.controlThaoTac.Name = "controlThaoTac";
            this.controlThaoTac.Size = new System.Drawing.Size(626, 141);
            this.controlThaoTac.TabIndex = 47;
            this.controlThaoTac.Text = "Thao tác";
            // 
            // panelThaoTac
            // 
            this.panelThaoTac.Controls.Add(this.btnThem);
            this.panelThaoTac.Controls.Add(this.btnHuy);
            this.panelThaoTac.Controls.Add(this.btnXoa);
            this.panelThaoTac.Controls.Add(this.btnSua);
            this.panelThaoTac.Controls.Add(this.btnLuu);
            this.panelThaoTac.Location = new System.Drawing.Point(17, 41);
            this.panelThaoTac.Name = "panelThaoTac";
            this.panelThaoTac.Size = new System.Drawing.Size(604, 91);
            this.panelThaoTac.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Location = new System.Drawing.Point(11, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(98, 63);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Enabled = false;
            this.btnHuy.Location = new System.Drawing.Point(488, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(98, 63);
            this.btnHuy.TabIndex = 59;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(248, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(98, 63);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(128, 11);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(98, 63);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Enabled = false;
            this.btnLuu.Location = new System.Drawing.Point(370, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(98, 63);
            this.btnLuu.TabIndex = 58;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // controlThongTin
            // 
            this.controlThongTin.Controls.Add(this.pannelThongTin);
            this.controlThongTin.Location = new System.Drawing.Point(5, 141);
            this.controlThongTin.Name = "controlThongTin";
            this.controlThongTin.Size = new System.Drawing.Size(391, 141);
            this.controlThongTin.TabIndex = 12;
            this.controlThongTin.Text = "Xem thông tin";
            // 
            // pannelThongTin
            // 
            this.pannelThongTin.Controls.Add(this.btnXemHoanThanh);
            this.pannelThongTin.Controls.Add(this.btnXemThiCong);
            this.pannelThongTin.Location = new System.Drawing.Point(16, 41);
            this.pannelThongTin.Name = "pannelThongTin";
            this.pannelThongTin.Size = new System.Drawing.Size(363, 86);
            this.pannelThongTin.TabIndex = 15;
            // 
            // btnXemHoanThanh
            // 
            this.btnXemHoanThanh.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXemHoanThanh.Appearance.Options.UseFont = true;
            this.btnXemHoanThanh.Location = new System.Drawing.Point(200, 10);
            this.btnXemHoanThanh.Name = "btnXemHoanThanh";
            this.btnXemHoanThanh.Size = new System.Drawing.Size(152, 63);
            this.btnXemHoanThanh.TabIndex = 16;
            this.btnXemHoanThanh.Text = "CT Đã hoàn thành";
            this.btnXemHoanThanh.Click += new System.EventHandler(this.btnXemHoanThanh_Click);
            // 
            // btnXemThiCong
            // 
            this.btnXemThiCong.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXemThiCong.Appearance.Options.UseFont = true;
            this.btnXemThiCong.Location = new System.Drawing.Point(12, 10);
            this.btnXemThiCong.Name = "btnXemThiCong";
            this.btnXemThiCong.Size = new System.Drawing.Size(152, 63);
            this.btnXemThiCong.TabIndex = 15;
            this.btnXemThiCong.Text = "CT Đang thi công";
            this.btnXemThiCong.Click += new System.EventHandler(this.btnXemThiCong_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maCongTrinh,
            this.tenCongTrinh,
            this.diaDiemXayDung,
            this.luongCongTrinh,
            this.ngayCapPhep,
            this.ngayKhoiCong,
            this.ngayHoanThanh});
            this.dataGridView1.Location = new System.Drawing.Point(81, 337);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1195, 197);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // maCongTrinh
            // 
            this.maCongTrinh.DataPropertyName = "maCongTrinh";
            this.maCongTrinh.HeaderText = "Mã CT";
            this.maCongTrinh.Name = "maCongTrinh";
            this.maCongTrinh.ReadOnly = true;
            this.maCongTrinh.Width = 90;
            // 
            // tenCongTrinh
            // 
            this.tenCongTrinh.DataPropertyName = "tenCongTrinh";
            this.tenCongTrinh.HeaderText = "Tên CT";
            this.tenCongTrinh.Name = "tenCongTrinh";
            this.tenCongTrinh.ReadOnly = true;
            this.tenCongTrinh.Width = 180;
            // 
            // diaDiemXayDung
            // 
            this.diaDiemXayDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.diaDiemXayDung.DataPropertyName = "diaDiemXayDung";
            this.diaDiemXayDung.HeaderText = "Địa Điểm Xây Dựng";
            this.diaDiemXayDung.Name = "diaDiemXayDung";
            this.diaDiemXayDung.ReadOnly = true;
            // 
            // luongCongTrinh
            // 
            this.luongCongTrinh.DataPropertyName = "luongCongTrinh";
            this.luongCongTrinh.FillWeight = 120F;
            this.luongCongTrinh.HeaderText = "Lương CT";
            this.luongCongTrinh.Name = "luongCongTrinh";
            this.luongCongTrinh.ReadOnly = true;
            // 
            // ngayCapPhep
            // 
            this.ngayCapPhep.DataPropertyName = "ngayCapPhep";
            this.ngayCapPhep.HeaderText = "Ngày Cấp Phép";
            this.ngayCapPhep.Name = "ngayCapPhep";
            this.ngayCapPhep.ReadOnly = true;
            this.ngayCapPhep.Width = 140;
            // 
            // ngayKhoiCong
            // 
            this.ngayKhoiCong.DataPropertyName = "ngayKhoiCong";
            this.ngayKhoiCong.HeaderText = "Ngày Khởi Công";
            this.ngayKhoiCong.Name = "ngayKhoiCong";
            this.ngayKhoiCong.ReadOnly = true;
            this.ngayKhoiCong.Width = 140;
            // 
            // ngayHoanThanh
            // 
            this.ngayHoanThanh.DataPropertyName = "ngayHoanThanh";
            this.ngayHoanThanh.HeaderText = "Ngày Hoàn Thành";
            this.ngayHoanThanh.Name = "ngayHoanThanh";
            this.ngayHoanThanh.ReadOnly = true;
            this.ngayHoanThanh.Width = 150;
            // 
            // cbbTK_NV
            // 
            this.cbbTK_NV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTK_NV.FormattingEnabled = true;
            this.cbbTK_NV.Items.AddRange(new object[] {
            "Theo Tên CT",
            "Theo Mã CT",
            "Theo Địa Điểm"});
            this.cbbTK_NV.Location = new System.Drawing.Point(164, 307);
            this.cbbTK_NV.Name = "cbbTK_NV";
            this.cbbTK_NV.Size = new System.Drawing.Size(266, 24);
            this.cbbTK_NV.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(84, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "Tìm kiếm:";
            // 
            // tbTimKiemCT
            // 
            this.tbTimKiemCT.Location = new System.Drawing.Point(436, 308);
            this.tbTimKiemCT.Name = "tbTimKiemCT";
            this.tbTimKiemCT.Size = new System.Drawing.Size(840, 23);
            this.tbTimKiemCT.TabIndex = 32;
            this.tbTimKiemCT.TextChanged += new System.EventHandler(this.tbTimKiemNV_TextChanged);
            // 
            // Form_NVDA_QuanLyCongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 547);
            this.Controls.Add(this.cbbTK_NV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbTimKiemCT);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_NVDA_QuanLyCongTrinh";
            this.Text = "Quản Lý Công Trình";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_NVDA_QuanLyCongTrinh_FormClosed);
            this.Load += new System.EventHandler(this.Form_NVDA_QuanLyCongTrinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.panelQuanLy.ResumeLayout(false);
            this.panelQuanLy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLuongCT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaCongTrinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenCongTrinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDiaDiemXayDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlThaoTac)).EndInit();
            this.controlThaoTac.ResumeLayout(false);
            this.panelThaoTac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlThongTin)).EndInit();
            this.controlThongTin.ResumeLayout(false);
            this.pannelThongTin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit tbDiaDiemXayDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.GroupControl controlThaoTac;
        private DevExpress.XtraEditors.GroupControl controlThongTin;
        private DevExpress.XtraEditors.SimpleButton btnXemHoanThanh;
        private DevExpress.XtraEditors.SimpleButton btnXemThiCong;
        private System.Windows.Forms.DateTimePicker dtpNgayHoanThanh;
        private System.Windows.Forms.DateTimePicker dtpNgayKhoiCong;
        private System.Windows.Forms.DateTimePicker dtpNgayCapPhep;
        private DevExpress.XtraEditors.TextEdit tbMaCongTrinh;
        private DevExpress.XtraEditors.TextEdit tbTenCongTrinh;
        private System.Windows.Forms.Panel panelQuanLy;
        private System.Windows.Forms.Panel panelThaoTac;
        private System.Windows.Forms.Panel pannelThongTin;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnHoanThanh;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit tbLuongCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn maCongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenCongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaDiemXayDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn luongCongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayCapPhep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayKhoiCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayHoanThanh;
        private System.Windows.Forms.ComboBox cbbTK_NV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTimKiemCT;
    }
}