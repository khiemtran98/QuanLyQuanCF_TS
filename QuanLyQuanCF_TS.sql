create database QuanLyQuanCF_TS
go
use QuanLyQuanCF_TS

create table NhanVien
(
	ma_nhan_vien int identity,
	ho_ten nvarchar(max) not null,
	mat_khau varchar(max) not null,
	ngay_bat_dau date not null,
	la_admin bit not null,
	constraint PK_NhanVien primary key (ma_nhan_vien)
)

create table LoaiMon
(
	ma_loai_mon int identity,
	ten_loai_mon nvarchar(max) not null,
	trang_thai bit not null,
	constraint PK_LoaiMon primary key (ma_loai_mon)
)

create table Mon
(
	ma_mon int identity,
	ten_mon nvarchar(max) not null,
	loai_mon int not null,
	hinh nvarchar(max) not null,
	gia_tien float not null,
	trang_thai bit not null,
	constraint PK_Mon primary key (ma_mon),
	constraint FK_Mon_LoaiMon foreign key (loai_mon) references LoaiMon(ma_loai_mon)
)

create table LoaiTopping
(
	ma_loai_topping int identity,
	ten_loai_topping nvarchar(max) not null,
	loai_mon int not null,
	trang_thai bit not null,
	constraint PK_LoaiTopping primary key (ma_loai_topping),
	constraint FK_LoaiTopping_LoaiMon foreign key (loai_mon) references LoaiMon(ma_loai_mon)
)

create table Topping
(
	ma_topping int identity,
	ten_topping nvarchar(max) not null,
	loai_topping int not null,
	gia_tien float not null,
	trang_thai bit not null,
	constraint PK_Topping primary key (ma_topping),
	constraint FK_Topping_LoaiTopping foreign key (loai_topping) references LoaiTopping(ma_loai_topping)
)

create table NhaCungCap
(
	ma_nha_cung_cap int identity,
	ten_nha_cung_cap nvarchar(max) not null
	constraint PK_NhaCungCap primary key (ma_nha_cung_cap)
)

create table NguyenLieu
(
	ma_nguyen_lieu int identity,
	ten_nguyen_lieu nvarchar(max) not null,
	khoi_luong int not null,
	constraint PK_NguyenLieu primary key (ma_nguyen_lieu)
)

create table HoaDon
(
	ma_hoa_don int identity,
	nhan_vien_lap int not null,
	ngay_lap datetime not null,
	tong_tien float not null,
	trang_thai bit not null,
	constraint PK_HoaDon primary key (ma_hoa_don),
	constraint FK_HoaDon_NhanVien foreign key (nhan_vien_lap) references NhanVien(ma_nhan_vien)
)

create table PhieuNhap
(
	ma_phieu_nhap int identity,
	nha_cung_cap int not null,
	ngay_lap datetime not null,
	tong_tien float not null,
	trang_thai bit not null,
	constraint PK_PhieuNhap primary key (ma_phieu_nhap),
	constraint FK_PhieuNhap_NhaCungCap foreign key (nha_cung_cap) references NhaCungCap(ma_nha_cung_cap)
)

create table ChiTietHoaDon
(
	ma_cthd int identity,
	hoa_don int not null,
	mon int not null,
	so_luong int not null,
	don_gia float not null,
	constraint PK_ChiTietHoaDon primary key (ma_cthd),
	constraint FK_ChiTietHoaDon_HoaDon foreign key (hoa_don) references HoaDon(ma_hoa_don),
	constraint FK_ChiTietHoaDon_Mon foreign key (mon) references Mon(ma_mon)
)

create table ChiTietMon
(
	ma_cthd int,
	ma_topping int,
	so_luong int,
	don_gia float not null,
	constraint PK_ChiTietMon primary key (ma_cthd, ma_topping),
	constraint FK_ChiTietMon_ChiTietHoaDon foreign key (ma_cthd) references ChiTietHoaDon(ma_cthd),
	constraint FK_ChiTietMon_Topping foreign key (ma_topping) references Topping(ma_topping)
)

create table ChiTietPhieuNhap
(
	ma_phieu_nhap int,
	ma_nguyen_lieu int not null,
	khoi_luong int not null,
	don_gia float not null,
	constraint PK_ChiTietPhieuNhap primary key (ma_phieu_nhap, ma_nguyen_lieu),
	constraint FK_ChiTietPhieuNhap_PhieuNhap foreign key (ma_phieu_nhap) references PhieuNhap(ma_phieu_nhap),
	constraint FK_ChiTietPhieuNhap_NguyenLieu foreign key (ma_nguyen_lieu) references NguyenLieu(ma_nguyen_lieu)
)

