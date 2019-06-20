namespace QuanLyLaoDong.Form_Chung
{
    partial class Form_LienHe
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoiMK = new DevExpress.XtraEditors.SimpleButton();
            this.tbNoiDung = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbEmail = new System.Windows.Forms.RichTextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maLienHe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpbPhanHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(312, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nội dung:";
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDoiMK.Appearance.Options.UseFont = true;
            this.btnDoiMK.Location = new System.Drawing.Point(1079, 73);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(219, 122);
            this.btnDoiMK.TabIndex = 16;
            this.btnDoiMK.Text = "Xác Nhận";
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // tbNoiDung
            // 
            this.tbNoiDung.Location = new System.Drawing.Point(315, 73);
            this.tbNoiDung.Name = "tbNoiDung";
            this.tbNoiDung.Size = new System.Drawing.Size(737, 122);
            this.tbNoiDung.TabIndex = 17;
            this.tbNoiDung.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(47, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Email:";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl1.Controls.Add(this.tbEmail);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.btnDoiMK);
            this.groupControl1.Controls.Add(this.tbNoiDung);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 2);
            this.groupControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1345, 213);
            this.groupControl1.TabIndex = 53;
            this.groupControl1.Text = "Gửi Hỗ Trợ";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(50, 73);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(234, 122);
            this.tbEmail.TabIndex = 20;
            this.tbEmail.Text = "";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl2.Controls.Add(this.dataGridView1);
            this.groupControl2.Location = new System.Drawing.Point(3, 221);
            this.groupControl2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1345, 313);
            this.groupControl2.TabIndex = 54;
            this.groupControl2.Text = "Các thông tin hỗ trợ đã gửi";
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
            this.email,
            this.noiDung,
            this.ngayGui,
            this.tpbPhanHoi,
            this.trangThai});
            this.dataGridView1.Location = new System.Drawing.Point(5, 29);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1335, 279);
            this.dataGridView1.TabIndex = 3;
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
            this.ngayGui.Width = 110;
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
            this.trangThai.Width = 110;
            // 
            // Form_LienHe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 546);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "Form_LienHe";
            this.Text = "Hỗ Trợ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_LienHe_FormClosed);
            this.Load += new System.EventHandler(this.Form_LienHe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox tbNoiDung;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnDoiMK;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox tbEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLienHe;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn noiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpbPhanHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai;
    }
}