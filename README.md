# Đồ án môn học Lập trình Windows nâng cao

> ## Update 2.6.2: Tạo bản mẫu thống kê hoá đơn

### # CÁC THAY ĐỔI

  **Sửa lỗi:**
  
  - Tính sai tổng tiền hoá đơn.
  
  - Chức năng sửa tài khoản và món làm mất hình hiện tại.
  
  - Danh sách tài khoản và món không tải được hình và tên loại ở một số dòng.
  
### # QUAN TRỌNG

**1. Dựng bản thử nghiệm:**

- Món bán theo nhiều size với giá khác nhau.

- Hạn chế chức năng cho từng loại tài khoản.

**2. Project:** Bổ sung 2 package hỗ trợ biểu đồ: [ZedGraph](https://www.nuget.org/packages/ZedGraph/), [LiveCharts](https://www.nuget.org/packages/LiveCharts.WinForms/).

**3. Database:** Chỉ sử dụng database *QuanLyQuanCF_TS_TEST.sql* để dựng chức năng mới. Còn lại vẫn sử dụng database *QuanLyQuanCF_TS.sql*.

*Xem hướng dẫn cài đặt để không bị lỗi khi mở project.*

### # HƯỚNG DẪN CÀI ĐẶT

  1. Tạo database (*QuanLyQuanCF_TS.sql*).
  
  2. Cập nhật dữ liệu các bảng trong database (tuỳ chọn).
  
  2. Di chuyển tất cả thư mục trong **assets** ra ngoài thư mục project.
  
  3. Mở project.

  3. Thêm chuỗi kết nối database trong class *DataProvider*.
  
  5. Build project.

### # HƯỚNG DẪN SỬ DỤNG

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
