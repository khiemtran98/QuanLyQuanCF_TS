# Đồ án môn học lập trình Windows NC

> ## Update 1.5: Thêm form đăng nhập và cập nhật database

### # Các thay đổi

  1.	Cho phép nhân viên đăng xuất khỏi phần mềm.
  
  2.	Nhân viên có thêm xem các thông tin cơ bản của mình trong phần mềm

  3.	Thêm chức năng bán hàng. Cho phép nhân viên chọn món để in hoá đơn và tính tiền.

  4.	Bổ sung table 'Ban' trong database.
  
  5.	Menu món được phân loại và có thể tải được hình (xem hướng dẫn ở dưới).
  
### # Quan trọng

Database được thêm bảng 'Ban' nhằm giúp quản lý các khách hàng đang ngồi bàn trong quán được thuận tiện. Hãy cập nhật lại database theo các trường hợp dưới đây.

- **Trường hợp 1: Chưa tạo database:**

  - Chạy file *QuanLyQuanCF_TS.sql*

- **Trường hợp 2: Đã tạo database (cũ):**

  - Chạy đoạn code bên dưới trong SQL Server

```
create table Ban
(
  id int identity,
  trangthai bit,
  constraint PK_ban primary key (id)
)
 
alter table HoaDonBan
  add ban int
 
alter table HoaDonBan
  add constraint FK_HoaDonBan_Ban foreign key (ban) references Ban(id)
```

### # Hướng dẫn cài đặt

  1.	Tạo database (*QuanLyQuanCF_TS.sql*).

  2.	Thay đổi chuỗi kết nối database của từng class trong lớp DAO của máy đang chạy.

  3.	Cập nhật dữ liệu các bảng 'NhanVien', 'LoaiMon', 'Mon', 'Ca' trong database để các chức năng của phần mềm hoạt động (tuy nhiên phần mềm vẫn có thể chạy được nếu không cập nhật đầy đủ các thuộc tính trong bảng).

  4.	Thêm hình ảnh vào folder 'hinh' trong bin\debug (tên hình phải trùng với mã món). **Lưu ý: dữ liệu hình trong database là tên hình ảnh + đuôi file (VD: 1.jpg).**
  
  5.	Build project.
  
### # Hướng dẫn sử dụng

- **Bán hàng**

  - Thêm/xoá món bằng cách chọn món và nhấn Spacebar.

---

> ## Update 1.4: Sửa lỗi kết nối database
	
> ## Update 1.3: Thêm MDI
	
> ## Update 1.2: Thêm form đăng nhập

> ## Update 1.1: Thêm mô hình 3 lớp