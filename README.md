# Đồ án môn học lập trình Windows NC

> ## Update 1.7: Thêm thanh tìm kiếm trong form bán hàng

### # Các thay đổi

  1. Thêm thanh tìm kiếm trong form bán hàng.

  2. Cập nhật database.
  
### # Quan trọng

Database loại bỏ bảng 'ChamCong', 'CTChamCong', 'LoaiHoaDonBan' và một sô thuộc tính. Hãy cập nhật lại database theo các trường hợp dưới đây.

- **Trường hợp 1: Chưa tạo database:**

  - Chạy đoạn code trong file *QuanLyQuanCF_TS.sql*

- **Trường hợp 2: Đã tạo database (cũ):**

  - Chạy đoạn code bên dưới trong SQL Server

```
use QuanLyQuanCF_TS
go
alter table HoaDonBan
	drop constraint FK_HoaDonBan_LoaiHoaDonBan

alter table HoaDonBan
	drop column loaihoadon

drop table LoaiHoaDonBan
	
drop table CTChamCong

drop table ChamCong

sp_rename @objname = N'[Ca].[PK_Cashier]', @newname = N'PK_Ca'

```

Chạy đoạn code trong file *DuLieuMon.sql* để thêm dữ liệu tạm thời (nếu chưa có).

### # Hướng dẫn cài đặt

  1. Tạo database (*QuanLyQuanCF_TS.sql*).

  2. Thêm chuỗi kết nối database của từng class trong lớp DAO của máy đang chạy.

  3. Cập nhật dữ liệu các bảng 'NhanVien', 'LoaiMon', 'Mon', 'Ca' trong database để phần mềm hoạt động tốt nhất.

  4. Thêm hình ảnh vào folder 'hinh' trong bin\debug (tên hình phải trùng với mã món). **Lưu ý: dữ liệu hình trong database là tên hình ảnh + đuôi file (VD: 1.jpg).**
  
  5. Build project.

### # Hướng dẫn sử dụng

- **Bán hàng**

  - Thêm món bằng cách chọn món trong menu và nhấn phím Spacebar.
  
  - Xoá món bằng cách chọn món trong hoá đơn và nhấn phím Del.
  
  - Thay đổi số lượng món trong hoá đơn bằng cách nhấn đúp vào ô trong cột số lượng muốn thay đổi.
  
  - Sử dụng thanh tìm kiếm bằng cách nhập từ khoá tên món và nhất phím Enter. Xoá thanh tìm kiếm và nhấn phím Enter để hiện lại danh sách đầy đủ.
  
  - Quay lại màn hình chính bằng phím Esc.

---
> ## Update 1.6: Tối ưu chức năng bán hàng

> ## Update 1.5: Thêm form đăng nhập và cập nhật database

> ## Update 1.4: Sửa lỗi kết nối database
	
> ## Update 1.3: Thêm MDI
	
> ## Update 1.2: Thêm form đăng nhập

> ## Update 1.1: Thêm mô hình 3 lớp