INSERT [dbo].[NhanVien] (ho_ten, mat_khau, ngay_bat_dau, la_admin) VALUES (N'[TEST-Admin]', '123', '1/1/2018', 1)
INSERT [dbo].[NhanVien] (ho_ten, mat_khau, ngay_bat_dau, la_admin) VALUES (N'[TEST-Cashier]', '123', '1/1/2018', 0)

INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Trà sữa', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Cà phê', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Freeze', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Thức ăn', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Xiên que', 1)

INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa trân châu', 1, N'1.jpg', 37000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa hokkaido', 1, N'2.jpg', 32000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa ô long', 1, N'3.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa vị hoa nhài', 1, N'4.jpg', 32000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Hồng trà sữa', 1, N'5.jpg', 32000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa khoai môn', 1, N'6.jpg', 32000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa chocolate', 1, N'7.jpg', 32000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa hạt dẻ', 1, N'8.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa đường đen', 1, N'9.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa thạch dừa', 1, N'10.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa valina', 1, N'11.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa thạch rau câu', 1, N'12.jpg', 37000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa đậu đỏ', 1, N'13.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin sữa đá', 2, N'14.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin đen đá', 2, N'15.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin sữa nóng', 2, N'16.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin đen nóng', 2, N'17.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Latte', 2, N'18.jpg', 55000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Cappuccino', 2, N'19.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Caramel macchiato', 2, N'20.jpg', 59000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Mocha', 2, N'21.jpg', 59000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Americano', 2, N'22.jpg', 35000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Espresso', 2, N'23.jpg', 35000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Caramel Phin Freeze', 3, N'24.jpg', 49000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Classic Phin Freeze', 3, N'25.jpg', 49000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Freeze trà xanh', 3, N'26.jpg', 49000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Freeze socola', 3, N'27.jpg', 49000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Cookies & cream', 3, N'28.jpg', 49000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sen vàng', 1, N'29.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà thạch đào', 1, N'30.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà thanh đào', 1, N'31.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà thạch vãi', 1, N'32.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh đậu đỏ', 1, N'33.jpg', 39000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa trân châu đường đen', 1, N'34.jpg', 35000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Chocolate trân châu đường đen', 1, N'35.jpg', 38000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Đường đen trân châu sủi bọt', 1, N'36.jpg', 45000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Matcha trân chân đường đen', 1, N'37.jpg', 50000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'1883 trân châu sủi bọt', 1, N'38.jpg', 45000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà trái cây main tea', 1, N'39.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà cam nha đam', 1, N'40.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà thạch bông cỏ', 1, N'41.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà kim quất xí mụi', 1, N'42.jpg', 42000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà machada hạt chia', 1, N'43.jpg', 45000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Hồng trà vãi hạt chia', 1, N'44.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sấu táo đỏ thạch bông cỏ', 1, N'45.jpg', 47000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà kim quất mãng cầu', 1, N'46.jpg', 50000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh vải hạt chia', 1, N'47.jpg', 45000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà chanh thanh long đỏ macchiato  ', 1, N'48.jpg', 45000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà chanh thanh long đỏ macchiato nhỏ  ', 1, N'49.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà đen macchiato', 1, N'50.jpg', 37000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh macchiato', 1, N'51.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà xoài macchiato', 1, N'52.jpg', 42000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà olong nhân sâm hoa mộc macchiato ', 1, N'53.jpg', 40000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà bá tước hoa hồng', 1, N'54.jpg', 50000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà chanh dây macchiato', 1, N'55.jpg', 42000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh gạo rang', 1, N'56.jpg', 45000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà đen', 1, N'57.jpg', 35000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì thịt nướng', 4, N'58.jpg', 19000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì gà xé nước tương', 4, N'59.jpg', 19000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì chả lụa xá xíu', 4, N'60.jpg', 19000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì xíu mại', 4, N'61.jpg', 19000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh tiramisu', 4, N'62.jpg', 19000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh chuối', 4, N'63.jpg', 19000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai Caramel', 4, N'64.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai chanh dây', 4, N'65.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai trà xanh', 4, N'66.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai cà phê', 4, N'67.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh socola', 4, N'68.jpg', 29000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mousse cacao', 4, N'69.jpg', 29000, 1)

