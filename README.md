# Đồ án Hệ thống Quản lý Phòng trọ

## Giới thiệu
Đây là đồ án môn học về xây dựng **hệ thống quản lý phòng trọ**.  
Mục tiêu của dự án:
- Quản lý thông tin phòng trọ, khách thuê, hợp đồng
- Quản lý hóa đơn tiền phòng, điện, nước
- Hỗ trợ chủ trọ theo dõi tình trạng phòng và doanh thu
- Cung cấp giao diện dễ sử dụng cho người quản lý

## Công nghệ sử dụng
- **Ngôn ngữ chính:** C# (WinForms/WPF/ASP.NET)
- **Cơ sở dữ liệu:** SQL Server (file `QLPT.sql`)
- **Quản lý mã nguồn:** GitHub

## Chức năng chính
- Quản lý phòng trọ (thêm, sửa, xóa, trạng thái phòng)
- Quản lý khách thuê (thông tin cá nhân, hợp đồng)
- Quản lý hóa đơn (tiền phòng, điện, nước, dịch vụ)
- Thống kê doanh thu, tình trạng phòng
- Đăng nhập/đăng xuất, phân quyền người dùng

## Cấu trúc thư mục
DoAn1/
│── QLPt/          # Mã nguồn C# của hệ thống
│── QLPT.sql       # Script SQL khởi tạo cơ sở dữ liệu
│── README.md      # Tài liệu hướng dẫn
## Cài đặt và chạy thử
1. Clone repository:
   ```bash
   git clone https://github.com/Houtaru0709/DoAn1.git
2.Khởi tạo cơ sở dữ liệu bằng file QLPT.sql trên SQL Server.
3.Mở project trong Visual Studio và chạy chương trình.
4.Chọn cấu hình Release → Build Solution.
5.Chạy chương trình (QLPt.exe) trong thư mục bin/Release.
## Demo chạy thử:
File chạy demo (QLPt.exe) được phát hành trong mục Releases của repo.
Tải về, giải nén và mở file .exe để sử dụng.
## Tài khoản Demo:
- Username: admin
- Password: admin123
- Username: thuan
- Password: 123
## Tác giả
Phạm Kim Hòa Thuận - DH23TIN05 - 235148 Sinh viên ngành Công Nghệ Thông Tin Trường Đại học Nam Cần Thơ
