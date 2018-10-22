# Đồ án môn học Lập trình Windows nâng cao

> ## Update 2.4: Cập nhật Metro UI

### # Các thay đổi

  **Cập nhật UI:**
  
  **1. Màn hình chính**:
  
  - Cập nhật giao diện Metro hoàn chỉnh.
  
  - Thêm một loạt icon giao diện
  
  **2. Màn hình bán hàng**:
  
  - Tối ưu UI responsive, thay đổi tỉ lệ splitter, item.
  
  - Thêm lựa chọn hiện tất cả món trong Menu món.
  
  - Thêm lại group theo loại món.
  
  **Sửa lỗi:**
  
  1. Sửa một lỗi khiến dữ liệu món order không clear hết sau khi xuất hoá đơn thành công.
  
  2. Thay đổi mã nguồn và tái sử dụng một số phương thức.

### # Hướng dẫn cài đặt

  1. Tạo database (*QuanLyQuanCF_TS.sql*).
  
  2. Cài đặt các gói NuGet: [MetroModernUI](https://www.nuget.org/packages/MetroModernUI/), [MaterialSkin](https://www.nuget.org/packages/MaterialSkin/) bằng cách nhấn chuột phải vào project **QuanLyQuanCF_TS** chọn **Manage NuGet Package...**, tìm các gói NuGet và cài đặt.

  3. Thêm chuỗi kết nối database trong class *DataProvider*.
  
  4. Di chuyển 2 folder *img*, *icon* vào trong bin/debug/.

  5. Cập nhật dữ liệu các bảng trong database (tuỳ chọn).
  
  6. Build project.

### # Hướng dẫn sử dụng

- **Chức năng Bán hàng**

  - Thêm món từ menu bằng cách nhấn trực tiếp vào món đó thay vì dùng phím Spacebar như trước.
  
  - Sau khi thêm món có thể chọn topping tương ứng.
  
  - Xoá món hoặc topping khỏi hoá đơn bằng phím Del.
  
  - Thay đổi số lượng món hoặc topping trực tiếp trong ô số lượng.
  
  - Nhập tiền mặt và nhấn Enter để tính tiền thừa.

---

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