INSERT [dbo].[LoaiTopping] ([ten_loai_topping], [loai_mon], [trang_thai]) VALUES (N'Kem', 2, 1)
INSERT [dbo].[LoaiTopping] ([ten_loai_topping], [loai_mon], [trang_thai]) VALUES (N'Trân châu', 1, 1)
INSERT [dbo].[LoaiTopping] ([ten_loai_topping], [loai_mon], [trang_thai]) VALUES (N'Thạch', 1, 1)

INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Kem Macchiato', 1, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu đen', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu trắng', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu xanh', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu sợi', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu tươi socola', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu tươi matcha', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu phô mai tươi', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu tím', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Trân châu mật ong', 2, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Thạch pudding', 3, 5000, 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [trang_thai]) VALUES (N'Thạch viên phô mai', 3, 5000, 1)

GO
CREATE TRIGGER TRIG_NhanVien_delete
ON dbo.NhanVien
FOR DELETE
AS
	IF (
		SELECT MAX(ma_nhan_vien)
		FROM NhanVien ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_nhan_vien)
			FROM NhanVien;
			DBCC CHECKIDENT (NhanVien, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (NhanVien, RESEED, 0);

GO
CREATE TRIGGER TRIG_LoaiMon_delete
ON dbo.LoaiMon
FOR DELETE
AS
	IF (
		SELECT MAX(ma_loai_mon)
		FROM LoaiMon ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_loai_mon)
			FROM LoaiMon;
			DBCC CHECKIDENT (LoaiMon, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (LoaiMon, RESEED, 0);

GO
CREATE TRIGGER TRIG_Mon_delete
ON dbo.Mon
FOR DELETE
AS
	IF (
		SELECT MAX(ma_mon)
		FROM Mon ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_mon)
			FROM Mon;
			DBCC CHECKIDENT (Mon, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (Mon, RESEED, 0);

GO
CREATE TRIGGER TRIG_LoaiTopping_delete
ON dbo.LoaiTopping
FOR DELETE
AS
	IF (
		SELECT MAX(ma_loai_topping)
		FROM LoaiTopping ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_loai_topping)
			FROM LoaiTopping;
			DBCC CHECKIDENT (LoaiTopping, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (LoaiTopping, RESEED, 0);

GO
CREATE TRIGGER TRIG_Topping_delete
ON dbo.Topping
FOR DELETE
AS
	IF (
		SELECT MAX(ma_topping)
		FROM Topping ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_topping)
			FROM Topping;
			DBCC CHECKIDENT (Topping, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (Topping, RESEED, 0);

GO
CREATE TRIGGER TRIG_NhaCungCap_delete
ON dbo.NhaCungCap
FOR DELETE
AS
	IF (
		SELECT MAX(ma_nha_cung_cap)
		FROM NhaCungCap ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_nha_cung_cap)
			FROM NhaCungCap;
			DBCC CHECKIDENT (NhaCungCap, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (NhaCungCap, RESEED, 0);

GO
CREATE TRIGGER TRIG_NguyenLieu_delete
ON dbo.NguyenLieu
FOR DELETE
AS
	IF (
		SELECT MAX(ma_nguyen_lieu)
		FROM NguyenLieu ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_nguyen_lieu)
			FROM NguyenLieu;
			DBCC CHECKIDENT (NguyenLieu, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (NguyenLieu, RESEED, 0);

GO
CREATE TRIGGER TRIG_HoaDon_delete
ON dbo.HoaDon
FOR DELETE
AS
	IF (
		SELECT MAX(ma_hoa_don)
		FROM HoaDon ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID =  MAX(ma_hoa_don)
			FROM HoaDon;
			DBCC CHECKIDENT (HoaDon, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (HoaDon, RESEED, 0);

GO
CREATE TRIGGER TRIG_ChiTietHoaDon_delete
ON dbo.ChiTietHoaDon
FOR DELETE
AS
	IF (
		SELECT MAX(ma_cthd)
		FROM ChiTietHoaDon ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID =  MAX(ma_cthd)
			FROM ChiTietHoaDon;
			DBCC CHECKIDENT (ChiTietHoaDon, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (ChiTietHoaDon, RESEED, 0);

GO
CREATE TRIGGER TRIG_PhieuNhap_delete
ON dbo.PhieuNhap
FOR DELETE
AS
	IF (
		SELECT MAX(ma_phieu_nhap)
		FROM PhieuNhap ) = NULL
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_phieu_nhap)
			FROM PhieuNhap;
			DBCC CHECKIDENT (PhieuNhap, RESEED, @maxID);
		END
	ELSE
		DBCC CHECKIDENT (PhieuNhap, RESEED, 0);
