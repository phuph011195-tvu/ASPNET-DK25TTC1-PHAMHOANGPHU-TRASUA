# ĐỒ ÁN ASP.NET

## Thông tin sinh viên

- Họ và tên: Phạm Hoàng Phú
- MSSV: 170125001
- Lớp: DK25TTC1
- Repository: ASPNET-DK25TTC1-PHAMHOANGPHU-TRASUA

## Mô tả đề tài

Repository dùng để quản lý đồ án ASP.NET.

## Tiến độ

### Tuần 1 (29/06/2026)
- Tạo GitHub Repository.
- Tạo cấu trúc thư mục theo yêu cầu.
- Hoàn thành README.md.
- Push project lên GitHub.

### Tuần 2 (05/07/2026)
* Hoàn thành thiết kế Cơ sở dữ liệu (DbContext, Migrations).
* Sinh code tự động (Scaffolding) thành công chức năng CRUD Quản lý Danh mục và Sản phẩm Trà sữa.
* Sửa các lỗi biên dịch, cấu hình và đồng bộ code lên GitHub thành công.

### Tuần 3 (12/07/2026 - 19/07/2026)

* **Xây dựng chức năng Giỏ hàng (Cart) và Quản lý đơn hàng:**
    * Phát triển `CartController` và thiết kế giao diện danh sách giỏ hàng (`Cart/Index.cshtml`).
    * Sử dụng `Session` hoặc `Cookie` để lưu trữ trạng thái các món trà sữa được người dùng chọn thêm vào giỏ.
    * Tích hợp tính năng cập nhật số lượng, tính tổng tiền đơn hàng động và xóa món khỏi giỏ.
* **Hoàn thiện các trang bổ trợ giao diện người dùng (Front-end):**
    * Xây dựng trang Chi tiết sản phẩm (`Home/Details.cshtml`) hiển thị đầy đủ thông tin mô tả chi tiết, giá bán và hình ảnh lớn của từng loại trà sữa.
    * Liên kết sự kiện cho hệ thống nút bấm "Đặt hàng ngay" trên Banner và nút "Thêm món" tại các thẻ sản phẩm ở Trang chủ.
* Đồng bộ phiên bản và đẩy toàn bộ mã nguồn chức năng giỏ hàng lên hệ thống GitHub.
