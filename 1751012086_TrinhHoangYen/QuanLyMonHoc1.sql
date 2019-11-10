USE [master]
GO


/****** Object:  Database [QuanLyMonHoc1]    Script Date: 19-Aug-19 7:43:06 PM ******/
CREATE DATABASE [QuanLyMonHoc1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyMonHoc1', FILENAME = N'C:\SQLServer\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyMonHoc1.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyMonHoc1_log', FILENAME = N'C:\SQLServer\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyMonHoc1_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyMonHoc1] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyMonHoc1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyMonHoc1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyMonHoc1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyMonHoc1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyMonHoc1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyMonHoc1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyMonHoc1] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyMonHoc1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyMonHoc1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyMonHoc1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyMonHoc1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyMonHoc1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyMonHoc1', N'ON'
GO
USE [QuanLyMonHoc1]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GiangVien](
	[maGV] [varchar](10) NOT NULL,
	[hoGV] [nvarchar](50) NOT NULL,
	[tenGV] [nvarchar](50) NOT NULL,
	[ngayBatDau] [datetime] NOT NULL,
	[ngaySinh] [datetime] NOT NULL,
	[gioiTinh] [nvarchar](10) NOT NULL,
	[soDienThoai] [nvarchar](10) NOT NULL,
	[maKhoa] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Khoa](
	[maKhoa] [varchar](10) NOT NULL,
	[tenKhoa] [nvarchar](100) NOT NULL,
	[ngayThanhLap] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lop](
	[maLop] [varchar](10) NOT NULL,
	[tenLop] [nvarchar](50) NOT NULL,
	[maKhoa] [varchar](10) NOT NULL,
	[khoaHoc] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MonHoc](
	[maMH] [varchar](10) NOT NULL,
	[tenMH] [nvarchar](100) NOT NULL,
	[soTinChi] [int] NOT NULL,
	[maGV] [varchar](10) NOT NULL,
	[maKhoa] [varchar](10) NOT NULL,
	[ngayBatDau] [datetime] NOT NULL,
	[ngayKetThuc] [datetime] NOT NULL,
	[noiDung] [nvarchar](200) NOT NULL,
	[siSo] [int] NOT NULL,
	[tinhTrang] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[maMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SinhVien](
	[mssv] [varchar](10) NOT NULL,
	[hoSV] [nvarchar](50) NOT NULL,
	[tenSV] [nvarchar](50) NOT NULL,
	[ngaySinh] [datetime] NOT NULL,
	[gioiTinh] [nvarchar](10) NOT NULL,
	[soDienThoai] [nvarchar](10) NOT NULL,
	[maLop] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mssv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SinhVien_MonHoc]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SinhVien_MonHoc](
	[mssv] [varchar](10) NOT NULL,
	[maMH] [varchar](10) NOT NULL,
	[diemThi] [float] NOT NULL,
	[ngayDangKy] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[mssv] ASC,
	[maMH] ASC,
	[ngayDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[tenTK] [varchar](50) NOT NULL,
	[matKhau] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV001', N'Lê', N'Quốc Hoàng', CAST(N'2017-11-15 00:00:00.000' AS DateTime), CAST(N'1999-11-22 00:00:00.000' AS DateTime), N'Nam', N'0947825365', N'CNTT')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV002', N'Trần', N'Mai Hữu Anh Quang', CAST(N'2008-12-25 00:00:00.000' AS DateTime), CAST(N'1999-02-17 00:00:00.000' AS DateTime), N'Nam', N'096965443', N'CNTT')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV003', N'Nguyễn', N'Minh Quang', CAST(N'2017-01-8 00:00:00.000' AS DateTime), CAST(N'1999-08-20 00:00:00.000' AS DateTime), N'Nam', N'0915875443', N'CNTT')

INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV010', N'Lê', N'Hoài Thu', CAST(N'2001-01-18 00:00:00.000' AS DateTime), CAST(N'1997-08-20 00:00:00.000' AS DateTime), N'Nữ', N'0915875443', N'KT')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV008', N'Trần', N'Quốc Anh', CAST(N'2005-02-14 00:00:00.000' AS DateTime), CAST(N'1995-08-20 00:00:00.000' AS DateTime), N'Nam', N'0915875443', N'LA')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV011', N'Nguyễn', N'Mai Lan Trinh', CAST(N'2011-03-20 00:00:00.000' AS DateTime), CAST(N'1993-08-20 00:00:00.000' AS DateTime), N'Nữ', N'0915875443', N'NN')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV005', N'Lê', N'Thị Thảo', CAST(N'2019-04-07 00:00:00.000' AS DateTime), CAST(N'1994-08-20 00:00:00.000' AS DateTime), N'Nữ', N'0915875443', N'XH')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV012', N'Trần', N'Thị Ngọc', CAST(N'2017-05-19 00:00:00.000' AS DateTime), CAST(N'1991-08-20 00:00:00.000' AS DateTime), N'Nữ', N'0915875443', N'KT')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV007', N'Nguyễn', N'Hữu Quốc', CAST(N'1998-06-15 00:00:00.000' AS DateTime), CAST(N'1980-08-20 00:00:00.000' AS DateTime), N'Nam', N'0915875443', N'LA')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV004', N'Lê', N'Hoàng Như', CAST(N'2015-07-11 00:00:00.000' AS DateTime), CAST(N'1990-08-20 00:00:00.000' AS DateTime), N'Nữ', N'0915875443', N'XH')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV006', N'Trần', N'Thị Thúy Kiều', CAST(N'2003-08-31 00:00:00.000' AS DateTime), CAST(N'1987-08-20 00:00:00.000' AS DateTime), N'Nữ', N'0915875443', N'LA')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV012', N'Nguyễn', N'Trần Thủy Tiên', CAST(N'2007-09-05 00:00:00.000' AS DateTime), CAST(N'2000-08-20 00:00:00.000' AS DateTime), N'Nữ', N'0915875443', N'NN')
INSERT [dbo].[GiangVien] ([maGV], [hoGV], [tenGV], [ngayBatDau], [ngaySinh], [gioiTinh], [soDienThoai], [maKhoa]) VALUES (N'GV013', N'Đỗ', N'Trọng Nghĩa', CAST(N'2016-10-28 00:00:00.000' AS DateTime), CAST(N'1999-08-20 00:00:00.000' AS DateTime), N'Nam', N'0915875443', N'KT')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'CNTT', N'Công nghệ thông tin', N'10-5-2010')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'KT', N'Kế toán', N'1-23-2010')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'NN', N'Ngoại ngữ', N'9-8-1997')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'QT', N'Quản trị kinh doanh', N'12-5-2010')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'SH', N'Công nghệ sinh học', N'6-15-1975')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'TC', N'Tài chính ngân hàng', N'7-30-2001')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'XH', N'Xã hội học', N'4-22-2003')
INSERT [dbo].[Khoa] ([maKhoa], [tenKhoa], [ngayThanhLap]) VALUES (N'LA', N'Luật', N'3-25-2003')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'TH71', N'DH17TH01', N'CNTT', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'TH72', N'DH17TH02', N'CNTT', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'TH73', N'DH17TH03', N'CNTT', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'TH74', N'DH17TH04', N'CNTT', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'TH75', N'DH17TH05', N'CNTT', N'2017-2020')

INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'TK71', N'DH17TK05', N'CNTT', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'XH71', N'XHH01', N'XH', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'XH72', N'XHH02', N'XH', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'LA71', N'LKT01', N'LA', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'LA81', N'LXH01', N'LA', N'2018-2021')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'KT71', N'KT01', N'KT', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'KT72', N'KT02', N'KT', N'2017-2020')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'NNA81', N'NN18NNA01', N'NN', N'2018-2021')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'NNA82', N'NN18NNA02', N'NN', N'2018-2021')
INSERT [dbo].[Lop] ([maLop], [tenLop], [maKhoa], [khoaHoc]) VALUES (N'NNT81', N'NN18NNT01', N'NN', N'2018-2021')

INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'NK81', N'Tiếng anh nâng cao 1', 2, N'GV011', N'NN', CAST(N'2019-10-01 00:00:00.000' AS DateTime), CAST(N'2020-02-20 00:00:00.000' AS DateTime), N'MyElt 1', 100, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'NK82', N'Tiếng anh nâng cao 2', 2, N'GV012', N'NN', CAST(N'2019-10-02 00:00:00.000' AS DateTime), CAST(N'2020-02-21 00:00:00.000' AS DateTime), N'MyElt 2', 100, 1)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'NK83', N'Tiếng anh nâng cao 3', 2, N'GV011', N'NN', CAST(N'2019-10-03 00:00:00.000' AS DateTime), CAST(N'2020-02-22 00:00:00.000' AS DateTime), N'MyElt 3', 100, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'NK84', N'Tiếng anh nâng cao 4', 2, N'GV012', N'NN', CAST(N'2019-10-04 00:00:00.000' AS DateTime), CAST(N'2020-02-23 00:00:00.000' AS DateTime), N'MyElt 4', 100, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'NK85', N'Tiếng anh nâng cao 5', 2, N'GV011', N'NN', CAST(N'2019-10-05 00:00:00.000' AS DateTime), CAST(N'2020-02-24 00:00:00.000' AS DateTime), N'MyElt 5', 100, 1)

INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'POLI2303', N'Pháp luật đại cương', 2, N'GV001', N'LA', CAST(N'2019-09-11 00:00:00.000' AS DateTime), CAST(N'2020-12-01 00:00:00.000' AS DateTime), N'Luật cơ bản của công dân', 100, 1)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'XHH2304', N'Triết học', 2, N'GV002', N'XH', CAST(N'2019-09-12 00:00:00.000' AS DateTime), CAST(N'2019-11-13 00:00:00.000' AS DateTime), N'Xã hội chủ nghĩa', 150, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'XHH2305', N'Chủ nghĩa Mac Lenin 1', 2, N'GV003', N'XH', CAST(N'2019-09-13 00:00:00.000' AS DateTime), CAST(N'2019-12-02 00:00:00.000' AS DateTime), N'Xã hội chủ nghĩa và tư tưởng Mac', 150, 1)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'XHH2306', N'Chủ nghĩa Mac Lenin 2', 3, N'GV001', N'XH', CAST(N'2019-09-14 00:00:00.000' AS DateTime), CAST(N'2019-12-03 00:00:00.000' AS DateTime), N'Lenin', 90, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'XHH2307', N'Chủ nghĩa Mac Lenin 3', 2, N'GV002', N'XH', CAST(N'2019-09-15 00:00:00.000' AS DateTime), CAST(N'2019-12-04 00:00:00.000' AS DateTime), N'Bác Hồ tiếp cận chủ nghĩa Mac Lenin', 100, 1)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'POLI2308', N'Giáo dục công dân', 3, N'GV003', N'LA', CAST(N'2019-09-16 00:00:00.000' AS DateTime), CAST(N'2019-12-05 00:00:00.000' AS DateTime), N'', 120, 1)

INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'CS18jv09', N'Lập trình java', 4, N'GV002', N'CNTT', CAST(N'2019-09-20 00:00:00.000' AS DateTime), CAST(N'2019-11-13 00:00:00.000' AS DateTime), N'Lập trình java căn bản', 50, 1)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'itec2411', N'Nhập môn lập trình', 4, N'GV003', N'CNTT', CAST(N'2019-09-25 00:00:00.000' AS DateTime), CAST(N'2019-12-13 00:00:00.000' AS DateTime), N'Lập trình C++ cơ bản', 100, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'itec2403', N'Cơ sở lập tình', 4, N'GV001', N'CNTT', CAST(N'2017-09-20 00:00:00.000' AS DateTime), CAST(N'2017-11-13 00:00:00.000' AS DateTime), N'Nhập môn lập trình', 70, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'itec2401', N'Hệ điều hành', 4, N'GV001', N'CNTT', CAST(N'2018-09-20 00:00:00.000' AS DateTime), CAST(N'2018-11-13 00:00:00.000' AS DateTime), N'', 50, 1)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'itec2402', N'Mạng Máy Tính', 4, N'GV003', N'CNTT', CAST(N'2019-09-20 00:00:00.000' AS DateTime), CAST(N'2019-11-13 00:00:00.000' AS DateTime), N'Nhập môn mạgn máy tính', 110, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'ITEC3401', N'Xử lý ảnh', 3, N'GV002', N'CNTT', CAST(N'2019-09-27 00:00:00.000' AS DateTime), CAST(N'2019-11-01 00:00:00.000' AS DateTime), N'Đồ họa máy tính', 100, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'ITEC3402', N'Cơ sở dữ liệu nâng cao', 3, N'GV001', N'CNTT', CAST(N'2019-09-29 00:00:00.000' AS DateTime), CAST(N'2019-11-01 00:00:00.000' AS DateTime), N'Cơ sở dữ liệu, sql Server', 100, 1)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'ITEC3403', N'Kỹ thuật lập trình', 4, N'GV003', N'CNTT', CAST(N'2019-09-15 00:00:00.000' AS DateTime), CAST(N'2020-01-21 00:00:00.000' AS DateTime), N'C++, mảng, con trỏ, struct, class', 100, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'ITEC3404', N'Ứng dụng web', 4, N'GV001', N'CNTT', CAST(N'2019-09-17 00:00:00.000' AS DateTime), CAST(N'2020-01-25 00:00:00.000' AS DateTime), N'HTML, CSS, jquery, javascript', 100, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'ITEC4403', N'Quản trị mạng', 3, N'GV002', N'CNTT', CAST(N'2019-09-18 00:00:00.000' AS DateTime), CAST(N'2019-10-30 00:00:00.000' AS DateTime), N'Mạng máy tính nâng cao', 50, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'ITEC4415', N'Kiểm thử phần mềm', 3, N'GV003', N'CNTT', CAST(N'2019-09-17 00:00:00.000' AS DateTime), CAST(N'2019-10-28 00:00:00.000' AS DateTime), N'Tester', 50, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'POLI2301', N'Ðường lối CM của Ðảng CSVN', 3, N'GV002', N'XH', CAST(N'2019-09-29 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), N'Tiếp nối tư tưởng HCM', 80, 0)
INSERT [dbo].[MonHoc] ([maMH], [tenMH], [soTinChi], [maGV], [maKhoa], [ngayBatDau], [ngayKetThuc], [noiDung], [siSo], [tinhTrang]) VALUES (N'POLI2302', N'Tư tưởng Hồ Chí Minh', 3, N'GV003', N'XH', CAST(N'2019-09-29 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), N'Tiếp nối tư tưởng HCM', 80, 1)
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010005', N'Trần', N'Nguyễn Ánh', CAST(N'1999-11-19 00:00:00.000' AS DateTime), N'Nữ', N'0852798583', N'TH73')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010046', N'Nguyễn', N'Hoàng Huy', CAST(N'1999-11-19 00:00:00.000' AS DateTime), N'Nam', N'0982788753', N'TH72')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010062', N'Phan', N'Anh Khoa', CAST(N'1999-11-19 00:00:00.000' AS DateTime), N'Nam', N'0927788753', N'TH72')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010072', N'Trịnh', N'Minh Linh', CAST(N'1999-11-19 00:00:00.000' AS DateTime), N'Nam', N'0982748903', N'TH73')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010121', N'Hoàng', N'Thị Quyên', CAST(N'1999-11-19 00:00:00.000' AS DateTime), N'Nữ', N'0121798583', N'TH74')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010162', N'Phạm', N'Hổ Toàn', CAST(N'1999-01-01 00:00:00.000' AS DateTime), N'Nam', N'0328218204', N'TH71')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010167', N'Nguyễn', N'Thị Triệu', CAST(N'1999-11-19 00:00:00.000' AS DateTime), N'Nữ', N'0988798583', N'TH72')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751010177', N'Nguyễn', N'Thanh Tú', CAST(N'1999-09-29 00:00:00.000' AS DateTime), N'Nam', N'0924345655', N'TH72')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751012033', N'Võ', N'Thị Thanh Kiều', CAST(N'1999-11-19 00:00:00.000' AS DateTime), N'Nữ', N'0782798583', N'TH75')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751012049', N'Hoàng', N'Đức Nhật', CAST(N'1999-11-24 00:00:00.000' AS DateTime), N'Nam', N'0869943265', N'TH75')
INSERT [dbo].[SinhVien] ([mssv], [hoSV], [tenSV], [ngaySinh], [gioiTinh], [soDienThoai], [maLop]) VALUES (N'1751012086', N'Trịnh', N'Hoàng Yến', CAST(N'1999-12-06 00:00:00.000' AS DateTime), N'Nữ', N'0912839740', N'TH75')

INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010046', N'ITEC4403', 0, CAST(N'2019-08-22 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010062', N'itec2402', 6, CAST(N'2019-08-27 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010162', N'POLI2302', 8, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010177', N'POLI2302', 7, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751012049', N'ITEC3402', 0, CAST(N'2019-08-25 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751012049', N'POLI2302', 8, CAST(N'2019-08-24 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751012086', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751012049', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010177', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751012086', N'POLI2301', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))

INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010177', N'CS18jv09', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751012086', N'CS18jv09', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751012049', N'CS18jv09', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010046', N'CS18jv09', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010162', N'CS18jv09', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010062', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010046', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010005', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010167', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010072', N'ITEC3402', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))

INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010121', N'NK83', 0, CAST(N'2019-08-15 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010167', N'NK83', 0, CAST(N'2019-08-17 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010162', N'NK83', 0, CAST(N'2019-08-20 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010177', N'NK83', 0, CAST(N'2019-08-15 00:00:00.000' AS DateTime))
INSERT [dbo].[SinhVien_MonHoc] ([mssv], [maMH], [diemThi], [ngayDangKy]) VALUES (N'1751010046', N'NK83', 0, CAST(N'2019-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[TaiKhoan] ([tenTK], [matKhau]) VALUES (N'1', N'1')
INSERT [dbo].[TaiKhoan] ([tenTK], [matKhau]) VALUES (N'trhgyen612', N'123')
INSERT [dbo].[TaiKhoan] ([tenTK], [matKhau]) VALUES (N'yen612', N'123')
ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[Khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[Khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[Khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[Khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD FOREIGN KEY([maGV])
REFERENCES [dbo].[GiangVien] ([maGV])
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD FOREIGN KEY([maGV])
REFERENCES [dbo].[GiangVien] ([maGV])
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[Khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[Khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([maLop])
REFERENCES [dbo].[Lop] ([maLop])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([maLop])
REFERENCES [dbo].[Lop] ([maLop])
GO
ALTER TABLE [dbo].[SinhVien_MonHoc]  WITH CHECK ADD FOREIGN KEY([maMH])
REFERENCES [dbo].[MonHoc] ([maMH])
GO
ALTER TABLE [dbo].[SinhVien_MonHoc]  WITH CHECK ADD FOREIGN KEY([maMH])
REFERENCES [dbo].[MonHoc] ([maMH])
GO
ALTER TABLE [dbo].[SinhVien_MonHoc]  WITH CHECK ADD FOREIGN KEY([mssv])
REFERENCES [dbo].[SinhVien] ([mssv])
GO
ALTER TABLE [dbo].[SinhVien_MonHoc]  WITH CHECK ADD FOREIGN KEY([mssv])
REFERENCES [dbo].[SinhVien] ([mssv])
GO
/****** Object:  StoredProcedure [dbo].[dangKyMonHoc]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--đăng ký môn học
CREATE PROC [dbo].[dangKyMonHoc]
@maMH VARCHAR(10), @mssv VARCHAR(10)
AS
BEGIN
	INSERT dbo.SinhVien_MonHoc( mssv ,maMH ,diemThi ,ngayDangKy)
	VALUES  ( @mssv ,  @maMH , 0.0 ,  GETDATE())
END


GO
/****** Object:  StoredProcedure [dbo].[DangNhap]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--tạo parameter mới dùng cho form Đăng nhập
CREATE PROC [dbo].[DangNhap]
@tenTK VARCHAR(50), @matKhau NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE tenTK = @tenTK AND matKhau = @matKhau
END


GO
/****** Object:  StoredProcedure [dbo].[layGVBangMaGV]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--lấy bảng GiangVien
CREATE PROC [dbo].[layGVBangMaGV]
@maGV VARCHAR(10)
AS
BEGIN
	SELECT * FROM dbo.GiangVien WHERE maGV = @maGV
END
	SELECT * FROM dbo.GiangVien WHERE maGV = N'' OR  1=1--


GO
/****** Object:  StoredProcedure [dbo].[layKhoaBangMaKhoa]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--lấy bảng Khoa
CREATE PROC [dbo].[layKhoaBangMaKhoa]
@maKhoa VARCHAR(10)
AS
BEGIN
	SELECT * FROM dbo.Khoa WHERE maKhoa = @maKhoa
END
	SELECT * FROM dbo.Khoa WHERE maKhoa= N'' OR 1=1--


GO
/****** Object:  StoredProcedure [dbo].[layLopBangMaLop]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--lấy bảng Lop
CREATE PROC [dbo].[layLopBangMaLop]
@maLop VARCHAR(10)
AS
BEGIN
	SELECT * FROM dbo.Lop WHERE maLop = @maLop
END
	SELECT * FROM dbo.Lop WHERE  maLop = N'' OR 1=1--


GO
/****** Object:  StoredProcedure [dbo].[layMHBangMaMH]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--lấy bảng MonHoc
CREATE PROC [dbo].[layMHBangMaMH]
@maMH VARCHAR(10)
AS
BEGIN
	SELECT * FROM dbo.MonHoc WHERE maMH = @maMH
END
	SELECT * FROM dbo.MonHoc WHERE maMH = N'' OR 1=1--


GO
/****** Object:  StoredProcedure [dbo].[laySVBangMaSV]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--lấy bảng SinhVien
CREATE PROC [dbo].[laySVBangMaSV]
@maSV VARCHAR(10)
AS
BEGIN
	SELECT * FROM dbo.SinhVien WHERE mssv = @maSV
END

SELECT * FROM dbo.SinhVien WHERE mssv = N'' OR 1=1--


GO
/****** Object:  StoredProcedure [dbo].[layTaiKhoanBangTenTK]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--lấy bảng TaiKhoan
CREATE PROC [dbo].[layTaiKhoanBangTenTK]
@tenTK VARCHAR(50)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE tenTK = @tenTK
END	
SELECT * FROM dbo.TaiKhoan WHERE tenTK = N'' OR 1=1--


GO
/****** Object:  StoredProcedure [dbo].[themKhoa]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--thêm khoa
CREATE PROC [dbo].[themKhoa]
@maKhoa VARCHAR(10) , @tenKhoa NVARCHAR(100) , @nam VARCHAR(10)
AS
BEGIN
	INSERT dbo.Khoa( maKhoa , tenKhoa , ngayThanhLap )
	VALUES  ( @maKhoa , @tenKhoa ,  @nam)
END


GO
/****** Object:  StoredProcedure [dbo].[themLop]    Script Date: 19-Aug-19 7:43:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[themLop] @maLop VARCHAR(10) , @tenLop NVARCHAR(50) , @maKhoa VARCHAR(10), @khoa NVARCHAR(10)
AS
BEGIN
	INSERT dbo.Lop( maLop, tenLop, maKhoa, khoaHoc )
	VALUES  ( @maLop, @tenLop , @maKhoa, @khoa)
END


GO
USE [master]
GO
ALTER DATABASE [QuanLyMonHoc1] SET  READ_WRITE 
GO
