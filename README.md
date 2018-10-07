# Đồ án môn học lập trình Windows NC

> ## Update 2.0: Thay đổi prototype

### # Các thay đổi

Thay đổi toàn bộ.
  
### # Quan trọng

Database cũ bị loại bỏ hoàn toàn. Tạo database mới bằng file *QuanLyQuanCF_TS.sql* (đã bao gồm dữ liệu).

### # Hướng dẫn cài đặt

  1. Tạo database (*QuanLyQuanCF_TS.sql*).
  
  2. Cài đặt các gói NuGet: [MetroModernUI](https://www.nuget.org/packages/MetroModernUI/), [MaterialSkin](https://www.nuget.org/packages/MaterialSkin/) bằng cách nhấn chuột phải vào project **QuanLyQuanCF_TS** chọn **Manage NuGet Package...**, tìm các gói NuGet và cài đặt.

  3. Thêm chuỗi kết nối database trong class *DataProvider*.
  
  4. Thêm lại folder hình từ project cũ trong bin/debug/.

  5. Cập nhật dữ liệu các bảng trong database (tuỳ chọn).
  
  6. Build project.

### # Hướng dẫn sử dụng

- **Bán hàng**

  - Thêm món từ menu bằng phím Spacebar.
  
  - Xoá món khỏi hoá đơn bằng phím Del.

---

> ## Update 1.7: Thêm thanh tìm kiếm trong form bán hàng

> ## Update 1.6: Tối ưu chức năng bán hàng

> ## Update 1.5: Thêm form đăng nhập và cập nhật database

> ## Update 1.4: Sửa lỗi kết nối database
	
> ## Update 1.3: Thêm MDI
	
> ## Update 1.2: Thêm form đăng nhập

> ## Update 1.1: Thêm mô hình 3 lớp

> ## Update 1.0: Tạo prototype
