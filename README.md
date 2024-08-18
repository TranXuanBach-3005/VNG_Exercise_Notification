# VNG_Exercise_Notification
Có 2 cách để test:
Cách 1: Test sử dụng API
     Bước 1: gọi API get tất cả user (https://localhost:7173/Post/users)
     Bước 2: từ data ở bước 1 truyền những data cần thiết vào API tạo bài viết (https://localhost:7173/Post/create-post)
     Bước 3: mở console xem thông tin notification 
Cách 2: Run project unit test VNG_Exercise_Notification.Test 
