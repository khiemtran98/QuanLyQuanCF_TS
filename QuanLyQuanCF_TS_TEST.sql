create database QuanLyQuanCF_TS
go
use QuanLyQuanCF_TS

create table LoaiTaiKhoan
(
	ma_loai_tai_khoan int identity,
	ten_loai_tai_khoan nvarchar(max) not null,
	trang_thai bit not null,
	constraint PK_LoaiTaiKhoan primary key (ma_loai_tai_khoan)
)

create table TaiKhoan
(
	ma_tai_khoan int identity,
	ho_ten nvarchar(max) not null,
	mat_khau varchar(max) not null,
	ngay_bat_dau date not null,
	loai_tai_khoan int not null,
	hinh nvarchar(max),
	trang_thai bit not null,
	constraint PK_TaiKhoan primary key (ma_tai_khoan),
	constraint FK_TaiKhoan_LoaiTaiKhoan foreign key (loai_tai_khoan) references LoaiTaiKhoan(ma_loai_tai_khoan)
)

create table ChucNang
(
	ma_chuc_nang int identity,
	ten_chuc_nang nvarchar(max) not null
	constraint PK_ChucNang primary key (ma_chuc_nang)
)

create table ChucNang_LoaiTaiKhoan
(
	ma_chuc_nang int,
	ma_loai_tai_khoan int,
	constraint PK_ChucNang_LoaiTaiKhoan primary key (ma_chuc_nang, ma_loai_tai_khoan),
	constraint FK_ChucNang_LoaiTaiKhoan_ChucNang foreign key (ma_chuc_nang) references ChucNang(ma_chuc_nang),
	constraint FK_ChucNang_LoaiTaiKhoan_LoaiTaiKhoan foreign key (ma_loai_tai_khoan) references LoaiTaiKhoan(ma_loai_tai_khoan)
)

create table LoaiMon
(
	ma_loai_mon int identity,
	ten_loai_mon nvarchar(max) not null,
	la_do_uong bit not null,
	trang_thai bit not null,
	constraint PK_LoaiMon primary key (ma_loai_mon)
)

create table Mon
(
	ma_mon int identity,
	ten_mon nvarchar(max) not null,
	loai_mon int not null,
	hinh nvarchar(max),
	trang_thai bit not null,
	constraint PK_Mon primary key (ma_mon),
	constraint FK_Mon_LoaiMon foreign key (loai_mon) references LoaiMon(ma_loai_mon)
)

create table SizeMon
(
	size nvarchar(10),
	ma_mon int not null,
	gia_tien float not null,
	trang_thai bit not null,
	constraint PK_SizeMon primary key (size, ma_mon),
	constraint FK_SizeMon_Mon foreign key (ma_mon) references Mon(ma_mon)
)

create table LoaiTopping
(
	ma_loai_topping int identity,
	ten_loai_topping nvarchar(max) not null,
	trang_thai bit not null,
	constraint PK_LoaiTopping primary key (ma_loai_topping)
)

