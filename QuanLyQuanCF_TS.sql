create database QuanLyQuanCF_TS
go
use QuanLyQuanCF_TS

create table Ca
(
	maca int identity,
	thoigianbatdau time,
	thoigianketthuc time,
	luong float,
	constraint PK_Cashier primary key (maca)
)

create table NhanVien
(
	manv int identity,
	hoten nvarchar(max),
	matkhau varchar(max),
	ngaysinh date,
	phai int,
	sdt varchar(11),
	ngaybatdau date,
	diachi nvarchar(max),
	ca int,
	laAdmin bit,
	constraint PK_NhanVien primary key (manv),
	constraint FK_NhanVien_Ca foreign key (ca) references Ca(maca)
)

create table LoaiMon
(
	maloaimon int identity,
	tenloaimon nvarchar(max),
	constraint PK_LoaiMon primary key (maloaimon)
)

create table Mon
(
	mamon int identity,
	tenmon nvarchar(max),
	loaimon int,
	hinh nvarchar(max),
	giatien float,
	constraint PK_Mon primary key (mamon),
	constraint FK_Mon_LoaiMon foreign key (loaimon) references LoaiMon(maloaimon)
)

create table Voucher
(
	mavoucher varchar(7),
	ngaybatdau datetime,
	ngayketthuc datetime,
	giatri float,
	trangthai bit,
	constraint PK_Voucher primary key (mavoucher)
)

create table Combo
(
	macombo int identity,
	tencombo nvarchar(max),
	giaban float,
	trangthai bit,
	constraint PK_Combo primary key (macombo)
)

create table CTCombo
(
	macombo int,
	mamon int,
	dongia float,
	constraint PK_CTCombo primary key (macombo, mamon),
	constraint FK_CTCombo_Combo foreign key (macombo) references Combo(macombo),
	constraint FK_CTCombo_Mon foreign key (mamon) references Mon(mamon)
)

create table NhaCungCap
(
	manhacungcap int identity,
	tennhacungcap nvarchar(max),
	diachi nvarchar(max),
	sdt varchar(11),
	constraint PK_NhaCungCap primary key (manhacungcap)
)

create table NguyenLieu
(
	manguyenlieu int identity,
	tennguyenlieu nvarchar(max),
	soluong int,
	nhacungcap int,
	gianhap float,
	constraint PK_NguyenLieu primary key (manguyenlieu),
	constraint FK_NguyenLieu_NhaCungCap foreign key (nhacungcap) references NhaCungCap(manhacungcap)
)

create table CongThuc
(
	manguyenlieu int,
	mamon int,
	constraint PK_CongThuc primary key (manguyenlieu, mamon),
	constraint FK_CongThuc_NguyenLieu foreign key (manguyenlieu) references NguyenLieu(manguyenlieu),
	constraint FK_CongThuc_Mon foreign key (mamon) references Mon(mamon)
)

create table HoaDonBan
(
	mahoadon int identity,
	nhanvienlap int,
	ngaylap datetime,
	voucher varchar(7),
	tongtien float,
	constraint PK_HoaDonBan primary key (mahoadon),
	constraint FK_HoaDonBan_Voucher foreign key (voucher) references Voucher(mavoucher),
	constraint FK_HoaDonBan_NhanVien foreign key (nhanvienlap) references NhanVien(manv)
)

create table HoaDonNhap
(
	mahoadon int identity,
	nhacungcap int,
	ngaylap datetime,
	tongtien float,
	constraint PK_HoaDonNhap primary key (mahoadon),
	constraint FK_HoaDonNhap_NhaCungCap foreign key (nhacungcap) references NhaCungCap(manhacungcap)
)

create table CTHDBan
(
	macthd int identity,
	mahd int,
	mamon int,
	combo int,
	soluong int,
	dongia float,
	constraint PK_CTHDBan primary key (macthd),
	constraint FK_CTHDBan_HoaDonBan foreign key (mahd) references HoaDonBan(mahoadon),
	constraint FK_CTHDBan_Mon foreign key (mamon) references Mon(mamon),
	constraint FK_CTHDBan_Combo foreign key (combo) references Combo(macombo),
)

create table CTHDNhap
(
	mahd int,
	manguyenlieu int,
	soluong int,
	dongia float,
	constraint PK_CTHDNhap primary key (mahd, manguyenlieu),
	constraint FK_CTHDNhap_HoaDonNhap foreign key (mahd) references HoaDonNhap(mahoadon),
	constraint FK_CTHDNhap_NguyenLieu foreign key (manguyenlieu) references NguyenLieu(manguyenlieu),
)

create table ChamCong
(
	machamcong int identity,
	ngaybatdau datetime,
	ngayketthuc datetime,
	constraint PK_ChamCong primary key (machamcong)
)

create table CTChamCong
(
	manv int,
	ngaylam date,
	machamcong int,
	tinhcong bit,
	constraint PK_cTChamCong primary key (manv, ngaylam),
	constraint FK_CTChamCong_NhanVien foreign key (manv) references NhanVien(manv),
	constraint FK_CTChamCong_ChamCong foreign key (machamcong) references Chamcong(machamcong)
)