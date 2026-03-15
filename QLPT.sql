CREATE DATABASE QuanLyPhongTro;
GO
USE QuanLyPhongTro;
GO

-- 1. Phòng trọ
CREATE TABLE tblPhongTro (
    MaPhongTro INT IDENTITY(1,1) PRIMARY KEY,
    ToaNha NVARCHAR(50),
    Tang INT,
    SoPhong NVARCHAR(10),
    GiaPhong DECIMAL(18,2),
    MoTa NVARCHAR(255)
);

-- 2. Khách thuê
CREATE TABLE tblKhachThue (
    MaKhachThue INT IDENTITY(1,1) PRIMARY KEY,
    MaPhongTro INT,
    HoTen NVARCHAR(100),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    QueQuan NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    CCCD NVARCHAR(20),
    FOREIGN KEY (MaPhongTro) REFERENCES tblPhongTro(MaPhongTro)
);

-- 3. Hợp đồng
CREATE TABLE tblHopDong (
    MaHopDong INT IDENTITY(1,1) PRIMARY KEY,
    MaPhongTro INT,
    MaKhachThue INT,
    HinhThucThue NVARCHAR(50),
    TienCoc DECIMAL(18,2),
    NgayKi DATE,
    NgayHetHan DATE,
    GhiChu NVARCHAR(255),
    FOREIGN KEY (MaPhongTro) REFERENCES tblPhongTro(MaPhongTro),
    FOREIGN KEY (MaKhachThue) REFERENCES tblKhachThue(MaKhachThue)
);

-- 4. Điện nước
CREATE TABLE tblDienNuoc (
    MaDienNuoc INT IDENTITY(1,1) PRIMARY KEY,
    MaPhongTro INT,
    ThangNam NVARCHAR(7), -- ví dụ: 03/2026
    SoDienCu INT,
    SoDienMoi INT,
    TieuThuDien INT,
    TienDien DECIMAL(18,2),
    SoNuocCu INT,
    SoNuocMoi INT,
    TieuThuNuoc INT,
    TienNuoc DECIMAL(18,2),
    DonGiaDien DECIMAL(18,2) DEFAULT 3500,
    DonGiaNuoc DECIMAL(18,2) DEFAULT 12000,
    FOREIGN KEY (MaPhongTro) REFERENCES tblPhongTro(MaPhongTro)
);

-- 5. Đăng nhập
CREATE TABLE tblDangNhap (
    Acc INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100)
);

-- 6. Hóa đơn
	CREATE TABLE tblHoaDon (
		MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
		MaPhongTro INT,
		ThangNam NVARCHAR(7),
		TienSinhHoat DECIMAL(18,2),
		Internet DECIMAL(18,2),
		DichVuKhac DECIMAL(18,2),
		ChuyenKhoan NVARCHAR(50),
		GhiChu NVARCHAR(255),
		TrangThai NVARCHAR(20) DEFAULT N'Chưa thanh toán',
		FOREIGN KEY (MaPhongTro) REFERENCES tblPhongTro(MaPhongTro)
	);

	-- 7. Chi tiết hóa đơn (đã sửa đúng logic)
	CREATE TABLE tblChiTietHoaDon (
		MaChiTietHoaDon INT IDENTITY(1,1) PRIMARY KEY,
		MaHoaDonCT INT,
		STT INT,
		TenDichVu NVARCHAR(100),
		ChiSoCu INT,
		ChiSoMoi INT,
		SoLuong INT,
		ThanhTien DECIMAL(18,2),
		FOREIGN KEY (MaHoaDonCT) REFERENCES tblHoaDon(MaHoaDon)
	);
GO

-- Tài khoản admin mặc định
INSERT INTO tblDangNhap (TenDangNhap, MatKhau, Email) 
VALUES ('admin', 'admin123', 'admin@gmail.com');
--Phòng trọ
INSERT INTO tblPhongTro (ToaNha, Tang, SoPhong, GiaPhong, MoTa)
VALUES 
(N'A1', 1, N'101', 2500000, N'Phòng đơn, có ban công'),
(N'A1', 2, N'201', 3000000, N'Phòng đôi, có máy lạnh'),
(N'B2', 3, N'301', 3500000, N'Phòng rộng, có nội thất');

-- Khách thuê
INSERT INTO tblKhachThue (MaPhongTro, HoTen, GioiTinh, NgaySinh, QueQuan, SoDienThoai, CCCD)
VALUES
(1, N'Nguyễn Văn A', N'Nam', '2000-05-12', N'Hà Nội', '0912345678', '012345678901'),
(2, N'Trần Thị B', N'Nữ', '1998-09-20', N'Hải Phòng', '0987654321', '098765432109');

-- Hợp đồng
INSERT INTO tblHopDong (MaPhongTro, MaKhachThue, HinhThucThue, TienCoc, NgayKi, NgayHetHan, GhiChu)
VALUES
(1, 1, N'Tháng', 1000000, '2026-03-01', '2026-09-01', N'Hợp đồng 6 tháng'),
(2, 2, N'Năm', 3000000, '2026-01-15', '2027-01-15', N'Hợp đồng 1 năm');

-- Điện nước
INSERT INTO tblDienNuoc (MaPhongTro, ThangNam, SoDienCu, SoDienMoi, TieuThuDien, TienDien,
                         SoNuocCu, SoNuocMoi, TieuThuNuoc, TienNuoc)
VALUES
(1, '03/2026', 120, 150, 30, 30*3500, 50, 60, 10, 10*12000),
(2, '03/2026', 200, 240, 40, 40*3500, 80, 95, 15, 15*12000);

-- Hóa đơn
INSERT INTO tblHoaDon (MaPhongTro, ThangNam, TienSinhHoat, Internet, DichVuKhac, ChuyenKhoan, GhiChu, TrangThai)
VALUES
(1, '03/2026', 50000, 100000, 20000, N'VCB-123456', N'Thanh toán qua ngân hàng', N'Chưa thanh toán'),
(2, '03/2026', 60000, 120000, 30000, N'ACB-654321', N'Thanh toán tiền mặt', N'Đã thanh toán');

-- Chi tiết hóa đơn
INSERT INTO tblChiTietHoaDon (MaHoaDonCT, STT, TenDichVu, ChiSoCu, ChiSoMoi, SoLuong, ThanhTien)
VALUES
(1, 1, N'Điện', 120, 150, 30, 30*3500),
(1, 2, N'Nước', 50, 60, 10, 10*12000),
(2, 1, N'Điện', 200, 240, 40, 40*3500),
(2, 2, N'Nước', 80, 95, 15, 15*12000);