create table Topping
(
	ma_topping int identity,
	ten_topping nvarchar(max) not null,
	loai_topping int not null,
	gia_tien float not null,
	hinh nvarchar(max),
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
	constraint FK_HoaDon_TaiKhoan foreign key (nhan_vien_lap) references TaiKhoan(ma_tai_khoan)
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

create table CTHoaDon
(
	ma_cthd int identity,
	hoa_don int not null,
	mon int not null,
	so_luong int not null,
	don_gia float not null,
	ghi_chu nvarchar(max),
	constraint PK_CTHoaDon primary key (ma_cthd),
	constraint FK_CTHoaDon_HoaDon foreign key (hoa_don) references HoaDon(ma_hoa_don),
	constraint FK_CTHoaDon_Mon foreign key (mon) references Mon(ma_mon)
)

create table CTHoaDon_Topping
(
	ma_cthd int,
	ma_topping int,
	so_luong int not null,
	don_gia float not null,
	ghi_chu nvarchar(max),
	constraint PK_CTHoaDon_Topping primary key (ma_cthd, ma_topping),
	constraint FK_CTHoaDon_Topping_CTHoaDon foreign key (ma_cthd) references CTHoaDon(ma_cthd),
	constraint FK_CTHoaDon_Topping_Topping foreign key (ma_topping) references Topping(ma_topping)
)

create table CTPhieuNhap
(
	ma_phieu_nhap int,
	ma_nguyen_lieu int not null,
	khoi_luong int not null,
	don_gia float not null,
	constraint PK_CTPhieuNhap primary key (ma_phieu_nhap, ma_nguyen_lieu),
	constraint FK_CTPhieuNhap_PhieuNhap foreign key (ma_phieu_nhap) references PhieuNhap(ma_phieu_nhap),
	constraint FK_CTPhieuNhap_NguyenLieu foreign key (ma_nguyen_lieu) references NguyenLieu(ma_nguyen_lieu)
)

create table CTLoaiMon_LoaiTopping
(
	ma_loai_mon int,
	ma_loai_topping int,
	constraint PK_CTLoaiMon_LoaiTopping primary key (ma_loai_mon, ma_loai_topping),
	constraint FK_CTLoaiMon_LoaiTopping_LoaiMon foreign key (ma_loai_mon) references LoaiMon(ma_loai_mon),
	constraint FK_CTLoaiMon_LoaiTopping_LoaiTopping foreign key (ma_loai_topping) references LoaiTopping(ma_loai_topping)
)

INSERT [dbo].[LoaiTaiKhoan] ([ten_loai_tai_khoan], [trang_thai]) VALUES (N'Admin', 1)
INSERT [dbo].[LoaiTaiKhoan] ([ten_loai_tai_khoan], [trang_thai]) VALUES (N'Cashier', 1)

INSERT [dbo].[TaiKhoan] (ho_ten, mat_khau, ngay_bat_dau, loai_tai_khoan, hinh, trang_thai) VALUES (N'[TEST-Admin]', '123', '1/1/2018', 1, 'default-account.png' ,1)
INSERT [dbo].[TaiKhoan] (ho_ten, mat_khau, ngay_bat_dau, loai_tai_khoan, hinh, trang_thai) VALUES (N'[TEST-Cashier]', '123', '1/1/2018', 2, 'default-account.png' ,1)

INSERT [dbo].[LoaiMon] ([ten_loai_mon], [la_do_uong], [trang_thai]) VALUES (N'Trà sữa', 1, 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [la_do_uong], [trang_thai]) VALUES (N'Cà phê', 1, 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [la_do_uong], [trang_thai]) VALUES (N'Freeze', 1, 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [la_do_uong], [trang_thai]) VALUES (N'Bánh mì', 1, 1)
INSERT [dbo].[LoaiMon] ([ten_loai_mon], [la_do_uong], [trang_thai]) VALUES (N'Xiên que', 1, 1)

INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa trân châu', 1, N'1.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa hokkaido', 1, N'2.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa ô long', 1, N'3.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa vị hoa nhài', 1, N'4.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Hồng trà sữa', 1, N'5.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa khoai môn', 1, N'6.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa chocolate', 1, N'7.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa hạt dẻ', 1, N'8.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa đường đen', 1, N'9.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa thạch dừa', 1, N'10.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa valina', 1, N'11.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa thạch rau câu', 1, N'12.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa đậu đỏ', 1, N'13.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Phin sữa đá', 2, N'14.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Phin đen đá', 2, N'15.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Phin sữa nóng', 2, N'16.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Phin đen nóng', 2, N'17.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Latte', 2, N'18.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Cappuccino', 2, N'19.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Caramel macchiato', 2, N'20.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Mocha', 2, N'21.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Americano', 2, N'22.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Espresso', 2, N'23.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Caramel Phin Freeze', 3, N'24.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Classic Phin Freeze', 3, N'25.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Freeze trà xanh', 3, N'26.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Freeze socola', 3, N'27.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Cookies & cream', 3, N'28.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sen vàng', 1, N'29.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà thạch đào', 1, N'30.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà thanh đào', 1, N'31.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà thạch vãi', 1, N'32.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà xanh đậu đỏ', 1, N'33.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sữa trân châu đường đen', 1, N'34.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Chocolate trân châu đường đen', 1, N'35.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Đường đen trân châu sủi bọt', 1, N'36.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Matcha trân chân đường đen', 1, N'37.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'1883 trân châu sủi bọt', 1, N'38.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà trái cây main tea', 1, N'39.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Lục trà cam nha đam', 1, N'40.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Lục trà thạch bông cỏ', 1, N'41.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Lục trà kim quất xí mụi', 1, N'42.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà machada hạt chia', 1, N'43.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Hồng trà vãi hạt chia', 1, N'44.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà sấu táo đỏ thạch bông cỏ', 1, N'45.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Lục trà kim quất mãng cầu', 1, N'46.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà xanh vải hạt chia', 1, N'47.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà chanh thanh long đỏ macchiato  ', 1, N'48.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà chanh thanh long đỏ macchiato nhỏ  ', 1, N'49.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà đen macchiato', 1, N'50.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà xanh macchiato', 1, N'51.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Lục trà xoài macchiato', 1, N'52.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà olong nhân sâm hoa mộc macchiato ', 1, N'53.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà bá tước hoa hồng', 1, N'54.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà chanh dây macchiato', 1, N'55.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà xanh gạo rang', 1, N'56.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Trà đen', 1, N'57.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh mì thịt nướng', 4, N'58.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh mì gà xé nước tương', 4, N'59.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh mì chả lụa xá xíu', 4, N'60.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh mì xíu mại', 4, N'61.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh tiramisu', 4, N'62.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh chuối', 4, N'63.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh phô mai Caramel', 4, N'64.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh phô mai chanh dây', 4, N'65.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh phô mai trà xanh', 4, N'66.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh phô mai cà phê', 4, N'67.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh socola', 4, N'68.jpg', 1)
INSERT [dbo].[Mon] ([ten_mon], [loai_mon], [hinh], [trang_thai]) VALUES (N'Bánh mousse cacao', 4, N'69.jpg', 1)

INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 1, 27000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 1, 37000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 1, 47000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 2, 22000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 2, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 2, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 3, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 3, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 3, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 4, 22000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 4, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 4, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 5, 22000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 5, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 5, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 6, 22000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 6, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 6, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 7, 22000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 7, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 7, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 8, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 8, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 8, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 9, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 9, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 9, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 10, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 10, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 10, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 11, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 11, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 11, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 12, 27000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 12, 37000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 12, 47000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 13, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 13, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 13, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 14, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 14, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 14, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 15, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 15, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 15, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 16, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 16, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 16, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 17, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 17, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 17, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 18, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 18, 55000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 18, 65000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 19, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 19, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 19, 60000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 20, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 20, 59000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 20, 69000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 21, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 21, 59000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 21, 69000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 22, 25000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 22, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 22, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 23, 25000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 23, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 23, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 24, 25000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 24, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 24, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 25, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 25, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 25, 59000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 26, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 26, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 26, 59000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 27, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 27, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 27, 59000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 28, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 28, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 28, 59000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 29, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 29, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 29, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 30, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 30, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 30, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 31, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 31, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 31, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 32, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 32, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 32, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 33, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 33, 39000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 33, 49000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 34, 25000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 34, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 34, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 35, 28000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 35, 38000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 35, 48000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 36, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 36, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 36, 55000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 37, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 37, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 37, 60000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 38, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 38, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 38, 55000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 39, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 39, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 39, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 40, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 40, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 40, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 41, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 41, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 41, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 42, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 42, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 42, 52000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 43, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 43, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 43, 55000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 44, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 44, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 44, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 45, 37000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 45, 47000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 45, 57000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 46, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 46, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 46, 60000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 47, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 47, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 47, 55000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 48, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 48, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 48, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 49, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 49, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 49, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 50, 27000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 50, 37000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 50, 47000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 51, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 51, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 51, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 52, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 52, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 52, 52000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 53, 30000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 53, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 53, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 54, 40000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 54, 50000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 54, 60000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 55, 32000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 55, 42000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 55, 52000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 56, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 56, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 56, 55000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('S', 57, 25000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('M', 57, 35000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('L', 57, 45000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 58, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 59, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 60, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 61, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 62, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 63, 19000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 64, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 65, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 66, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 67, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 68, 29000, 1)
INSERT [dbo].[SizeMon] ([size], [ma_mon], [gia_tien], [trang_thai]) VALUES ('Standard', 69, 29000, 1)

INSERT [dbo].[LoaiTopping] ([ten_loai_topping], [trang_thai]) VALUES (N'Kem', 1)
INSERT [dbo].[LoaiTopping] ([ten_loai_topping], [trang_thai]) VALUES (N'Trân châu', 1)
INSERT [dbo].[LoaiTopping] ([ten_loai_topping], [trang_thai]) VALUES (N'Thạch', 1)

INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Kem Macchiato', 1, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu đen', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu trắng', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu xanh', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu sợi', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu tươi socola', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu tươi matcha', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu phô mai tươi', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu tím', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Trân châu mật ong', 2, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Thạch pudding', 3, 5000, 'default-product.png', 1)
INSERT [dbo].[Topping] ([ten_topping], [loai_topping], [gia_tien], [hinh], [trang_thai]) VALUES (N'Thạch viên phô mai', 3, 5000, 'default-product.png', 1)

INSERT [dbo].[CTLoaiMon_LoaiTopping] ([ma_loai_mon], [ma_loai_topping]) VALUES (1, 2)
INSERT [dbo].[CTLoaiMon_LoaiTopping] ([ma_loai_mon], [ma_loai_topping]) VALUES (1, 3)
INSERT [dbo].[CTLoaiMon_LoaiTopping] ([ma_loai_mon], [ma_loai_topping]) VALUES (2, 1)
INSERT [dbo].[CTLoaiMon_LoaiTopping] ([ma_loai_mon], [ma_loai_topping]) VALUES (3, 1)

INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Quản lý tài khoản')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Quản lý món')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Quản lý kho')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Thống kê hoá đơn')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Thống kê nhập hàng')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Thống kê doanh thu')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Nhập hàng')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Bán hàng')
INSERT [dbo].[ChucNang] ([ten_chuc_nang]) VALUES ('Cài đặt')

INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (1, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (2, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (3, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (4, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (5, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (6, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (7, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (8, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (9, 1)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (7, 2)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (8, 2)
INSERT [dbo].[ChucNang_LoaiTaiKhoan] ([ma_chuc_nang], [ma_loai_tai_khoan]) VALUES (9, 2)

GO
CREATE TRIGGER TRIG_LoaiTaiKhoan_delete
ON dbo.LoaiTaiKhoan
AFTER DELETE
AS
	IF (SELECT MAX(ma_loai_tai_khoan) FROM LoaiTaiKhoan) IS NULL
		DBCC CHECKIDENT (LoaiTaiKhoan, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_loai_tai_khoan)
			FROM LoaiTaiKhoan;
			DBCC CHECKIDENT (LoaiTaiKhoan, RESEED, @maxID);
		END
		
GO
CREATE TRIGGER TRIG_TaiKhoan_delete
ON dbo.TaiKhoan
AFTER DELETE
AS
	IF (SELECT MAX(ma_tai_khoan) FROM TaiKhoan) IS NULL
		DBCC CHECKIDENT (TaiKhoan, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_tai_khoan)
			FROM TaiKhoan;
			DBCC CHECKIDENT (TaiKhoan, RESEED, @maxID);
		END
		
GO
CREATE TRIGGER TRIG_LoaiMon_delete
ON dbo.LoaiMon
AFTER DELETE
AS
	IF (SELECT MAX(ma_loai_mon) FROM LoaiMon) IS NULL
		DBCC CHECKIDENT (LoaiMon, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_loai_mon)
			FROM LoaiMon;
			DBCC CHECKIDENT (LoaiMon, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_Mon_delete
ON dbo.Mon
AFTER DELETE
AS
	IF (SELECT MAX(ma_mon) FROM Mon) IS NULL
		DBCC CHECKIDENT (Mon, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_mon)
			FROM Mon;
			DBCC CHECKIDENT (Mon, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_LoaiTopping_delete
ON dbo.LoaiTopping
AFTER DELETE
AS
	IF (SELECT MAX(ma_loai_topping) FROM LoaiTopping) IS NULL
		DBCC CHECKIDENT (LoaiTopping, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_loai_topping)
			FROM LoaiTopping;
			DBCC CHECKIDENT (LoaiTopping, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_Topping_delete
ON dbo.Topping
AFTER DELETE
AS
	IF (SELECT MAX(ma_topping) FROM Topping) IS NULL
		DBCC CHECKIDENT (Topping, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_topping)
			FROM Topping;
			DBCC CHECKIDENT (Topping, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_NhaCungCap_delete
ON dbo.NhaCungCap
AFTER DELETE
AS
	IF (SELECT MAX(ma_nha_cung_cap) FROM NhaCungCap) IS NULL
		DBCC CHECKIDENT (NhaCungCap, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_nha_cung_cap)
			FROM NhaCungCap;
			DBCC CHECKIDENT (NhaCungCap, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_NguyenLieu_delete
ON dbo.NguyenLieu
AFTER DELETE
AS
	IF (SELECT MAX(ma_nguyen_lieu) FROM NguyenLieu) IS NULL
		DBCC CHECKIDENT (NguyenLieu, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_nguyen_lieu)
			FROM NguyenLieu;
			DBCC CHECKIDENT (NguyenLieu, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_HoaDon_delete
ON dbo.HoaDon
AFTER DELETE
AS
	IF (SELECT MAX(ma_hoa_don) FROM HoaDon) IS NULL
		DBCC CHECKIDENT (HoaDon, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID =  MAX(ma_hoa_don)
			FROM HoaDon;
			DBCC CHECKIDENT (HoaDon, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_PhieuNhap_delete
ON dbo.PhieuNhap
AFTER DELETE
AS
	IF (SELECT MAX(ma_phieu_nhap) FROM PhieuNhap) IS NULL
		DBCC CHECKIDENT (PhieuNhap, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID = MAX(ma_phieu_nhap)
			FROM PhieuNhap;
			DBCC CHECKIDENT (PhieuNhap, RESEED, @maxID);
		END

GO
CREATE TRIGGER TRIG_CTHoaDon_delete
ON dbo.CTHoaDon
AFTER DELETE
AS
	IF (SELECT MAX(ma_cthd) FROM CTHoaDon) IS NULL
		DBCC CHECKIDENT (CTHoaDon, RESEED, 0);
	ELSE
		BEGIN
			DECLARE @maxID int;
			SELECT @maxID =  MAX(ma_cthd)
			FROM CTHoaDon;
			DBCC CHECKIDENT (CTHoaDon, RESEED, @maxID);
		END
