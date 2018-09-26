# Đồ án môn học lập trình Windows NC

> ## Update 1.6: Tối ưu chức năng bán hàng

### # Các thay đổi

  1.	Số lượng món có thể nhập trực tiếp trong hoá đơn. Đơn giá và tổng tiền được cập nhật theo.

  2.	Số lượng món trong hoá đơn tự động tăng khi thêm nhiều lần. Đơn giá và tổng tiền được cập nhật theo.
  
  3.	Thêm một món nhiều lần làm tăng số lượng món đó trong hoá đơn thay vì thêm trùng món như trước.
  
  3.	Xoá table 'Ban' trong database.
  
### # Quan trọng

Database xoá bảng 'Ban' và một sô thuộc tính. Hãy cập nhật lại database theo các trường hợp dưới đây.

- **Trường hợp 1: Chưa tạo database:**

  - Chạy file *QuanLyQuanCF_TS.sql*

- **Trường hợp 2: Đã tạo database (cũ):**

  - Chạy đoạn code bên dưới trong SQL Server

```
use QuanLyQuanCF_TS
go

alter table Ca
	drop column luong

alter table HoaDonBan
	drop constraint FK_HoaDonBan_Ban

alter table HoaDonBan
	drop column ban

drop table Ban
```

### # Hướng dẫn cài đặt

  1.	Tạo database (*QuanLyQuanCF_TS.sql*).

  2.	Thêm chuỗi kết nối database của từng class trong lớp DAO của máy đang chạy.

  3.	Cập nhật dữ liệu các bảng 'NhanVien', 'LoaiMon', 'Mon', 'Ca' trong database để các chức năng của phần mềm hoạt động (tuy nhiên phần mềm vẫn có thể chạy được nếu không cập nhật đầy đủ các thuộc tính trong bảng).

  4.	Thêm hình ảnh vào folder 'hinh' trong bin\debug (tên hình phải trùng với mã món). **Lưu ý: dữ liệu hình trong database là tên hình ảnh + đuôi file (VD: 1.jpg).**
  
  5.	Build project.

### # Hướng dẫn sử dụng

- **Bán hàng**

  - Thêm món bằng cách chọn món trong menu và nhấn phím Spacebar.
  
  - Xoá món bằng cách chọn món trong hoá đơn và nhấn phím Del.
  
  - Quay lại màn hình chính bằng phím Esc.

---
> ## Update 1.5: Thêm form đăng nhập và cập nhật database

> ## Update 1.4: Sửa lỗi kết nối database
	
> ## Update 1.3: Thêm MDI
	
> ## Update 1.2: Thêm form đăng nhập

> ## Update 1.1: Thêm mô hình 3 lớp