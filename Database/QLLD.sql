USE [master]
GO
/****** Object:  Database [QuanLiLaoDong]    Script Date: 12/09/2018 21:19:41 ******/
CREATE DATABASE [QuanLiLaoDong] ON  PRIMARY 
( NAME = N'QuanLiLaoDong', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QuanLiLaoDong.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLiLaoDong_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QuanLiLaoDong_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLiLaoDong] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLiLaoDong].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLiLaoDong] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET ARITHABORT OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QuanLiLaoDong] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QuanLiLaoDong] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QuanLiLaoDong] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET  DISABLE_BROKER
GO
ALTER DATABASE [QuanLiLaoDong] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QuanLiLaoDong] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QuanLiLaoDong] SET  READ_WRITE
GO
ALTER DATABASE [QuanLiLaoDong] SET RECOVERY SIMPLE
GO
ALTER DATABASE [QuanLiLaoDong] SET  MULTI_USER
GO
ALTER DATABASE [QuanLiLaoDong] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QuanLiLaoDong] SET DB_CHAINING OFF
GO
USE [QuanLiLaoDong]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 12/09/2018 21:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[maPhongBan] [nvarchar](50) NOT NULL,
	[tenPhongBan] [nvarchar](30) NULL,
	[loaiPhongBan] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[maPhongBan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PhongBan] ([maPhongBan], [tenPhongBan], [loaiPhongBan]) VALUES (N'PB001       ', N'Phòng Chuyên Môn', N'PCM')
