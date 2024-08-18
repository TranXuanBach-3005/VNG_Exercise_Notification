# VNG_Exercise_Notification
## Hướng dẫn Test

Có 2 cách để test hệ thống:

1. **Test sử dụng API:**

   - **Bước 1:** Gọi API để lấy tất cả user:
     ```http
     GET https://localhost:7173/Post/users
     ```
   - **Bước 2:** Sử dụng dữ liệu từ bước 1 để truyền các thông tin cần thiết vào API tạo bài viết:
     ```http
     POST https://localhost:7173/Post/create-post
     ```
   - **Bước 3:** Mở console và xem thông tin notification đã được tạo.

2. **Run project unit test:**

   - Chạy unit test cho dự án `VNG_Exercise_Notification.Test`.

