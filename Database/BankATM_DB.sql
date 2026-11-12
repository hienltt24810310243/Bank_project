CREATE DATABASE BankATM_DB;
GO
USE BankATM_DB;
GO

CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    CCCD VARCHAR(12) UNIQUE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    Email VARCHAR(100),
    DiaChi NVARCHAR(200)
);

CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    MatKhau VARCHAR(100) NOT NULL
);

CREATE TABLE TaiKhoan (
    SoTaiKhoan VARCHAR(20) PRIMARY KEY,
    MaKH VARCHAR(10) FOREIGN KEY REFERENCES KhachHang(MaKH),
    SoDu DECIMAL(18, 2) NOT NULL DEFAULT 0,
    NgayMo DATE DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động'
);

CREATE TABLE TheATM (
    SoThe VARCHAR(16) PRIMARY KEY,
    SoTaiKhoan VARCHAR(20) FOREIGN KEY REFERENCES TaiKhoan(SoTaiKhoan),
    MaPIN VARCHAR(100) NOT NULL,
    NgayHetHan DATE NOT NULL,
    SoLanSaiPIN INT DEFAULT 0,
    IsLocked BIT DEFAULT 0
);

CREATE TABLE MayATM (
    MaATM VARCHAR(10) PRIMARY KEY,
    TenTram NVARCHAR(100) NOT NULL,
    ViTri NVARCHAR(200) NOT NULL,
    TongTienMat DECIMAL(18, 2) NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(20) DEFAULT N'Online'
);

CREATE TABLE KhayTienATM (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaATM VARCHAR(10) FOREIGN KEY REFERENCES MayATM(MaATM),
    MenhGia INT NOT NULL,
    SoLuongTo INT NOT NULL
);

CREATE TABLE GiaoDich (
    MaGD VARCHAR(20) PRIMARY KEY,
    SoTaiKhoan VARCHAR(20) FOREIGN KEY REFERENCES TaiKhoan(SoTaiKhoan),
    MaATM VARCHAR(10) FOREIGN KEY REFERENCES MayATM(MaATM),
    LoaiGD NVARCHAR(50) NOT NULL,
    SoTien DECIMAL(18, 2) NOT NULL,
    SoDuSauGD DECIMAL(18, 2) NOT NULL,
    ThoiGian DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(30) NOT NULL
);

CREATE TABLE ChiTietChuyenKhoan (
    MaGD VARCHAR(20) PRIMARY KEY FOREIGN KEY REFERENCES GiaoDich(MaGD),
    SoTKNhan VARCHAR(20) FOREIGN KEY REFERENCES TaiKhoan(SoTaiKhoan),
    NoiDung NVARCHAR(255)
);

GO
DELETE FROM ChiTietChuyenKhoan;
DELETE FROM GiaoDich;
DELETE FROM KhayTienATM;
DELETE FROM TheATM;
DELETE FROM TaiKhoan;
DELETE FROM MayATM;
DELETE FROM NhanVien;
DELETE FROM KhachHang;

INSERT INTO KhachHang VALUES 
('KH001', N'Nguyễn Văn An', '001202001111', '0912345678', 'an.nguyen@gmail.com', N'235 Hoàng Quốc Việt, Cầu Giấy, Hà Nội'),
('KH002', N'Trần Thị Bình', '001202002222', '0987654321', 'binh.tran@gmail.com', N'12 Phạm Văn Đồng, Bắc Từ Liêm, Hà Nội'),
('KH003', N'Lê Minh Cường', '001202003333', '0901234567', 'cuong.le@gmail.com', N'100 Tây Sơn, Đống Đa, Hà Nội');

INSERT INTO NhanVien VALUES 
('NV01', N'Đỗ Quang Admin', N'Quản trị viên', '123456'),
('NV02', N'Nguyễn Văn Kỹ Thuật', N'Kỹ thuật viên ATM', '123456');

INSERT INTO TaiKhoan VALUES 
('1001', 'KH001', 8500000, GETDATE(), N'Hoạt động'),
('1002', 'KH002', 15200000, GETDATE(), N'Hoạt động'),
('1003', 'KH003', 250000, GETDATE(), N'Khóa tạm thời');

INSERT INTO TheATM VALUES 
('9704000000001001', '1001', '123456', '2028-12-31', 0, 0),
('9704000000001002', '1002', '654321', '2028-12-31', 0, 0),
('9704000000001003', '1003', '111111', '2028-12-31', 3, 1);

INSERT INTO MayATM VALUES 
('ATM01', N'ATM ĐH Điện Lực (EPU)', N'235 Hoàng Quốc Việt, Cầu Giấy, Hà Nội', 90000000, N'Online'),
('ATM02', N'ATM Chi nhánh Đống Đa', N'100 Tây Sơn, Đống Đa, Hà Nội', 75000000, N'Online');

INSERT INTO KhayTienATM (MaATM, MenhGia, SoLuongTo) VALUES 
('ATM01', 500000, 100),
('ATM01', 200000, 100),
('ATM01', 100000, 150),
('ATM01', 50000,  100),
('ATM02', 500000, 150);

INSERT INTO GiaoDich VALUES 
('GD01', '1001', 'ATM01', N'Rút tiền', 500000, 8000000, '2026-11-10 20:22:00', N'Thành công'),
('GD02', '1002', 'ATM01', N'Chuyển khoản', 1000000, 14200000, '2026-11-10 20:25:00', N'Thành công'),
('GD03', '1001', 'ATM01', N'Rút tiền', 1000000, 7500000, '2026-11-08 15:30:00', N'Thành công'),
('GD04', '1001', 'ATM01', N'Rút tiền', 2000000, 8500000, '2026-11-05 10:15:00', N'Thành công'),
('GD05', '1001', 'ATM01', N'Mở tài khoản EPU', 0, 10500000, '2026-10-28 08:30:00', N'Thành công'),
('GD06', '1002', 'ATM01', N'Rút tiền', 2000000, 15200000, '2026-11-09 11:20:00', N'Thành công'),
('GD07', '1002', 'ATM01', N'Mở tài khoản EPU', 0, 17200000, '2026-10-25 09:00:00', N'Thành công'),
('GD08', '1003', 'ATM01', N'Rút tiền', 50000, 250000, '2026-11-01 16:45:00', N'Thành công');

INSERT INTO ChiTietChuyenKhoan VALUES 
('GD02', '1001', N'Chuyen tien hoc phi');
GO

select* from KhachHang
select* from TaiKhoan
select* from TheATM