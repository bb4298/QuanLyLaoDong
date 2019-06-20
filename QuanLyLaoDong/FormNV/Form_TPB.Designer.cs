namespace QuanLyLaoDong
{
    partial class Form_TPB
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TPB));
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnThongTinCaNhan = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuanLyNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhanCong = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuanLyNgayCong = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoiMK = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar2 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.nativeMdiView1 = new DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeMdiView1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.View = this.nativeMdiView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.nativeMdiView1});
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Xin chào:";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnThongTinCaNhan,
            this.btnQuanLyNhanVien,
            this.btnPhanCong,
            this.btnQuanLyNgayCong,
            this.btnDoiMK});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1356, 179);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar2;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.Caption = "Thông tin cá nhân";
            this.btnThongTinCaNhan.Id = 1;
            this.btnThongTinCaNhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThongTinCaNhan.ImageOptions.Image")));
            this.btnThongTinCaNhan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThongTinCaNhan.ImageOptions.LargeImage")));
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnThongTinCaNhan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongTinCaNhan_ItemClick);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.Caption = "Quản lý nhân viên";
            this.btnQuanLyNhanVien.Id = 3;
            this.btnQuanLyNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyNhanVien.ImageOptions.Image")));
            this.btnQuanLyNhanVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuanLyNhanVien.ImageOptions.LargeImage")));
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQuanLyNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuanLyNhanVien_ItemClick);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Caption = "Phân công nhân viên";
            this.btnPhanCong.Id = 4;
            this.btnPhanCong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPhanCong.ImageOptions.Image")));
            this.btnPhanCong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPhanCong.ImageOptions.LargeImage")));
            this.btnPhanCong.Name = "btnPhanCong";
            // 
            // btnQuanLyNgayCong
            // 
            this.btnQuanLyNgayCong.Caption = "Quản lý ngày công nhân viên";
            this.btnQuanLyNgayCong.Id = 5;
            this.btnQuanLyNgayCong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyNgayCong.ImageOptions.Image")));
            this.btnQuanLyNgayCong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuanLyNgayCong.ImageOptions.LargeImage")));
            this.btnQuanLyNgayCong.Name = "btnQuanLyNgayCong";
            this.btnQuanLyNgayCong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Caption = "Đổi mật khẩu";
            this.btnDoiMK.Id = 6;
            this.btnDoiMK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiMK.ImageOptions.Image")));
            this.btnDoiMK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoiMK.ImageOptions.LargeImage")));
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDoiMK_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnThongTinCaNhan);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDoiMK);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnQuanLyNhanVien);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPhanCong);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnQuanLyNgayCong);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar2
            // 
            this.ribbonStatusBar2.Location = new System.Drawing.Point(0, 742);
            this.ribbonStatusBar2.Name = "ribbonStatusBar2";
            this.ribbonStatusBar2.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar2.Size = new System.Drawing.Size(1356, 30);
            // 
            // Form_TPB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 772);
            this.Controls.Add(this.ribbonStatusBar2);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.label1);
            this.IsMdiContainer = true;
            this.Name = "Form_TPB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTPB";
            this.Load += new System.EventHandler(this.Form_TPB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeMdiView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnThongTinCaNhan;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnPhanCong;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyNgayCong;
        private DevExpress.XtraBars.BarButtonItem btnDoiMK;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView nativeMdiView1;
    }
}