# WEBSITE BÁN TRÀ SỮA MON - ASP.NET CORE MVC

## 1. Thông tin sinh viên
* **Họ và tên:** Phạm Hoàng Phú
* **MSSV:** 170125001
* **Lớp:** DK25TTC1
* **Email:** phuph011195@tvu-onschool.edu.vn
* **SĐT:** 0879492739
* **Repository:** ASPNET-DK25TTC1-PHAMHOANGPHU-TRASUA

---

## 2. Mô tả đề tài
Website quản lý và bán trà sữa trực tuyến MON được xây dựng trên nền tảng ASP.NET Core MVC. Hệ thống tích hợp đầy đủ các tính năng:
* Xem danh sách sản phẩm, chi tiết sản phẩm.
* Quản lý giỏ hàng (thêm, sửa số lượng, xóa sản phẩm).
* Quản lý danh mục và sản phẩm (CRUD).

---

## 3. Yêu cầu hệ thống (Prerequisites)
Để cài đặt và chạy được ứng dụng, máy tính cần cài đặt sẵn:
* **.NET SDK:** Phiên bản 6.0 / 8.0 trở lên.
* **Hệ quản trị CSDL:** SQL Server / SQL Server Express / LocalDB.
* **Công cụ phát triển:** Visual Studio 2022 (khuyên dùng) hoặc VS Code.
* **SQL Management Tool:** SQL Server Management Studio (SSMS) hoặc Azure Data Studio.

---

## 4. Hướng dẫn cài đặt và chạy ứng dụng

### Bước 1: Khởi tạo Cơ sở dữ liệu (Database)
Bạn có thể khởi tạo CSDL theo 1 trong 2 cách sau:

* **Cách 1: Chạy file Script SQL (Khuyên dùng)**
  1. Mở **SQL Server Management Studio (SSMS)** và kết nối tới SQL Server của bạn.
  2. Mở file `Script_CSDL_TraSuaMon.sql` (nằm trong thư mục `setup/`).
  3. Nhấn **Execute (F5)** để tạo Database và chèn dữ liệu mẫu.

* **Cách 2: Sử dụng EF Core Migration**
  1. Mở Terminal / Package Manager Console tại thư mục `scr/TrasuaMON`.
  2. Chạy câu lệnh:
     ```bash
     dotnet ef database update
     ```

---

### Bước 2: Cấu hình chuỗi kết nối Database (Connection String)
1. Mở file `appsettings.json` trong thư mục project `scr/TrasuaMON/`.
2. Sửa lại tham số `Server` trong chuỗi kết nối cho khớp với tên SQL Server trên máy bạn:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TraSuaMonDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
