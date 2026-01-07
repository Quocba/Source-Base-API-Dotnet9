# Source Base Dotnet API

Tài liệu này mô tả chi tiết kiến trúc, các thành phần và hướng dẫn sử dụng source code của dự án Source Base Dotnet API.

## 1. Tổng Quan Kiến Trúc (Architecture Overview)

Dự án được xây dựng dựa trên kiến trúc **Clean Architecture** kết hợp với **CQRS** (Command Query Responsibility Segregation) sử dụng MediatR. Sơ đồ phụ thuộc giữa các tầng như sau:

```mermaid
graph TD
    API[BaseAPI (Presentation)] --> Application
    API --> Domain
    API --> Infrastructure
    API --> RabbitMQContract
    API --> RedisService
    API --> EmailService
    
    Infrastructure --> Application
    Infrastructure --> Domain
    Infrastructure --> RabbitMQContract
    
    Application --> Domain
    Application --> RedisService
    Application --> EmailService
    
    RedisService --> Domain
    RabbitMQContract --> Domain
    RabbitMQContract --> EmailService
```
### Các Layer Chính:

*   **BaseAPI (API Layer)**: Entry point của ứng dụng. Chứa Controllers, Middleware, Configuration (DI, Serilog, JWT, Swagger, etc.).
*   **Application**: Chứa business logic. Sử dụng Pattern CQRS với `MediatR` (Commands, Queries, Handle). Định nghĩa Interfaces cho Repository, Services.
*   **Domain**: Chứa Entities, Enums, Constants, Interfaces cho các core service. Không phụ thuộc vào các layer khác.
*   **Infrastructure**: Triển khai các Interfaces từ Application. Chứa DBContext (EF Core), Repository Implementation, UnitOfWork, External Services (Google Drive, etc.).
*   **RabbitMQContract**: Định nghĩa các Contracts (Messages) và Consumers để xử lý message từ RabbitMQ.
*   **RedisService**: Service wrapper cho StackExchange.Redis để quản lý Cache.
*   **EmailService**: Service chuyên biệt để gửi Email.

---

## 2. Project & Package Dependencies

Dưới đây là danh sách các NuGet Package chính được sử dụng trong từng Project:

| Project | Packages Chính | Mục Đích |
| :--- | :--- | :--- |
| **BaseAPI** | `AspNetCoreRateLimit` | Giới hạn số lượng request (Rate Limiting). |
| | `FluentValidation.AspNetCore` | Validation dữ liệu đầu vào. |
| | `Serilog`, `Serilog.Sinks.*` | Ghi log (File, Console, Discord). |
| | `Swashbuckle.AspNetCore` | Swagger UI/OpenAPI. |
| | `Microsoft.AspNetCore.Authentication.JwtBearer` | Xác thực JWT. |
| | `StackExchange.Redis` | Client Redis. |
| **Application** | `MediatR` | Triển khai pattern Mediator (CQRS). |
| | `Dapper` | Micro-ORM cho các truy vấn hiệu năng cao. |
| | `Elastic.Clients.Elasticsearch` | Client cho Elasticsearch. |
| **Domain** | `Microsoft.EntityFrameworkCore` | ORM Framework. |
| | `MassTransit.RabbitMQ` | Library làm việc với message broker RabbitMQ. |
| | `Newtonsoft.Json` | Xử lý JSON. |
| **Infrastructure** | `Google.Apis.Drive.v3` | Tích hợp Google Drive API. |
| **RabbitMQContract** | `MassTransit.RabbitMQ` | Cấu hình MassTransit và RabbitMQ. |
| **RedisService** | `StackExchange.Redis` | Thư viện giao tiếp Redis. |
| **EmailService** | `Microsoft.AspNetCore.Identity.UI` | Hỗ trợ Identity UI (nếu dùng). |

---

## 3. RabbitMQ & Messaging

Dự án sử dụng **MassTransit** để làm việc với **RabbitMQ**.

### Cấu Hình
Cấu hình RabbitMQ nằm trong `appsettings.json` và được mapping vào class `RabbitMQConfig`.

```json
"RabbitMQ": {
  "HostName": "localhost",
  "UserName": "guest",
  "Password": "guest",
  "Port": 5672,
  "VirtualHost": "/"
}
```

### Các Consumers
Hệ thống đã định nghĩa sẵn các Consumers để xử lý message trong `BaseAPI/DI/DependencyInjection.cs`:

1.  **EmailConsumer** (Queue: `email-queue`): Xử lý việc gửi email thông thường.
2.  **EmailSendFileConsumer** (Queue: `email-send-file`): Xử lý gửi email kèm file đính kèm.
3.  **GenericQueueConsumer** (Queue: `generic-queue`): Xử lý các tác vụ chung khác (có cấu hình prefetch count).
4.  **DbActionConsumer**: Xử lý các tác vụ liên quan đến Database action (nếu có).

### Cách Thêm Consumer Mới
1.  Tạo class Consumer mới trong `RabbitMQContract/Consumer`.
2.  Đăng ký Consumer trong `BaseAPI/DI/DependencyInjection.cs`:
    ```csharp
    x.AddConsumer<MyNewConsumer>();
    // ...
    cfg.ReceiveEndpoint("my-new-queue", e =>
    {
        e.ConfigureConsumer<MyNewConsumer>(context);
    });
    ```

---

## 4. Các Service Khác

### Elasticsearch
*   Sử dụng `Elastic.Clients.Elasticsearch`.
*   Cấu hình URI trong `appsettings.json`.
*   Đăng ký Interface `IElasticRepository<>` để thao tác với Elasticsearch.

### Redis Cache
*   Sử dụng `StackExchange.Redis`.
*   Có service `GenericCacheInvalidator` để quản lý việc xóa cache.

### Google Drive
*   Tích hợp sẵn `GoogleDriveService` để upload/quản lý file trên Google Drive.

---

## 5. Hướng Dẫn Setup & Chạy

1.  **Cài đặt Prerequisite**:
    *   .NET 9 SDK
    *   SQL Server
    *   RabbitMQ
    *   Redis
    *   Elasticsearch (nếu cần dùng tính năng tìm kiếm nâng cao)

2.  **Cấu hình**:
    *   Mở `BaseAPI/appsettings.json`.
    *   Cập nhật `ConnectionStrings:DefaultConnection`.
    *   Cập nhật cấu hình `RabbitMQ`, `Redis`, `Elasticsearch`.

3.  **Database Migration**:
    *   Chạy lệnh EF Core migration: `dotnet ef database update --project Infrastructure --startup-project BaseAPI`.

4.  **Chạy Ứng Dụng**:
    *   Set `BaseAPI` là Startup Project.
    *   Chạy Visual Studio hoặc `dotnet run`.
    *   Truy cập Swagger tại `/swagger/index.html` hoặc Scalar API Reference.

---
*Generated by Antigravity*