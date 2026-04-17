# Báo Cáo Nghiên Cứu
## [16/04/2026]

**Mục tiêu:** 
- Tổng quan về NoSQL và MongoDB
- Cài đặt MongoDB
- Thực hiện demo CRUD Menu-News

## Phần 1: Tổng hợp kết quả

| # | Task | Chi tiết  | Trạng thái |
|---|----------------|----------------------|------------|
| 1 | **Tổng quan về NoSQL và MongoDB** | Hiểu và áp dụng các lệnh của MongoDB | Đã xong |
| 2 | **Cài đặt MongoDB** | Cài đặt bằng `image` của `Docker` | Đã xong |
| 3 | **Thực hiện demo CRUD Menu-News** | Thực hiện CRUD để hiểu hơn về các tương tác dữ liệu với MongoDB | Đã xong |

## Phần 2: Chi tiết
### 1. Tổng quan NoSQL và MongoDB
#### Tại sao lại là NoSQL?
Ưu điểm:
- Linh hoạt cấu trúc (Schema-less): Thay đổi nhiều
- Mở rộng theo chiều ngang (Horizontal Scaling): hệ thống NoSQL được thiết kế để chạy phân tán trên nhiều máy chủ rẻ tiền cộng gộp lại (Scale-out).
- Hiệu năng cao với Big Data

Nhược điểm:
- Hy sinh tính nhất quán (ACID)
- Nếu hệ thống của bạn là lõi giao dịch tài chính/ngân hàng phức tạp, SQL vẫn là vua. Nếu là hệ thống Content, E-commerce hay Social Media, NoSQL là lựa chọn hoàn hảo.

#### Tại sao lại là Mongo DB?
- MongoDB thuộc `Document-oriented Database` trong 4 loại NoSQL (Key-Value, Column-family, Graph)

### 2. Cài đặt MongoDB
#### Cài đặt bằng `Docker Desktop`:
1. Pull image MongoDB 7:
```bash
docker pull mongo:7.0
```

2. Tạo và chạy container
```bash
docker run -d \
  --name mongodb7-pro \
  -p 27017:27017 \
  -v /path/to/your/data:/data/db \
  -e MONGO_INITDB_ROOT_USERNAME=yourname \
  -e MONGO_INITDB_ROOT_PASSWORD=yoursecretpassword \
  mongo:7.0
```

3. Truy cập qua Terminal (mongosh)
```bash
docker exec -it mongodb7-pro mongosh -u yourname -p yoursecretpassword
```

4. Tạo Database (MenuNewsDb)
```JavaScript
use MenuNewsDb
```

5. Tạo document (Menu trong bài demo)
```JavaScript
db.menus.insertOne({
    name: 'Tin tức công nghệ',
    description: 'Chuyên mục công nghệ',
    url: '/tin-tuc/cong-nghe',
    order: 1,
    isActive: true,
    createdAt: new Date(),
    updatedAt: new Date()
})
```

5. Kiểm tra collection

Xem collection đang có:
```JavaScript
show collections
```

Kiểm tra collection Menu
```JavaScript
db.menus.find()
```

### 3. Demo CRUD 
- Thực hiện kiến trúc Clean Architecture

- Trong phần Infrastructure cấu hình kết nối với Mongo DB.

- Chuỗi kết nối trong file `setting.json`:
```json
"MongoSettings": {
    "ConnectionString": "mongodb://username:password@yourhost:27017",
    "DatabaseName": "MenuNewsDb",
    "MenusCollection": "menus",
    "NewsCollection": "news"
  }
```
---
# Báo Cáo Nghiên Cứu
## [17/04/2026]

**Mục tiêu:** 
  - Tìm hiểu về gRPC, HTTP/2 và Protocol Buffers
  - So sánh gRPC và REST, phân biệt, khi nào dùng
  - Tìm hiểu 4 loại mô hình của gRPC
  - Thực hành demo CRUD

## 1. Tổng hợp kết quả

| # | Task | Chi tiết  | Trạng thái |
|---|----------------|----------------------|--------------------|
| 1 | **Tìm hiểu về gRPC, HTTP/2 và Protocol Buffers** | - | Hoàn thành |
| 2 | **So sánh gRPC và REST, phân biệt, khi nào dùng** | - | Hoàn thành |
| 3 | **Tìm hiểu 4 loại mô hình của gRPC** | Áp dụng được mô hình `Unary RPC` trong demo | Hoàn thành |
| 4 | **Thực hành demo CRUD** | CRUD Api bằng gRPC Service và tạo gRPC Client C# | Hoàn thành |

## 2. Chi tiết

### 1. Tìm hiểu về gRPC, HTTP/2 và Protocol Buffers

- **Protocol Buffers (Protobuf)**: Thay vì dùng JSON, Protobuf tuần tự hóa dữ liệu thành định dạng nhị phân (binary). File .proto đóng vai trò như một bản hợp đồng (contract) duy nhất, ràng buộc chặt chẽ kiểu dữ liệu (strongly-typed)
- **HTTP/2**: gửi/nhận hàng ngàn request song song trên một kết nối TCP duy nhất, Header Compression (nén metadata, cực kỳ tiết kiệm băng thông) và Server Push.
- **gRPC**: Là framework RPC (Remote Procedure Call) do Google phát triển, gom Protobuf và HTTP/2 lại.

### 2. So sánh gRPC và REST: Khi nào dùng cái nào?

| Tiêu chí | REST (JSON + HTTP/1.1) | gRPC (Protobuf + HTTP/2)  | 
|---|----------------|----------------------|
| Định dạng dữ liệu | JSON/XML (Văn bản - Text) | Protobuf (Nhị phân - Binary) |
| Hiệu năng & Kích thước | Trung bình. Payload lớn. | Cao. Payload siêu nhỏ, xử lý cực nhanh. |
| Chuẩn API | Không có chuẩn ép buộc cứng | Ép buộc chặt chẽ qua file .proto. |
| Mô hình giao tiếp | Chỉ Request - Response. | Request-Response và Streaming |

==> Dùng gRPC khi:

- Giao tiếp nội bộ (Service-to-Service): Giữa các Microservices với nhau.
- Hệ thống dùng nhiều ngôn ngữ lập trình khác nhau.
- Cần Streaming dữ liệu thời gian thực: Chat, VoIP, xử lý video/audio.

==> Dùng REST (hoặc GraphQL) khi:

- Public API (B2C/B2B): Cung cấp API ra bên ngoài cho đối tác hoặc khách hàng vì tính phổ biến và dễ tích hợp.

- Web Frontend (Browser-to-Server): Giao tiếp trực tiếp từ trình duyệt web.

### 3. Mô hình gRPC

1. `Unary RPC`: Giống hệt REST. (VD: Lấy thông tin user getUserById).
2. `Server Streaming`: Client gọi 1 lần, Server trả về một luồng dữ liệu liên tục. (VD: Theo dõi giá cổ phiếu realtime, lấy log hệ thống theo thời gian thực).
3. `Client Streaming`: Client gửi một luồng dữ liệu khổng lồ lên, Server gộp lại và trả 1 kết quả. (VD: Upload một file video lớn lên server, gửi luồng dữ liệu telemetry từ thiết bị IoT).
4. `Bidirectional Streaming`: Hai bên đẩy dữ liệu qua lại độc lập trên cùng 1 kết nối. (VD: Ứng dụng gọi video call, game multiplayer realtime, hệ thống chat).

### 4. Thực hành Demo

### Xây dựng gRPC Service

- CRUD Menu và New
- Test với `Postman`

### Xây dựng gRPC Client

- Client được xây dựng bằng Console App C# tương tác với gRPC Service
---