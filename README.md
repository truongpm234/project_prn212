# 🐾 PawFund Platform

PawFund là một nền tảng WPF được thiết kế nhằm hỗ trợ việc nhận nuôi và gây quỹ cho các động vật bị bỏ rơi hoặc trong trại cứu hộ. Ứng dụng cho phép người dùng đăng ký, gửi đơn xin nhận nuôi với hệ thống xét duyệt, quản lý danh sách thú cưng, quyên góp, và nhiều tính năng khác.

---

### 🌟 Tính năng nổi bật

- 🔐 **Đăng ký và xác thực người dùng**: Hệ thống đăng ký, đăng nhập bảo mật với nhiều vai trò khác nhau.
- 🐕 **Đơn xin nhận nuôi & phê duyệt**: Người dùng có thể gửi đơn xin nhận nuôi và được xét duyệt bởi quản trị viên.
- 📋 **Bảng điều khiển dành cho Admin**: Quản lý việc xét duyệt người dùng, đơn xin nhận nuôi, và các hoạt động khác.
- 🏠 **Quản lý danh sách thú cưng**: Nhân viên trại cứu hộ có thể thêm, chỉnh sửa, và quản lý thông tin thú cưng.
- 👥 **Phân quyền theo vai trò**: Hệ thống phân quyền chi tiết cho Admin, Shelter Staff (nhân viên cứu hộ), Adopter (người nhận nuôi) và Guest (khách).
- 💸 **Hỗ trợ quyên góp**: Cho phép người dùng quyên góp hỗ trợ các hoạt động cứu hộ.
- 📧 **Dịch vụ gửi email tùy chỉnh**: Hệ thống gửi mail thông báo qua SMTP.

---

### 🛠️ Công nghệ sử dụng

- 🖥️ **Backend**: Ứng dụng WPF trên nền tảng .NET (ASP.NET WPF Console App)
- 🗄️ **Database**: Microsoft SQL Server
- 🔗 **ORM**: Entity Framework Core
- ✉️ **Dịch vụ Email**: Hệ thống mail SMTP tùy chỉnh

---

### 📁 Cấu trúc dự án

- **BusinessObject**: Các lớp thực thể (Entity classes) đại diện cho bảng dữ liệu.
- **DataAccessLayer**: Lớp truy cập và tương tác dữ liệu với SQL Server.
- **Services**: Các dịch vụ xử lý nghiệp vụ (business logic).
- **View**: Chứa các file XAML giao diện người dùng và controller đi kèm (xaml.cs).

---

### ⚙️ Hướng dẫn cài đặt

1. **Clone** repository về máy:
    ```bash
    git clone https://github.com/truongpm234/project_prn212.git
    ```
2. **Cấu hình kết nối database** trong file `appsettings.json`.
3. **Mở project** bằng Visual Studio và **build**.
4. **Chạy ứng dụng** để bắt đầu sử dụng nền tảng PawFund.

---

### 📬 Liên hệ

Nếu có thắc mắc hoặc muốn hợp tác, vui lòng liên hệ qua email:  
✉️[Email](ghoul1645@gmail.com)

---


*Cảm ơn bạn đã quan tâm và sử dụng PawFund! 🐶🐱*
