USE [QuanLyGiaoVien]
GO
/****** Object:  Table [dbo].[BangLuong]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangLuong](
	[LuongID] [int] IDENTITY(1,1) NOT NULL,
	[GiangVienID] [int] NULL,
	[TienThanhToan] [decimal](18, 2) NULL,
	[NgayThanhToan] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[LuongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangTamUng]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangTamUng](
	[TamUngID] [int] IDENTITY(1,1) NOT NULL,
	[GiangVienID] [int] NULL,
	[SoTienTamUng] [decimal](18, 2) NULL,
	[NgayTamUng] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TamUngID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucDanh]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucDanh](
	[ChucDanhID] [int] IDENTITY(1,1) NOT NULL,
	[TenChucDanh] [nvarchar](50) NULL,
	[LoaiChucDanh] [nvarchar](20) NULL,
	[GiaTienDay] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ChucDanhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemDanhBuoiHoc]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanhBuoiHoc](
	[DiemDanhID] [int] IDENTITY(1,1) NOT NULL,
	[TKBID] [int] NULL,
	[GiangVienID] [int] NULL,
	[NgayDiemDanh] [date] NULL,
	[TrangThai] [bit] NOT NULL,
	[GhiChu] [nvarchar](500) NULL,
	[DaTamUng] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DiemDanhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[GiangVienID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](15) NULL,
	[HocHam] [nvarchar](50) NULL,
	[HocVi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[GiangVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVienMonHoc]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVienMonHoc](
	[GiangVienID] [int] NOT NULL,
	[MonHocID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GiangVienID] ASC,
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeSo]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeSo](
	[HeSoID] [int] IDENTITY(1,1) NOT NULL,
	[SiSoTu] [int] NULL,
	[SiSoDen] [int] NULL,
	[HeSo] [decimal](3, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[HeSoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[LopID] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](100) NULL,
	[SiSo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopMonHoc]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopMonHoc](
	[LopID] [int] NOT NULL,
	[MonHocID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LopID] ASC,
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MonHocID] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](100) NULL,
	[SoTinChi] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoanID] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](256) NULL,
	[GiangVienID] [int] NULL,
	[VaiTro] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TaiKhoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThoiKhoaBieu]    Script Date: 16/11/2024 3:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThoiKhoaBieu](
	[TKBID] [int] IDENTITY(1,1) NOT NULL,
	[LopID] [int] NULL,
	[MonHocID] [int] NULL,
	[GiangVienID] [int] NULL,
	[NgayHoc] [date] NULL,
	[CaHoc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TKBID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChucDanh] ON 

INSERT [dbo].[ChucDanh] ([ChucDanhID], [TenChucDanh], [LoaiChucDanh], [GiaTienDay]) VALUES (1, N'Tú Tài', N'Học Vị', CAST(150000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChucDanh] ([ChucDanhID], [TenChucDanh], [LoaiChucDanh], [GiaTienDay]) VALUES (2, N'Cử Nhân, Kỹ sử', N'Học Vị', CAST(160000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChucDanh] ([ChucDanhID], [TenChucDanh], [LoaiChucDanh], [GiaTienDay]) VALUES (3, N'Thạc Sĩ', N'Học Vị', CAST(170000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChucDanh] ([ChucDanhID], [TenChucDanh], [LoaiChucDanh], [GiaTienDay]) VALUES (4, N'Tiến Sĩ', N'Học Vị', CAST(180000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChucDanh] ([ChucDanhID], [TenChucDanh], [LoaiChucDanh], [GiaTienDay]) VALUES (5, N'Phó Giáo Sư', N'Học Hàm', CAST(170000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChucDanh] ([ChucDanhID], [TenChucDanh], [LoaiChucDanh], [GiaTienDay]) VALUES (6, N'Giáo Sư', N'Học Hàm', CAST(200000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[ChucDanh] OFF
GO
SET IDENTITY_INSERT [dbo].[GiangVien] ON 

INSERT [dbo].[GiangVien] ([GiangVienID], [HoTen], [Email], [Phone], [HocHam], [HocVi]) VALUES (2, N'Nguyễn Thị Quỳnh', N'Quynh2308@gmail.com', N'0364821567', N'Thạc Sĩ', N'Phó Giáo Sư')
INSERT [dbo].[GiangVien] ([GiangVienID], [HoTen], [Email], [Phone], [HocHam], [HocVi]) VALUES (1002, N'Bùi Ngọc Quân', N'Quan@gmail.com', N'0867993203', N'Thạc Sĩ', N'Phó Giáo Sư')
INSERT [dbo].[GiangVien] ([GiangVienID], [HoTen], [Email], [Phone], [HocHam], [HocVi]) VALUES (2004, N'Phạm Ngọc Nam', N'Nam@gmail.com', N'0867993203', N'Giáo Sư', N'Thạc Sĩ')
SET IDENTITY_INSERT [dbo].[GiangVien] OFF
GO
INSERT [dbo].[GiaoVienMonHoc] ([GiangVienID], [MonHocID]) VALUES (2, 2005)
INSERT [dbo].[GiaoVienMonHoc] ([GiangVienID], [MonHocID]) VALUES (1002, 2004)
INSERT [dbo].[GiaoVienMonHoc] ([GiangVienID], [MonHocID]) VALUES (1002, 2008)
INSERT [dbo].[GiaoVienMonHoc] ([GiangVienID], [MonHocID]) VALUES (2004, 2008)
GO
SET IDENTITY_INSERT [dbo].[HeSo] ON 

INSERT [dbo].[HeSo] ([HeSoID], [SiSoTu], [SiSoDen], [HeSo]) VALUES (1, 0, 70, CAST(1.00 AS Decimal(3, 2)))
INSERT [dbo].[HeSo] ([HeSoID], [SiSoTu], [SiSoDen], [HeSo]) VALUES (2, 71, 80, CAST(1.10 AS Decimal(3, 2)))
INSERT [dbo].[HeSo] ([HeSoID], [SiSoTu], [SiSoDen], [HeSo]) VALUES (3, 81, 100, CAST(1.20 AS Decimal(3, 2)))
SET IDENTITY_INSERT [dbo].[HeSo] OFF
GO
SET IDENTITY_INSERT [dbo].[LopHoc] ON 

INSERT [dbo].[LopHoc] ([LopID], [TenLop], [SiSo]) VALUES (1002, N'Lop01', 75)
INSERT [dbo].[LopHoc] ([LopID], [TenLop], [SiSo]) VALUES (1003, N'Lop02', 81)
SET IDENTITY_INSERT [dbo].[LopHoc] OFF
GO
INSERT [dbo].[LopMonHoc] ([LopID], [MonHocID]) VALUES (1002, 2004)
INSERT [dbo].[LopMonHoc] ([LopID], [MonHocID]) VALUES (1002, 2005)
INSERT [dbo].[LopMonHoc] ([LopID], [MonHocID]) VALUES (1003, 2006)
INSERT [dbo].[LopMonHoc] ([LopID], [MonHocID]) VALUES (1003, 2008)
GO
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [SoTinChi]) VALUES (2004, N'Tiếng Anh', 3)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [SoTinChi]) VALUES (2005, N'Văn Học', 4)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [SoTinChi]) VALUES (2006, N'Thể Dục', 2)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [SoTinChi]) VALUES (2008, N'Toán', 4)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([TaiKhoanID], [TenDangNhap], [MatKhau], [GiangVienID], [VaiTro]) VALUES (5002, N'Nam', N'123', NULL, N'Quản trị viên')
INSERT [dbo].[TaiKhoan] ([TaiKhoanID], [TenDangNhap], [MatKhau], [GiangVienID], [VaiTro]) VALUES (5003, N'Quan', N'123', 1002, N'Giáo viên')
INSERT [dbo].[TaiKhoan] ([TaiKhoanID], [TenDangNhap], [MatKhau], [GiangVienID], [VaiTro]) VALUES (5004, N'Quynh', N'123', 2, N'Giáo viên')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TaiKhoan__55F68FC0DBD5D3E9]    Script Date: 16/11/2024 3:16:54 PM ******/
ALTER TABLE [dbo].[TaiKhoan] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BangLuong] ADD  DEFAULT (getdate()) FOR [NgayThanhToan]
GO
ALTER TABLE [dbo].[BangTamUng] ADD  DEFAULT (getdate()) FOR [NgayTamUng]
GO
ALTER TABLE [dbo].[DiemDanhBuoiHoc] ADD  DEFAULT (getdate()) FOR [NgayDiemDanh]
GO
ALTER TABLE [dbo].[DiemDanhBuoiHoc] ADD  DEFAULT ((0)) FOR [DaTamUng]
GO
ALTER TABLE [dbo].[BangLuong]  WITH NOCHECK ADD FOREIGN KEY([GiangVienID])
REFERENCES [dbo].[GiangVien] ([GiangVienID])
GO
ALTER TABLE [dbo].[BangTamUng]  WITH NOCHECK ADD FOREIGN KEY([GiangVienID])
REFERENCES [dbo].[GiangVien] ([GiangVienID])
GO
ALTER TABLE [dbo].[DiemDanhBuoiHoc]  WITH NOCHECK ADD FOREIGN KEY([GiangVienID])
REFERENCES [dbo].[GiangVien] ([GiangVienID])
GO
ALTER TABLE [dbo].[DiemDanhBuoiHoc]  WITH NOCHECK ADD FOREIGN KEY([TKBID])
REFERENCES [dbo].[ThoiKhoaBieu] ([TKBID])
GO
ALTER TABLE [dbo].[GiaoVienMonHoc]  WITH NOCHECK ADD FOREIGN KEY([GiangVienID])
REFERENCES [dbo].[GiangVien] ([GiangVienID])
GO
ALTER TABLE [dbo].[GiaoVienMonHoc]  WITH NOCHECK ADD FOREIGN KEY([MonHocID])
REFERENCES [dbo].[MonHoc] ([MonHocID])
GO
ALTER TABLE [dbo].[LopMonHoc]  WITH NOCHECK ADD FOREIGN KEY([LopID])
REFERENCES [dbo].[LopHoc] ([LopID])
GO
ALTER TABLE [dbo].[LopMonHoc]  WITH NOCHECK ADD FOREIGN KEY([MonHocID])
REFERENCES [dbo].[MonHoc] ([MonHocID])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH NOCHECK ADD FOREIGN KEY([GiangVienID])
REFERENCES [dbo].[GiangVien] ([GiangVienID])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH NOCHECK ADD FOREIGN KEY([GiangVienID])
REFERENCES [dbo].[GiangVien] ([GiangVienID])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH NOCHECK ADD FOREIGN KEY([LopID])
REFERENCES [dbo].[LopHoc] ([LopID])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH NOCHECK ADD FOREIGN KEY([MonHocID])
REFERENCES [dbo].[MonHoc] ([MonHocID])
GO
ALTER TABLE [dbo].[DiemDanhBuoiHoc]  WITH NOCHECK ADD CHECK  (([TrangThai]=(1) OR [TrangThai]=(0)))
GO
ALTER TABLE [dbo].[MonHoc]  WITH NOCHECK ADD CHECK  (([SoTinChi]>(0)))
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH NOCHECK ADD CHECK  (([CaHoc]>=(1) AND [CaHoc]<=(4)))
GO
