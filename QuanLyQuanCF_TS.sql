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

create table HoaDonBan
(
	ma_hoa_don_ban int identity,
	nhan_vien_lap int not null,
	ngay_lap datetime not null,
	tong_tien float not null,
	trang_thai bit not null,
	constraint PK_HoaDonBan primary key (ma_hoa_don_ban),
	constraint FK_HoaDonBan_NhanVien foreign key (nhan_vien_lap) references NhanVien(ma_nhan_vien)
)

create table HoaDonNhap
(
	ma_hoa_don_nhap int identity,
	nha_cung_cap int not null,
	ngay_lap datetime not null,
	tong_tien float not null,
	trang_thai bit not null,
	constraint PK_HoaDonNhap primary key (ma_hoa_don_nhap),
	constraint FK_HoaDonNhap_NhaCungCap foreign key (nha_cung_cap) references NhaCungCap(ma_nha_cung_cap)
)

create table CTHDBan
(
	ma_hoa_don_ban int,
	ma_mon int,
	so_luong int not null,
	don_gia float not null,
	constraint PK_CTHDBan primary key (ma_hoa_don_ban, ma_mon),
	constraint FK_CTHDBan_HoaDonBan foreign key (ma_hoa_don_ban) references HoaDonBan(ma_hoa_don_ban),
	constraint FK_CTHDBan_Mon foreign key (ma_mon) references Mon(ma_mon)
)

create table CTHDNhap
(
	ma_hoa_don_nhap int,
	ma_nguyen_lieu int not null,
	khoi_luong int not null,
	don_gia float not null,
	constraint PK_CTHDNhap primary key (ma_hoa_don_nhap, ma_nguyen_lieu),
	constraint FK_CTHDNhap_HoaDonNhap foreign key (ma_hoa_don_nhap) references HoaDonNhap(ma_hoa_don_nhap),
	constraint FK_CTHDNhap_NguyenLieu foreign key (ma_nguyen_lieu) references NguyenLieu(ma_nguyen_lieu)
)

INSERT [dbo].[NhanVien] (ho_ten, mat_khau, ngay_bat_dau, la_admin) VALUES (N'[TEST-Admin]', '123', '1/1/2018', 1)
INSERT [dbo].[NhanVien] (ho_ten, mat_khau, ngay_bat_dau, la_admin) VALUES (N'[TEST-Cashier]', '123', '1/1/2018', 0)

INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Trà sữa', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Cà phê', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Freeze', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Bánh mì', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Topping', 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [trang_thai]) VALUES (N'Đồ ăn vặt', 1)

INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa trân châu', 1, N'1.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa hokkaido', 1, N'2.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa ô long', 1, N'3.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa vị hoa nhài', 1, N'4.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Hồng trà sữa', 1, N'5.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa khoai môn', 1, N'6.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa chocolate', 1, N'7.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa hạt dẻ', 1, N'8.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa đường đen', 1, N'9.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa thạch dừa', 1, N'10.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa valina', 1, N'11.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa thạch rau câu', 1, N'12.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa đậu đỏ', 1, N'13.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin sữa đá', 2, N'14.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin đen đá', 2, N'15.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin sữa nóng', 2, N'16.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Phin đen nóng', 2, N'17.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Latte', 2, N'18.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Cappuccino', 2, N'19.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Caramel macchiato', 2, N'20.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Mocha', 2, N'21.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Americano', 2, N'22.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Espresso', 2, N'23.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Caramel Phin Freeze', 3, N'24.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Classic Phin Freeze', 3, N'25.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Freeze trà xanh', 3, N'26.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Freeze socola', 3, N'27.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Cookies & cream', 3, N'28.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sen vàng', 1, N'29.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà thạch đào', 1, N'30.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà thanh đào', 1, N'31.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà thạch vãi', 1, N'32.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh đậu đỏ', 1, N'33.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sữa trân châu đường đen', 1, N'34.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Chocolate trân châu đường đen', 1, N'35.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Đường đen trân châu sủi bọt', 1, N'36.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Matcha trân chân đường đen', 1, N'37.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'1883 trân châu sủi bọt', 1, N'38.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà trái cây main tea', 1, N'39.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà cam nha đam', 1, N'40.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà thạch bông cỏ', 1, N'41.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà kim quất xí mụi', 1, N'42.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà machada hạt chia', 1, N'43.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Hồng trà vãi hạt chia', 1, N'44.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà sấu táo đỏ thạch bông cỏ', 1, N'45.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà kim quất mãng cầu', 1, N'46.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh vải hạt chia', 1, N'47.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà chanh thanh long đỏ macchiato  ', 1, N'48.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà chanh thanh long đỏ macchiato nhỏ  ', 1, N'49.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà đen macchiato', 1, N'50.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh macchiato', 1, N'51.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Lục trà xoài macchiato', 1, N'52.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà olong nhân sâm hoa mộc macchiato ', 1, N'53.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà bá tước hoa hồng', 1, N'54.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà chanh dây macchiato', 1, N'55.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà xanh gạo rang', 1, N'56.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Trà đen', 1, N'57.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì thịt nướng', 4, N'58.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì gà xé nước tương', 4, N'59.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì chả lụa xá xíu', 4, N'60.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mì xíu mại', 4, N'61.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh tiramisu', 4, N'62.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh chuối', 4, N'63.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai Caramel', 4, N'64.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai chanh dây', 4, N'65.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai trà xanh', 4, N'66.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh phô mai cà phê', 4, N'67.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh socola', 4, N'68.jpg', 5000, 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [gia_tien], [trang_thai]) VALUES (N'Bánh mousse cacao', 4, N'69.jpg', 5000, 1)

GO
CREATE TRIGGER TRIG_NhanVien_delete
ON dbo.NhanVien
FOR DELETE
AS
    DECLARE @maxID int;
    SELECT @maxID = MAX(ma_nhan_vien)
    FROM NhanVien;
    DBCC CHECKIDENT (NhanVien, RESEED, @maxID);

GO
CREATE TRIGGER TRIG_LoaiMon_delete
ON dbo.LoaiMon
FOR DELETE
AS
    DECLARE @maxID int;
    SELECT @maxID = MAX(ma_loai_mon)
    FROM LoaiMon;
    DBCC CHECKIDENT (LoaiMon, RESEED, @maxID);

GO
CREATE TRIGGER TRIG_Mon_delete
ON dbo.Mon
FOR DELETE
AS
    DECLARE @maxID int;
    SELECT @maxID = MAX(ma_mon)
    FROM Mon;
    DBCC CHECKIDENT (Mon, RESEED, @maxID);

GO
CREATE TRIGGER TRIG_NhaCungCap_delete
ON dbo.NhaCungCap
FOR DELETE
AS
    DECLARE @maxID int;
    SELECT @maxID = MAX(ma_nha_cung_cap)
    FROM NhaCungCap;
    DBCC CHECKIDENT (NhaCungCap, RESEED, @maxID);

GO
CREATE TRIGGER TRIG_NguyenLieu_delete
ON dbo.NguyenLieu
FOR DELETE
AS
    DECLARE @maxID int;
    SELECT @maxID = MAX(ma_nguyen_lieu)
    FROM NguyenLieu;
    DBCC CHECKIDENT (NguyenLieu, RESEED, @maxID);

GO
CREATE TRIGGER TRIG_HoaDonBan_delete
ON dbo.HoaDonBan
FOR DELETE
AS
    DECLARE @maxID int;
    SELECT @maxID = MAX(ma_hoa_don_ban)
    FROM HoaDonBan;
    DBCC CHECKIDENT (HoaDonBan, RESEED, @maxID);

GO
CREATE TRIGGER TRIG_HoaDonNhap_delete
ON dbo.HoaDonNhap
FOR DELETE
AS
    DECLARE @maxID int;
    SELECT @maxID = MAX(ma_hoa_don_nhap)
    FROM HoaDonNhap;
    DBCC CHECKIDENT (HoaDonNhap, RESEED, @maxID);