INSERT [dbo].[PhongBan] ([maPhongBan], [tenPhongBan], [loaiPhongBan]) VALUES (N'PB002       ', N'Phòng Kinh Doanh', N'PKD')
INSERT [dbo].[PhongBan] ([maPhongBan], [tenPhongBan], [loaiPhongBan]) VALUES (N'PB003', N'Phòng Kỹ Thuật', N'PKT')
INSERT [dbo].[PhongBan] ([maPhongBan], [tenPhongBan], [loaiPhongBan]) VALUES (N'PB004', N'Phòng Tổ Chức', N'PTC')
INSERT [dbo].[PhongBan] ([maPhongBan], [tenPhongBan], [loaiPhongBan]) VALUES (N'PB005', N'Phòng Dự Án', N'PDA')
/****** Object:  Table [dbo].[CongTrinh]    Script Date: 12/09/2018 21:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongTrinh](
	[maCongTrinh] [nvarchar](50) NOT NULL,
	[tenCongTrinh] [nvarchar](50) NULL,
	[diaDiemXayDung] [nvarchar](max) NULL,
	[ngayCapPhep] [datetime] NULL,
	[ngayKhoiCong] [datetime] NULL,
	[ngayHoanThanh] [datetime] NULL,
	[luongCongTrinh] [decimal](18, 0) NULL,
	[trangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_CongTrinh] PRIMARY KEY CLUSTERED 
(
	[maCongTrinh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0001', N'Land Mark 81', N'Vinhome, quận Bình Thạnh, TP Hồ Chí Minh', CAST(0x0000A80A00000000 AS DateTime), CAST(0x0000A8A100000000 AS DateTime), CAST(0x0000AA3000000000 AS DateTime), CAST(200000 AS Decimal(18, 0)), N'DXD')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0002', N'Nhà Quốc Hội', N'Đường Độc Lập, quận Ba Đình, TP Hà Nội', CAST(0x0000A83F00000000 AS DateTime), CAST(0x0000A8D500000000 AS DateTime), CAST(0x0000AC2D00000000 AS DateTime), CAST(450000 AS Decimal(18, 0)), N'DXD')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0003', N'Trung tâm hành chính Bình Dương', N'Trung tâm thành phố mới Bình Dương', CAST(0x0000A56C00000000 AS DateTime), CAST(0x0000A74900000000 AS DateTime), CAST(0x0000AA6000000000 AS DateTime), CAST(300000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0004', N'Royal City', N'Đường Nguyễn Trãi, TP Hồ Chí Minh', CAST(0x0000A70E00000000 AS DateTime), CAST(0x0000A7E200000000 AS DateTime), CAST(0x0000AA5200000000 AS DateTime), CAST(400000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0005', N'The Gold Mart', N'Ấp 2, Xã Tiến Thành,TX. Đông Xoài, Tỉnh Bình Phước', CAST(0x0000A4C000000000 AS DateTime), CAST(0x0000A61C00000000 AS DateTime), CAST(0x0000ABE000000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0006', N'Tòa nhà PV Index Building', N'452 Trường Chinh, P13, Quận Tân Bình, TP Hồ Chí Minh', CAST(0x0000A5BD00000000 AS DateTime), CAST(0x0000A79C00000000 AS DateTime), CAST(0x0000A96D00000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0007', N'Nhà máy Synopex Việt Nam', N'Đường Lê Trung Nghĩa, Tỉnh Vĩnh Phúc', CAST(0x0000A49A00000000 AS DateTime), CAST(0x0000A53300000000 AS DateTime), CAST(0x0000AD3B00000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0008', N'Nhà máy Sumitomo Electrics', N'Lô T2-1.2, Đường D1, Khu Công Nghệ Cao, quận 9, TP Hồ Chí Minh', CAST(0x0000A6F900000000 AS DateTime), CAST(0x0000A84700000000 AS DateTime), CAST(0x0000A90F00000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0009', N'Trung tâm điều hành thông tin di động', N'Đường Phan Văn Trị, quận Gò Vấp, TP Hồ Chí Minh', CAST(0x0000A2C400000000 AS DateTime), CAST(0x0000A58000000000 AS DateTime), CAST(0x0000AA9B00000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0010', N'Nhà máy Yamaha Motor Việt Nam', N'Đường CN1, Quận Tân Bình, TP Hồ Chí Minh', CAST(0x0000A65600000000 AS DateTime), CAST(0x0000A78500000000 AS DateTime), CAST(0x0000AA0200000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'HT')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0012', N'Nhà Hát Lớn Thành Phố', N'TP HCM', CAST(0x0000A97D015E364C AS DateTime), CAST(0x0000AAEA015E364C AS DateTime), CAST(0x0000AC58015E364C AS DateTime), CAST(500000 AS Decimal(18, 0)), N'DXD')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0013', N'Phố đi bộ Nguyễn Huệ', N'Đường Nguyễn Huệ, HCM', CAST(0x0000A96D016CEF0C AS DateTime), CAST(0x0000A97C016CEF0C AS DateTime), CAST(0x0000AB0F016D0D84 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'DXD')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0014', N'Thế Giới Di Dộng TC', N'343 Trường Chinh, quận 12,HCM', CAST(0x0000A98100FB11D4 AS DateTime), CAST(0x0000AAEE00FB11D4 AS DateTime), CAST(0x0000AC5C00FB11D4 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'DXD')
INSERT [dbo].[CongTrinh] ([maCongTrinh], [tenCongTrinh], [diaDiemXayDung], [ngayCapPhep], [ngayKhoiCong], [ngayHoanThanh], [luongCongTrinh], [trangThai]) VALUES (N'CT0015', N'Điện Máy Xanh TC', N'Tân Bình, HCM', CAST(0x0000A9810105CA5C AS DateTime), CAST(0x0000A9A00105CA5C AS DateTime), CAST(0x0000A9BE0105CA5C AS DateTime), CAST(500000 AS Decimal(18, 0)), N'DXD')
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/09/2018 21:19:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maNhanVien] [nvarchar](50) NOT NULL,
	[hoTen] [nvarchar](50) NULL,
	[ngaySinh] [datetime] NULL,
	[gioiTinh] [nvarchar](50) NULL,
	[diaChiLienHe] [nvarchar](300) NULL,
	[soDienThoai] [nvarchar](50) NULL,
	[loaiNhanVien] [nvarchar](50) NULL,
	[trangThai] [nchar](10) NULL,
	[maPhongBan] [nvarchar](50) NULL,
	[ngayBatDau] [datetime] NULL,
	[ngayKetThuc] [datetime] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maNhanVien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0001', N'Nguyễn Hồng Quang', CAST(0x00008A8700000000 AS DateTime), N'Nam ', N'Quận 12', N'0164632569', N'TPB', N'L         ', N'PB001', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0002       ', N'Huỳnh Anh Khang', CAST(0x00008BFC00000000 AS DateTime), N'Nữ', N'Quận Gò Vấp1', N'01234562581', N'NV', N'L         ', N'PB001', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0003', N'Nguyễn Minh Phúc', CAST(0x00008C1000000000 AS DateTime), N'Nữ', N'Quận 6', N'0124568595', N'NV', N'N         ', N'PB001', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0004              ', N'Lê Thị Chi', CAST(0x00008C4D00000000 AS DateTime), N'Nữ', N'Quận Tân Bình', N'0132654895', N'NV', N'L         ', N'PB002', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0005       ', N'Huỳnh Phúc Huy', CAST(0x00008C6C00000000 AS DateTime), N'Nam', N'Quận Tân Bình', N'0124584695', N'TPB', N'L         ', N'PB002', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0006', N'Trần Trung Hào', CAST(0x00008C8A00000000 AS DateTime), N'Nam', N'Quận Gò Vấp', N'0124563298', N'NV', N'L         ', N'PB002', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0007', N'Nguyễn Đình Nhật Tân', CAST(0x00008CA900000000 AS DateTime), N'Nam', N'Quận 12', N'0124545896', N'TPB', N'L         ', N'PB003', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0008', N'Đinh Thảo Vy', CAST(0x00008C9400000000 AS DateTime), N'Nam', N'Quận 4', N'0232569745', N'NV', N'L         ', N'PB003', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0009', N'Cù Hoàng An', CAST(0x00008C0400000000 AS DateTime), N'Nữ', N'Quận 6', N'0906821549', N'NV', N'L         ', N'PB003', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0010', N'Đoàn Bảo Ngọc', CAST(0x00008C7700000000 AS DateTime), N'Nam', N'Quận Phú Nhuận', N'0904856935', N'TPB', N'L         ', N'PB004', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0011', N'Trần Hữu Thịnh', CAST(0x00008CF60155DF24 AS DateTime), N'Nam ', N'Quận 7, HCM', N'0123694452', N'NV', N'L         ', N'PB004', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0012', N'Nguyễn Tiến Dũng', CAST(0x00008A12015989D0 AS DateTime), N'Nam ', N'Hà Nội', N'0215968457', N'NV', N'L         ', N'PB004', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0013', N'Hồ Ngọc Phương', CAST(0x00007B0F015A7688 AS DateTime), N'Nữ', N'Quận 5', N'0124596863', N'TPB', N'L         ', N'PB005', CAST(0x0000A85B00000000 AS DateTime), CAST(0x0000AB3500000000 AS DateTime))
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0014', N'Lê Hồ Phương Uyên', CAST(0x00008CFB014C3EB0 AS DateTime), N'Nữ', N'Quận 7', N'0125469586', N'NV', N'L         ', N'PB001', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0015', N'Lê Minh Quân', CAST(0x00008D0C00D79ED4 AS DateTime), N'Nam ', N'Nguyễn Văn Quá, Quận 12', N'0134659768', N'NV', N'L         ', N'PB005', CAST(0x0000A85B00000000 AS DateTime), CAST(0x0000AB3600000000 AS DateTime))
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0016', N'Nguyễn Văn Minh', CAST(0x0000A99500D9D5EE AS DateTime), N'Nam ', N'Quận Tân Phú', N'0164606596', N'NV', N'L         ', N'PB001', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0017', N'Nguyễn Minh Tài', CAST(0x00008FE700DD80B0 AS DateTime), N'Nam ', N'Phan Huy Ích, Gò Vấp', N'0124569632', N'NV', N'L         ', N'PB001', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0018', N'Nguyễn Quang Trường', CAST(0x00008BAF01536FB4 AS DateTime), N'Nam ', N'Quận Hóc Môn', N'0165459865', N'NV', N'L         ', N'PB001', NULL, NULL)
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0019', N'Trần Văn Trọng ', CAST(0x00008D280012762C AS DateTime), N'Nam ', N'Quận 8', N'0245125960', N'NV', N'L         ', N'PB005', CAST(0x0000A9560012762C AS DateTime), CAST(0x0000A9B10012762C AS DateTime))
INSERT [dbo].[NhanVien] ([maNhanVien], [hoTen], [ngaySinh], [gioiTinh], [diaChiLienHe], [soDienThoai], [loaiNhanVien], [trangThai], [maPhongBan], [ngayBatDau], [ngayKetThuc]) VALUES (N'NV0020', N'Nguyễn Thị Thảo Nguyên', CAST(0x00009003014DD680 AS DateTime), N'Nữ', N'Quận 10', N'0124569568', N'NV', N'L         ', N'PB003', NULL, NULL)
/****** Object:  View [dbo].[View_DanhSachNhanVien]    Script Date: 12/09/2018 21:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DanhSachNhanVien]
AS
SELECT        dbo.NhanVien.maNhanVien AS maNV, dbo.NhanVien.hoTen AS hoTenNV, dbo.NhanVien.ngaySinh AS ngaySinhNV, dbo.NhanVien.gioiTinh AS gioiTinhNV, dbo.NhanVien.diaChiLienHe AS DCNV, 
                         dbo.NhanVien.soDienThoai AS SDTNV, dbo.NhanVien.loaiNhanVien AS loaiNV, dbo.NhanVien.maPhongBan AS maPBNV, dbo.NhanVien.trangThai AS TrangThaiNV, dbo.PhongBan.tenPhongBan AS tenPBNV, 
                         dbo.PhongBan.loaiPhongBan AS loaiPBNV
FROM            dbo.NhanVien INNER JOIN
                         dbo.PhongBan ON dbo.NhanVien.maPhongBan = dbo.PhongBan.maPhongBan
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "NhanVien"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PhongBan"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 119
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DanhSachNhanVien'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DanhSachNhanVien'
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/09/2018 21:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[tenTaiKhoan] [nvarchar](50) NOT NULL,
	[matKhau] [varchar](50) NULL,
	[maNhanVien] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TaiKhoan_1] PRIMARY KEY CLUSTERED 
(
	[tenTaiKhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'An123', N'An_123', N'NV0009')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Chi123', N'Chi_123', N'NV0004                          ')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Dung123', N'Dung_123', N'NV0012')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Hao123', N'Hao_123', N'NV0006')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Huy123', N'Huy_123', N'NV0005                    ')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Khang123', N'Khang_123', N'NV0002')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Minh123', N'Minh_123', N'NV0016')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Ngoc123', N'Ngoc_123', N'NV0010')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Nguyen123', N'Nguyen_123', N'NV0020')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Phuc123', N'Phuc_123', N'NV0003')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Phuong123', N'Phuong_123', N'NV0013')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Quan123', N'Quan_123', N'NV0015')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Quang123', N'Quang_123', N'NV0001              ')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Tai123', N'Tai_123', N'NV0017')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Tan123', N'Tan_123', N'NV0007')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Thinh123', N'Thinh_123', N'NV0011')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Trong123', N'Trong_123', N'NV0019')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Truong123', N'Truong_123', N'NV0018')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Uyen123', N'Uyen_123', N'NV0014')
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [maNhanVien]) VALUES (N'Vy123', N'Vy_123', N'NV0008')
/****** Object:  Table [dbo].[PhanCong]    Script Date: 12/09/2018 21:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[maPhanCong] [int] NOT NULL,
	[maNhanVien] [nvarchar](50) NULL,
	[maCongTrinh] [nvarchar](50) NULL,
	[ngayBatDauLam] [datetime] NULL,
	[ngayKetThuc] [datetime] NULL,
	[soNgayCong] [int] NULL,
	[tienLuong] [decimal](20, 0) NULL,
	[trangThai] [nvarchar](50) NULL,
	[daTraLuong] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanCong] PRIMARY KEY CLUSTERED 
(
	[maPhanCong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PhanCong] ([maPhanCong], [maNhanVien], [maCongTrinh], [ngayBatDauLam], [ngayKetThuc], [soNgayCong], [tienLuong], [trangThai], [daTraLuong]) VALUES (1, N'NV0012', N'CT0001', CAST(0x0000A8A100000000 AS DateTime), CAST(0x0000A8C300000000 AS DateTime), 398, CAST(199000000 AS Decimal(20, 0)), N'C', N'Chưa')
INSERT [dbo].[PhanCong] ([maPhanCong], [maNhanVien], [maCongTrinh], [ngayBatDauLam], [ngayKetThuc], [soNgayCong], [tienLuong], [trangThai], [daTraLuong]) VALUES (2, N'NV0012', N'CT0002', CAST(0x0000A8A200000000 AS DateTime), CAST(0x0000A95D00000000 AS DateTime), 856, CAST(428000000 AS Decimal(20, 0)), N'C', N'Chưa')
INSERT [dbo].[PhanCong] ([maPhanCong], [maNhanVien], [maCongTrinh], [ngayBatDauLam], [ngayKetThuc], [soNgayCong], [tienLuong], [trangThai], [daTraLuong]) VALUES (3, N'NV0012', N'CT0004', CAST(0x0000A7E200000000 AS DateTime), CAST(0x0000AA5200000000 AS DateTime), 620, CAST(310000000 AS Decimal(20, 0)), N'C', N'Đã Trả Lương')
INSERT [dbo].[PhanCong] ([maPhanCong], [maNhanVien], [maCongTrinh], [ngayBatDauLam], [ngayKetThuc], [soNgayCong], [tienLuong], [trangThai], [daTraLuong]) VALUES (4, N'NV0002', N'CT0001', CAST(0x0000A8A100000000 AS DateTime), CAST(0x0000A8DE00000000 AS DateTime), 61, CAST(79800000 AS Decimal(20, 0)), N'C', N'Đã Trả Lương')
INSERT [dbo].[PhanCong] ([maPhanCong], [maNhanVien], [maCongTrinh], [ngayBatDauLam], [ngayKetThuc], [soNgayCong], [tienLuong], [trangThai], [daTraLuong]) VALUES (6, N'NV0003', N'CT0001', CAST(0x0000A8A100000000 AS DateTime), CAST(0x0000A8C000000000 AS DateTime), 31, CAST(15500000 AS Decimal(20, 0)), N'C', N'Chưa')
INSERT [dbo].[PhanCong] ([maPhanCong], [maNhanVien], [maCongTrinh], [ngayBatDauLam], [ngayKetThuc], [soNgayCong], [tienLuong], [trangThai], [daTraLuong]) VALUES (7, N'NV0016', N'CT0001', CAST(0x0000A8A100000000 AS DateTime), CAST(0x0000A8E100000000 AS DateTime), 64, CAST(79800000 AS Decimal(20, 0)), N'C', N'Chưa')
INSERT [dbo].[PhanCong] ([maPhanCong], [maNhanVien], [maCongTrinh], [ngayBatDauLam], [ngayKetThuc], [soNgayCong], [tienLuong], [trangThai], [daTraLuong]) VALUES (8, N'NV0017', N'CT0004', CAST(0x0000A8D400000000 AS DateTime), CAST(0x0000A92200000000 AS DateTime), 78, CAST(31200000 AS Decimal(20, 0)), N'X', N'Đã Trả Lương')
/****** Object:  Table [dbo].[LienHe]    Script Date: 12/09/2018 21:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[maLienHe] [int] NOT NULL,
	[email] [nvarchar](50) NULL,
	[noiDung] [nvarchar](max) NULL,
	[ngayGui] [datetime] NULL,
	[tpbPhanHoi] [nvarchar](50) NULL,
	[trangThai] [nvarchar](50) NULL,
	[maNhanVien] [nvarchar](50) NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[maLienHe] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[LienHe] ([maLienHe], [email], [noiDung], [ngayGui], [tpbPhanHoi], [trangThai], [maNhanVien]) VALUES (1, N'quangnguyen@gmail.com', N'hello admin', CAST(0x0000A9B101624F20 AS DateTime), N'ok', N'Đã Xử Lý', N'NV0002       ')
INSERT [dbo].[LienHe] ([maLienHe], [email], [noiDung], [ngayGui], [tpbPhanHoi], [trangThai], [maNhanVien]) VALUES (2, N'quangdeptrai@gmail.com', N'xin NGHỈ ', CAST(0x0000A9B100C5C100 AS DateTime), N'ok', N'Đã Xử Lý', N'NV0002       ')
INSERT [dbo].[LienHe] ([maLienHe], [email], [noiDung], [ngayGui], [tpbPhanHoi], [trangThai], [maNhanVien]) VALUES (3, N'quang12@gmail.com', N'sai bảng lương', CAST(0x0000A9B100A62B10 AS DateTime), NULL, N'Chưa Xử Lý', N'NV0015')
INSERT [dbo].[LienHe] ([maLienHe], [email], [noiDung], [ngayGui], [tpbPhanHoi], [trangThai], [maNhanVien]) VALUES (4, N'khang1@gmail.com', N'sai bảng lương', CAST(0x0000A9B100E4D353 AS DateTime), N'', N'Chưa Xử Lý', N'NV0002       ')
INSERT [dbo].[LienHe] ([maLienHe], [email], [noiDung], [ngayGui], [tpbPhanHoi], [trangThai], [maNhanVien]) VALUES (5, N'an123@gmail.com', N'xin nghỉ việc', CAST(0x0000A9B1014B0A5F AS DateTime), N'ko đc đâu bạn', N'Đã Xử Lý', N'NV0009')
/****** Object:  Table [dbo].[ChamCong_PDA]    Script Date: 12/09/2018 21:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong_PDA](
	[maChamCong] [int] NOT NULL,
	[maNhanVien] [nvarchar](50) NULL,
	[thang] [int] NULL,
	[nam] [int] NULL,
	[soNgayLam] [int] NULL,
	[soNgayNghi] [int] NULL,
	[luongThang] [decimal](18, 0) NULL,
	[daTraLuong] [nvarchar](50) NULL,
	[D1] [nvarchar](50) NULL,
	[D2] [nvarchar](10) NULL,
	[D3] [nvarchar](10) NULL,
	[D4] [nvarchar](50) NULL,
	[D5] [nvarchar](50) NULL,
	[D6] [nvarchar](50) NULL,
	[D7] [nvarchar](50) NULL,
	[D8] [nvarchar](50) NULL,
	[D9] [nvarchar](50) NULL,
	[D10] [nvarchar](50) NULL,
	[D11] [nvarchar](50) NULL,
	[D12] [nvarchar](50) NULL,
	[D13] [nvarchar](50) NULL,
	[D14] [nvarchar](50) NULL,
	[D15] [nvarchar](50) NULL,
	[D16] [nvarchar](50) NULL,
	[D17] [nvarchar](50) NULL,
	[D18] [nvarchar](50) NULL,
	[D19] [nvarchar](50) NULL,
	[D20] [nvarchar](50) NULL,
	[D21] [nvarchar](50) NULL,
	[D22] [nvarchar](50) NULL,
	[D23] [nvarchar](50) NULL,
	[D24] [nvarchar](50) NULL,
	[D25] [nvarchar](50) NULL,
	[D26] [nvarchar](50) NULL,
	[D27] [nvarchar](50) NULL,
	[D28] [nvarchar](50) NULL,
	[D29] [nvarchar](50) NULL,
	[D30] [nvarchar](50) NULL,
	[D31] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChamCong_PDA] PRIMARY KEY CLUSTERED 
(
	[maChamCong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (1, N'NV0013', 1, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (2, N'NV0013', 2, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X', N'X', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (3, N'NV0013', 3, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (4, N'NV0013', 4, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (5, N'NV0013', 5, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (6, N'NV0013', 6, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (7, N'NV0013', 7, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (8, N'NV0013', 8, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (9, N'NV0013', 9, 2018, 0, 31, CAST(0 AS Decimal(18, 0)), N'Chưa', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (10, N'NV0013', 10, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (11, N'NV0013', 11, 2018, 2, 29, CAST(1000000 AS Decimal(18, 0)), N'Chưa', N'C', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'C', N'', N'', N'', N'', N'', N'', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (12, N'NV0013', 12, 2018, 17, 14, CAST(8500000 AS Decimal(18, 0)), N'Chưa', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'K', N'C', N'C', N'K', N'C', N'C', N'C', N'C', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (13, N'NV0013', 1, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (14, N'NV0013', 2, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X', N'X', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (15, N'NV0013', 3, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (16, N'NV0013', 4, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (17, N'NV0013', 5, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (18, N'NV0013', 6, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (19, N'NV0013', 7, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (20, N'NV0013', 8, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (22, N'NV0013', 9, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (23, N'NV0013', 10, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (24, N'NV0013', 11, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (25, N'NV0013', 12, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (26, N'NV0013', 1, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (27, N'NV0013', 2, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X', N'X', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (28, N'NV0013', 3, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (29, N'NV0013', 4, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (30, N'NV0013', 5, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (31, N'NV0013', 6, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (32, N'NV0013', 7, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (33, N'NV0013', 8, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (34, N'NV0013', 9, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (35, N'NV0013', 10, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (36, N'NV0013', 11, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (37, N'NV0013', 12, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (38, N'NV0015', 1, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (39, N'NV0015', 2, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X', N'X', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (40, N'NV0015', 3, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (41, N'NV0015', 4, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (42, N'NV0015', 5, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (43, N'NV0015', 6, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (44, N'NV0015', 7, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (45, N'NV0015', 8, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (46, N'NV0015', 9, 2018, 2, 29, CAST(1000000 AS Decimal(18, 0)), N'Chưa', N'C', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'C', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (47, N'NV0015', 10, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (48, N'NV0015', 11, 2018, 9, 22, CAST(4500000 AS Decimal(18, 0)), N'Chưa', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (49, N'NV0015', 12, 2018, 15, 16, CAST(7500000 AS Decimal(18, 0)), N'Chưa', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'K', N'K', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'K', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (50, N'NV0015', 1, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (51, N'NV0015', 2, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X', N'X', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (52, N'NV0015', 3, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (53, N'NV0015', 4, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (54, N'NV0015', 5, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (55, N'NV0015', 6, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (56, N'NV0015', 7, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (57, N'NV0015', 8, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (58, N'NV0015', 9, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (59, N'NV0015', 10, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (60, N'NV0015', 11, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (61, N'NV0015', 12, 2019, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (62, N'NV0015', 1, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (63, N'NV0015', 2, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X', N'X', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (64, N'NV0015', 3, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (65, N'NV0015', 4, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (66, N'NV0015', 5, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (67, N'NV0015', 6, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (68, N'NV0015', 7, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (69, N'NV0015', 8, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (70, N'NV0015', 9, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (71, N'NV0015', 10, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (72, N'NV0015', 11, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (73, N'NV0015', 12, 2020, 0, 0, CAST(0 AS Decimal(18, 0)), N'Chưa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (74, N'NV0019', 10, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), N'Đã Trả Lương', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (75, N'NV0019', 11, 2018, 30, 0, CAST(15000000 AS Decimal(18, 0)), N'Đã Trả Lương', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'X')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (76, N'NV0019', 12, 2018, 15, 16, CAST(7500000 AS Decimal(18, 0)), N'Đã Trả Lương', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'K', N'K', N'K', N'C', N'C', N'C', N'C', N'C', N'K', N'C', N'C', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[ChamCong_PDA] ([maChamCong], [maNhanVien], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [daTraLuong], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (77, N'NV0019', 9, 2018, 0, 30, CAST(0 AS Decimal(18, 0)), N'Đã Trả Lương', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'X')
/****** Object:  Table [dbo].[ChamCong]    Script Date: 12/09/2018 21:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[maChamCong] [int] NOT NULL,
	[maPhanCong] [int] NULL,
	[thang] [int] NULL,
	[nam] [int] NULL,
	[soNgayLam] [int] NULL,
	[soNgayNghi] [int] NULL,
	[luongThang] [decimal](18, 0) NULL,
	[D1] [nvarchar](50) NULL,
	[D2] [nvarchar](50) NULL,
	[D3] [nvarchar](50) NULL,
	[D4] [nvarchar](50) NULL,
	[D5] [nvarchar](50) NULL,
	[D6] [nvarchar](50) NULL,
	[D7] [nvarchar](50) NULL,
	[D8] [nvarchar](50) NULL,
	[D9] [nvarchar](50) NULL,
	[D10] [nvarchar](50) NULL,
	[D11] [nvarchar](50) NULL,
	[D12] [nvarchar](50) NULL,
	[D13] [nvarchar](50) NULL,
	[D14] [nvarchar](50) NULL,
	[D15] [nvarchar](50) NULL,
	[D16] [nvarchar](50) NULL,
	[D17] [nvarchar](50) NULL,
	[D18] [nvarchar](50) NULL,
	[D19] [nvarchar](50) NULL,
	[D20] [nvarchar](50) NULL,
	[D21] [nvarchar](50) NULL,
	[D22] [nvarchar](50) NULL,
	[D23] [nvarchar](50) NULL,
	[D24] [nvarchar](50) NULL,
	[D25] [nvarchar](50) NULL,
	[D26] [nvarchar](50) NULL,
	[D27] [nvarchar](50) NULL,
	[D28] [nvarchar](50) NULL,
	[D29] [nvarchar](50) NULL,
	[D30] [nvarchar](50) NULL,
	[D31] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[maChamCong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (1, 4, 3, 2018, 22, 9, CAST(4400000 AS Decimal(18, 0)), N'K', N'C', N'C', N'C', N'C', N'K', N'CN', N'C', N'C', N'C', N'C', N'C', N'C', N'CN', N'C', N'C', N'C', N'C', N'C', N'C', N'CN', N'C', N'C', N'C', N'NL', N'KP', N'CP', N'CN', N'C', N'C', N'C')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (2, 7, 3, 2018, 21, 10, CAST(4200000 AS Decimal(18, 0)), N'C', N'C', N'C', N'NL', N'C', N'C', N'CN', N'C', N'C', N'C', N'C', N'C', N'K', N'CN', N'C', N'C', N'C', N'C', N'C', N'C', N'CN', N'KHÔNG PHÉP', N'C', N'C', N'NL', N'KP', N'CP', N'CN', N'C', N'C', N'C')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (3, 4, 4, 2018, 21, 7, CAST(10500000 AS Decimal(18, 0)), N'c', N'k', N'k', N'k', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'Không phép', N'C', N'C', N'NL', N'KP', N'CP', N'C', N'C', N'C', N'X')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (4, 1, 1, 2018, 24, 7, CAST(12000000 AS Decimal(18, 0)), N'C', N'C', N'C', N'NL', N'C', N'C', N'CN', N'C', N'C', N'C', N'C', N'KP', N'C', N'CN', N'K', N'C', N'C', N'C', N'C', N'C', N'CN', N'C', N'C', N'C', N'C', N'C', N'C', N'CN', N'C', N'C', N'C')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (5, 6, 1, 2018, 23, 8, CAST(4600000 AS Decimal(18, 0)), N'C', N'C', N'C', N'NL', N'C', N'C', N'CN', N'K', N'C', N'C', N'C', N'C', N'C', N'CN', N'K', N'C', N'K', N'C', N'C', N'C', N'CN', N'C', N'C', N'C', N'C', N'C', N'C', N'CN', N'C', N'C', N'C')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (6, 8, 5, 2018, 30, 1, CAST(12000000 AS Decimal(18, 0)), N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'K', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (7, 8, 6, 2018, 29, 1, CAST(11600000 AS Decimal(18, 0)), N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'K', N'K', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'X')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (8, 8, 7, 2018, 30, 1, CAST(12000000 AS Decimal(18, 0)), N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'K', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C', N'C')
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (9, 4, 5, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (10, 7, 4, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChamCong] ([maChamCong], [maPhanCong], [thang], [nam], [soNgayLam], [soNgayNghi], [luongThang], [D1], [D2], [D3], [D4], [D5], [D6], [D7], [D8], [D9], [D10], [D11], [D12], [D13], [D14], [D15], [D16], [D17], [D18], [D19], [D20], [D21], [D22], [D23], [D24], [D25], [D26], [D27], [D28], [D29], [D30], [D31]) VALUES (11, 7, 5, 2018, 0, 0, CAST(0 AS Decimal(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  ForeignKey [FK_NhanVien_PhongBan]    Script Date: 12/09/2018 21:19:42 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([maPhongBan])
REFERENCES [dbo].[PhongBan] ([maPhongBan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
/****** Object:  ForeignKey [FK_TaiKhoan_NhanVien]    Script Date: 12/09/2018 21:19:43 ******/
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
/****** Object:  ForeignKey [FK_PhanCong_CongTrinh]    Script Date: 12/09/2018 21:19:43 ******/
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_CongTrinh] FOREIGN KEY([maCongTrinh])
REFERENCES [dbo].[CongTrinh] ([maCongTrinh])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_CongTrinh]
GO
/****** Object:  ForeignKey [FK_PhanCong_NhanVien]    Script Date: 12/09/2018 21:19:43 ******/
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_NhanVien] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_NhanVien]
GO
/****** Object:  ForeignKey [FK_LienHe_NhanVien]    Script Date: 12/09/2018 21:19:43 ******/
ALTER TABLE [dbo].[LienHe]  WITH CHECK ADD  CONSTRAINT [FK_LienHe_NhanVien] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[LienHe] CHECK CONSTRAINT [FK_LienHe_NhanVien]
GO
/****** Object:  ForeignKey [FK_ChamCong_PDA_NhanVien]    Script Date: 12/09/2018 21:19:43 ******/
ALTER TABLE [dbo].[ChamCong_PDA]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_PDA_NhanVien] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[ChamCong_PDA] CHECK CONSTRAINT [FK_ChamCong_PDA_NhanVien]
GO
/****** Object:  ForeignKey [FK_ChamCong_PhanCong]    Script Date: 12/09/2018 21:19:43 ******/
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_PhanCong] FOREIGN KEY([maPhanCong])
REFERENCES [dbo].[PhanCong] ([maPhanCong])
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK_ChamCong_PhanCong]
GO
