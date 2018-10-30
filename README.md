# Đồ án môn học Lập trình Windows nâng cao

> ## Update 2.6.1: Thêm bản mẫu chức năng

### # Các thay đổi

  # 2.6.1: Sửa lỗi Quản lý tài khoản & Bán hàng. Tạo các bản mẫu chức năng xem trước.
  
  # 2.6: Sửa lỗi Quản lý tài khoản & Bán hàng.

  **DATABASE:** Thêm bảng, thêm thuộc tính, sửa lỗi trigger.
  
  **CHỨC NĂNG:** Hoàn thiện Quản lý tài khoản & Quản lý món: tải ảnh, thay đổi trạng thái, thêm xoá sửa...
  
  **HIỆU SUẤT:** Tiếp tục cải thiện tốc độ form bán hàng: bỏ các thao tác thừa, tự dộng hiện màn hình option đầu tiên.
  
  **RÀNG BUỘC DỮ LIỆU:** Các chức năng hiện có (QL Tài khoản, QL Món, Bán hàng) được ràng buộc dữ liệu, cập nhật theo thời gian thực.
  
  **SỬA LỖI:** Sửa một lỗi trigger khiến các bảng trong database không thể xoá dòng dữ liệu cuối cùng.

### # Hướng dẫn cài đặt

  1. Tạo database (*QuanLyQuanCF_TS.sql*).
  
  2. Cài đặt các gói NuGet: [MetroModernUI](https://www.nuget.org/packages/MetroModernUI/), [MaterialSkin](https://www.nuget.org/packages/MaterialSkin/) bằng cách nhấn chuột phải vào project **QuanLyQuanCF_TS** chọn **Manage NuGet Package...**, tìm các gói NuGet và cài đặt.

  3. Thêm chuỗi kết nối database trong class *DataProvider*.
  
  4. Di chuyển 2 folder *img*, *icon* vào trong bin/debug/.

  5. Cập nhật dữ liệu các bảng trong database (tuỳ chọn).
  
  6. Build project.

### # Hướng dẫn sử dụng

- **Chức năng Quản lý tài khoản**

  - Thay đổi trạng thái hoặc xoá để tài khoản không còn xuất hiện trong form đăng nhập và các bên liên quan.
  
- **Chức năng Quản lý món**

  - Thay đổi trạng thái hoặc xoá để món không còn xuất hiện trong form bán hàng và các bên liên quan.

- **Chức năng Bán hàng**

  - Thêm món từ menu bằng cách nhấn trực tiếp vào món đó thay vì dùng phím Spacebar như trước.
  
  - Sau khi thêm món có thể chọn topping tương ứng.
  
  - Xoá món hoặc topping khỏi hoá đơn bằng phím Del.
  
  - Thay đổi số lượng món hoặc topping trực tiếp trong ô số lượng.
  
  - Nhập tiền mặt và nhấn Enter để tính tiền thừa.

---

> #### Update 2.6: Hoàn thiện chức năng Quản lý tài khoản & Quản lý món

> #### Update 2.5: Thêm chức năng Quản lý tài khoản & Quản lý món

> #### Update 2.4.1: Tạo prototype chức năng quản lý tài khoản

> #### Update 2.4: Cập nhật Metro UI

> #### Update 2.3: Thêm ghi chú bán hàng

> #### Update 2.2: Hoàn thiện chức năng bán hàng

> #### Update 2.1: Thay đổi database

> #### Update 2.0: Thay đổi prototype

> #### Update 1.7: Thêm thanh tìm kiếm trong form bán hàng

> #### Update 1.6: Tối ưu chức năng bán hàng

> #### Update 1.5: Thêm form đăng nhập và cập nhật database

> #### Update 1.4: Sửa lỗi kết nối database
	
> #### Update 1.3: Thêm MDI
	
> #### Update 1.2: Thêm form đăng nhập

> #### Update 1.1: Thêm mô hình 3 lớp

> #### Update 1.0: Tạo prototype
