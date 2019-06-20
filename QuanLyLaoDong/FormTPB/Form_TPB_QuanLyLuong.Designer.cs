namespace QuanLyLaoDong.FormTPB
{
    partial class Form_TPB_QuanLyLuong
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
            this.btnXNTL = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTenNhanVien = new DevExpress.XtraEditors.TextEdit();
            this.cbbTK_NV = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTimKiemNV = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maPhanCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenCongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayBatDauLam1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayKetThuc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daTraLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.cbbTenCongTrinh = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl1.Controls.Add(this.btnXNTL);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.tbTenNhanVien);
            this.groupControl1.Controls.Add(this.cbbTK_NV);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.tbTimKiemNV);
            this.groupControl1.Controls.Add(this.dataGridView1);
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Location = new System.Drawing.Point(3, 2);
            this.groupControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1351, 555);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "                                                                                 " +
    "                                                                    Quản Lý Lươn" +
    "g";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // btnXNTL
            // 
            this.btnXNTL.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXNTL.Appearance.Options.UseFont = true;
            this.btnXNTL.Enabled = false;
            this.btnXNTL.Location = new System.Drawing.Point(761, 503);
            this.btnXNTL.Name = "btnXNTL";
            this.btnXNTL.Size = new System.Drawing.Size(219, 41);
            this.btnXNTL.TabIndex = 72;
            this.btnXNTL.Text = "Xác nhận trả lương";
            this.btnXNTL.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(355, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 73;
            this.label3.Text = "Tên NV:";
            // 
            // tbTenNhanVien
            // 
            this.tbTenNhanVien.Enabled = false;
            this.tbTenNhanVien.Location = new System.Drawing.Point(425, 513);
            this.tbTenNhanVien.Name = "tbTenNhanVien";
            this.tbTenNhanVien.Size = new System.Drawing.Size(321, 22);
            this.tbTenNhanVien.TabIndex = 74;
            this.tbTenNhanVien.EditValueChanged += new System.EventHandler(this.tbTenNhanVien_EditValueChanged);
            // 
            // cbbTK_NV
            // 
            this.cbbTK_NV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTK_NV.FormattingEnabled = true;
            this.cbbTK_NV.Items.AddRange(new object[] {
            "Theo Tên NV",
            "Theo Mã NV"});
            this.cbbTK_NV.Location = new System.Drawing.Point(118, 117);
            this.cbbTK_NV.Name = "cbbTK_NV";
            this.cbbTK_NV.Size = new System.Drawing.Size(234, 24);
            this.cbbTK_NV.TabIndex = 71;
            this.cbbTK_NV.SelectedIndexChanged += new System.EventHandler(this.cbbTK_NV_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(32, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 70;
            this.label9.Text = "Tìm kiếm:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tbTimKiemNV
            // 
            this.tbTimKiemNV.Location = new System.Drawing.Point(365, 117);
            this.tbTimKiemNV.Name = "tbTimKiemNV";
            this.tbTimKiemNV.Size = new System.Drawing.Size(970, 23);
            this.tbTimKiemNV.TabIndex = 69;
            this.tbTimKiemNV.TextChanged += new System.EventHandler(this.tbTimKiemNV_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.maPhanCong,
            this.hoTen,
            this.tenCongTrinh,
            this.ngayBatDauLam1,
            this.ngayKetThuc1,
            this.Column2,
            this.Column1,
            this.daTraLuong});
            this.dataGridView1.Location = new System.Drawing.Point(9, 147);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1332, 338);
            this.dataGridView1.TabIndex = 67;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "maNhanVien";
            this.dataGridViewTextBoxColumn1.HeaderText = "MNV";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // maPhanCong
            // 
            this.maPhanCong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maPhanCong.DataPropertyName = "maPhanCong";
            this.maPhanCong.HeaderText = "MPC";
            this.maPhanCong.Name = "maPhanCong";
            this.maPhanCong.ReadOnly = true;
            // 
            // hoTen
            // 
            this.hoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hoTen.DataPropertyName = "hoTen";
            this.hoTen.HeaderText = "Họ Tên NV";
            this.hoTen.Name = "hoTen";
            this.hoTen.ReadOnly = true;
            // 
            // tenCongTrinh
            // 
            this.tenCongTrinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenCongTrinh.DataPropertyName = "tenCongTrinh";
            this.tenCongTrinh.HeaderText = "Tên Công Trình";
            this.tenCongTrinh.Name = "tenCongTrinh";
            this.tenCongTrinh.ReadOnly = true;
            // 
            // ngayBatDauLam1
            // 
            this.ngayBatDauLam1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ngayBatDauLam1.DataPropertyName = "ngayBatDauLam";
            this.ngayBatDauLam1.HeaderText = "Ngày Bắt Đầu";
            this.ngayBatDauLam1.Name = "ngayBatDauLam1";
            this.ngayBatDauLam1.ReadOnly = true;
            // 
            // ngayKetThuc1
            // 
            this.ngayKetThuc1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ngayKetThuc1.DataPropertyName = "ngayKetThuc";
            this.ngayKetThuc1.HeaderText = "Ngày Kết Thúc";
            this.ngayKetThuc1.Name = "ngayKetThuc1";
            this.ngayKetThuc1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Column1";
            this.Column2.HeaderText = "Số tháng làm";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Column2";
            this.Column1.HeaderText = "Lương CT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // daTraLuong
            // 
            this.daTraLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.daTraLuong.DataPropertyName = "daTraLuong";
            this.daTraLuong.HeaderText = "Đã trả lương";
            this.daTraLuong.Name = "daTraLuong";
            this.daTraLuong.ReadOnly = true;
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl3.Controls.Add(this.label2);
            this.groupControl3.Controls.Add(this.dtpNgayKetThuc);
            this.groupControl3.Controls.Add(this.dtpNgayBatDau);
            this.groupControl3.Controls.Add(this.cbbTenCongTrinh);
            this.groupControl3.Controls.Add(this.label12);
            this.groupControl3.Controls.Add(this.label10);
            this.groupControl3.Controls.Add(this.btnXacNhan);
            this.groupControl3.Location = new System.Drawing.Point(5, 29);
            this.groupControl3.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1336, 82);
            this.groupControl3.TabIndex = 66;
            this.groupControl3.Text = "Thông Tin Công Trình";
            this.groupControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl3_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(78, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Công Trình đang xây dựng:";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.Enabled = false;
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(874, 39);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(157, 23);
            this.dtpNgayKetThuc.TabIndex = 64;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Enabled = false;
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(653, 39);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(157, 23);
            this.dtpNgayBatDau.TabIndex = 63;
            // 
            // cbbTenCongTrinh
            // 
            this.cbbTenCongTrinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenCongTrinh.FormattingEnabled = true;
            this.cbbTenCongTrinh.Location = new System.Drawing.Point(282, 39);
            this.cbbTenCongTrinh.Name = "cbbTenCongTrinh";
            this.cbbTenCongTrinh.Size = new System.Drawing.Size(234, 24);
            this.cbbTenCongTrinh.TabIndex = 43;
            this.cbbTenCongTrinh.SelectedIndexChanged += new System.EventHandler(this.cbbTenCongTrinh_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(825, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 17);
            this.label12.TabIndex = 62;
            this.label12.Text = "Đến:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(577, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 61;
            this.label10.Text = "Từ ngày:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.Appearance.Options.UseFont = true;
            this.btnXacNhan.Location = new System.Drawing.Point(1088, 32);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(143, 41);
            this.btnXacNhan.TabIndex = 52;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // Form_TPB_QuanLyLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 558);
            this.Controls.Add(this.groupControl1);
            this.Name = "Form_TPB_QuanLyLuong";
            this.Text = "Quản Lý Lương - Công Trình Đang Xây Dựng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_TPB_QuanLyLuong_FormClosed);
            this.Load += new System.EventHandler(this.Form_TPB_QuanLyLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.ComboBox cbbTenCongTrinh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbbTK_NV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTimKiemNV;
        private DevExpress.XtraEditors.SimpleButton btnXNTL;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit tbTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPhanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenCongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayBatDauLam1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayKetThuc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn daTraLuong;
    }
}