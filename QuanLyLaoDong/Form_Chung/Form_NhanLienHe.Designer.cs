namespace QuanLyLaoDong.Form_Chung
{
    partial class Form_NhanLienHe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tbMaHoTro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maLienHe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpbPhanHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.tbNoiDungPhanHoi = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl2.Controls.Add(this.tbMaHoTro);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.dataGridView1);
            this.groupControl2.Location = new System.Drawing.Point(5, 4);
            this.groupControl2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1346, 309);
            this.groupControl2.TabIndex = 55;
            this.groupControl2.Text = "Danh sách hỗ trợ từ nhân viên";
            // 
            // tbMaHoTro
            // 
            this.tbMaHoTro.Enabled = false;
            this.tbMaHoTro.Location = new System.Drawing.Point(110, 33);
            this.tbMaHoTro.Name = "tbMaHoTro";
            this.tbMaHoTro.Size = new System.Drawing.Size(235, 23);
            this.tbMaHoTro.TabIndex = 59;
            this.tbMaHoTro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 58;
            this.label2.Text = "Mã Hỗ Trợ:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maLienHe,
            this.maNhanVien,
            this.tenNhanVien,
            this.email,
            this.noiDung,
            this.ngayGui,
            this.tpbPhanHoi,
            this.trangThai});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(5, 66);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1336, 234);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // maLienHe
            // 
            this.maLienHe.DataPropertyName = "maLienHe";
            this.maLienHe.HeaderText = "Mã Hỗ Trợ";
            this.maLienHe.Name = "maLienHe";
            this.maLienHe.ReadOnly = true;
            this.maLienHe.Width = 80;
            // 
            // maNhanVien
            // 
            this.maNhanVien.DataPropertyName = "maNhanVien";
            this.maNhanVien.FillWeight = 84.30657F;
            this.maNhanVien.HeaderText = "Mã Nhân Viên";
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.ReadOnly = true;
            this.maNhanVien.Width = 90;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.DataPropertyName = "hoTen";
            this.tenNhanVien.HeaderText = "Tên Nhân Vien";
            this.tenNhanVien.Name = "tenNhanVien";
            this.tenNhanVien.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.FillWeight = 84.30657F;
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 110;
            // 
            // noiDung
            // 
            this.noiDung.DataPropertyName = "noiDung";
            this.noiDung.HeaderText = "Nội Dung";
            this.noiDung.Name = "noiDung";
            this.noiDung.ReadOnly = true;
            this.noiDung.Width = 300;
            // 
            // ngayGui
            // 
            this.ngayGui.DataPropertyName = "ngayGui";
            this.ngayGui.FillWeight = 131.3869F;
            this.ngayGui.HeaderText = "Ngày Gửi";
            this.ngayGui.Name = "ngayGui";
            this.ngayGui.ReadOnly = true;
            this.ngayGui.Width = 90;
            // 
            // tpbPhanHoi
            // 
            this.tpbPhanHoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tpbPhanHoi.DataPropertyName = "tpbPhanHoi";
            this.tpbPhanHoi.HeaderText = "TPB Phản Hồi";
            this.tpbPhanHoi.Name = "tpbPhanHoi";
            this.tpbPhanHoi.ReadOnly = true;
            // 
            // trangThai
            // 
            this.trangThai.DataPropertyName = "trangThai";
            this.trangThai.HeaderText = "Trạng Thái";
            this.trangThai.Name = "trangThai";
            this.trangThai.ReadOnly = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl1.Controls.Add(this.btnXacNhan);
            this.groupControl1.Controls.Add(this.tbNoiDungPhanHoi);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(6, 319);
            this.groupControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1345, 222);
            this.groupControl1.TabIndex = 56;
            this.groupControl1.Text = "Hồi Đáp";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.Appearance.Options.UseFont = true;
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.Location = new System.Drawing.Point(1046, 68);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(263, 134);
            this.btnXacNhan.TabIndex = 16;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // tbNoiDungPhanHoi
            // 
            this.tbNoiDungPhanHoi.Enabled = false;
            this.tbNoiDungPhanHoi.Location = new System.Drawing.Point(30, 68);
            this.tbNoiDungPhanHoi.Name = "tbNoiDungPhanHoi";
            this.tbNoiDungPhanHoi.Size = new System.Drawing.Size(988, 134);
            this.tbNoiDungPhanHoi.TabIndex = 17;
            this.tbNoiDungPhanHoi.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(27, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nội dung phản hồi:";
            // 
            // Form_NhanLienHe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 546);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "Form_NhanLienHe";
            this.Text = "Nhận Hỗ Trợ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_NhanLienHe_FormClosed);
            this.Load += new System.EventHandler(this.Form_NhanLienHe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private System.Windows.Forms.RichTextBox tbNoiDungPhanHoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaHoTro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLienHe;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn noiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpbPhanHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai;
    }
}