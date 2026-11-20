create database DoAnCoSoNganh
go
DROP TABLE IF EXISTS ThanhToan;
DROP TABLE IF EXISTS ChiTietPhieuNhap;
DROP TABLE IF EXISTS PhieuNhap;
DROP TABLE IF EXISTS ChiTietDonMua;
DROP TABLE IF EXISTS DonMua;
DROP TABLE IF EXISTS SanPham;
DROP TABLE IF EXISTS NhaCungCap;
DROP TABLE IF EXISTS DonViTinh;
DROP TABLE IF EXISTS ThuongHieu;
DROP TABLE IF EXISTS LoaiHang;
DROP TABLE IF EXISTS NguoiDung;

CREATE TABLE NguoiDung (
  MaNguoiDung tinyint IDENTITY(1,1) NOT NULL PRIMARY KEY,
  TenDangNhap varchar(50) NOT NULL UNIQUE,
  MatKhauMaHoa varchar(255) NOT NULL,
  HoTen nvarchar(100) NOT NULL,
  SoDienThoai varchar(15) NULL,
  Email varchar(100) NULL,
  VaiTro nvarchar(30) NOT NULL
    CHECK (VaiTro IN (N'Quản trị viên', N'Nhân viên mua hàng', N'Nhân viên kho', N'Quản lý cửa hàng')),
  KichHoat bit NOT NULL DEFAULT 1
);

CREATE TABLE LoaiHang (
  MaLoaiHang tinyint IDENTITY(1,1) NOT NULL PRIMARY KEY,
  TenLoaiHang nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE ThuongHieu (
  MaThuongHieu tinyint IDENTITY(1,1) NOT NULL PRIMARY KEY,
  TenThuongHieu nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE DonViTinh (
  MaDonViTinh tinyint IDENTITY(1,1) NOT NULL PRIMARY KEY,
  TenDonViTinh nvarchar(50) NOT NULL UNIQUE
);

CREATE TABLE NhaCungCap (
  MaNhaCungCap int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  TenNhaCungCap nvarchar(150) NOT NULL,
  DiaChi nvarchar(255) NULL,
  SoDienThoai varchar(15) NULL,
  Email varchar(100) NULL,
  NguoiLienHe nvarchar(100) NULL,
  MaSoThue varchar(20) NULL,
  DieuKhoanThanhToan nvarchar(100) NULL,
  TrangThai nvarchar(30) NOT NULL DEFAULT N'Đang hợp tác'
    CHECK (TrangThai IN (N'Đang hợp tác', N'Ngừng hợp tác'))
);

/* Ma so thue duy nhat neu co (cho phep nhieu dong NULL) */
CREATE UNIQUE INDEX UX_NhaCungCap_MaSoThue ON NhaCungCap(MaSoThue) WHERE MaSoThue IS NOT NULL;

CREATE TABLE SanPham (
  MaSanPham int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  TenSanPham nvarchar(200) NOT NULL,
  MoTa nvarchar(500) NULL,
  GiaNhapThamKhao decimal(18,2) NOT NULL DEFAULT 0 CHECK (GiaNhapThamKhao >= 0),
  SoLuongTon int NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
  MucTonToiThieu int NOT NULL DEFAULT 0 CHECK (MucTonToiThieu >= 0),
  TrangThai nvarchar(30) NOT NULL DEFAULT N'Đang kinh doanh'
    CHECK (TrangThai IN (N'Đang kinh doanh', N'Ngừng kinh doanh')),
  MaLoaiHang tinyint NOT NULL REFERENCES LoaiHang(MaLoaiHang),
  MaThuongHieu tinyint NOT NULL REFERENCES ThuongHieu(MaThuongHieu),
  MaDonViTinh tinyint NOT NULL REFERENCES DonViTinh(MaDonViTinh)
);

CREATE TABLE DonMua (
  MaDonMua int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  NgayLap date NOT NULL,
  NgayDuKienGiao date NULL,
  TrangThai nvarchar(30) NOT NULL DEFAULT N'Nháp'
    CHECK (TrangThai IN (N'Nháp', N'Chờ duyệt', N'Đã duyệt', N'Đang nhận hàng', N'Hoàn tất', N'Đã hủy')),
  TongTien decimal(18,2) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
  MaNhaCungCap int NOT NULL REFERENCES NhaCungCap(MaNhaCungCap),
  MaNguoiLap tinyint NOT NULL REFERENCES NguoiDung(MaNguoiDung),
  CHECK (NgayDuKienGiao IS NULL OR NgayDuKienGiao >= NgayLap)
);

CREATE TABLE ChiTietDonMua (
  MaChiTietDonMua int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  SoLuongDat int NOT NULL CHECK (SoLuongDat > 0),
  DonGia decimal(18,2) NOT NULL CHECK (DonGia >= 0),
  ThanhTien decimal(18,2) NOT NULL,
  SoLuongDaNhan int NOT NULL DEFAULT 0,
  MaDonMua int NOT NULL REFERENCES DonMua(MaDonMua),
  MaSanPham int NOT NULL REFERENCES SanPham(MaSanPham),
  CONSTRAINT UQ_ChiTietDonMua UNIQUE (MaDonMua, MaSanPham),
  CHECK (SoLuongDaNhan >= 0 AND SoLuongDaNhan <= SoLuongDat)
);

CREATE TABLE PhieuNhap (
  MaPhieuNhap int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  NgayNhan date NOT NULL,
  TrangThai nvarchar(30) NOT NULL DEFAULT N'Nháp'
    CHECK (TrangThai IN (N'Nháp', N'Đã xác nhận', N'Đã hủy')),
  MaDonMua int NOT NULL REFERENCES DonMua(MaDonMua),
  MaNguoiNhan tinyint NOT NULL REFERENCES NguoiDung(MaNguoiDung)
);

CREATE TABLE ChiTietPhieuNhap (
  MaChiTietPhieuNhap int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  SoLuongNhan int NOT NULL CHECK (SoLuongNhan > 0),
  MaPhieuNhap int NOT NULL REFERENCES PhieuNhap(MaPhieuNhap),
  MaChiTietDonMua int NOT NULL REFERENCES ChiTietDonMua(MaChiTietDonMua),
  CONSTRAINT UQ_ChiTietPhieuNhap UNIQUE (MaPhieuNhap, MaChiTietDonMua)
);

CREATE TABLE ThanhToan (
  MaThanhToan int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  NgayTra date NOT NULL,
  SoTien decimal(18,2) NOT NULL CHECK (SoTien > 0),
  HinhThuc nvarchar(30) NOT NULL CHECK (HinhThuc IN (N'Tiền mặt', N'Chuyển khoản')),
  GhiChu nvarchar(255) NULL,
  MaDonMua int NOT NULL REFERENCES DonMua(MaDonMua),
  MaNguoiGhi tinyint NOT NULL REFERENCES NguoiDung(MaNguoiDung)
);

/* ---------- Du lieu mau ---------- */
INSERT INTO LoaiHang(TenLoaiHang) VALUES
 (N'CPU'),(N'Bo mạch chủ'),(N'RAM'),(N'Ổ cứng SSD'),(N'Ổ cứng HDD'),(N'Card đồ họa'),
 (N'Nguồn máy tính'),(N'Vỏ case'),(N'Màn hình'),(N'Bàn phím'),(N'Chuột');

INSERT INTO ThuongHieu(TenThuongHieu) VALUES
 (N'Intel'),(N'AMD'),(N'ASUS'),(N'MSI'),(N'Gigabyte'),(N'Kingston'),
 (N'Samsung'),(N'Corsair'),(N'Logitech'),(N'Dell');

INSERT INTO DonViTinh(TenDonViTinh) VALUES (N'Cái'),(N'Chiếc'),(N'Bộ'),(N'Hộp');

/* Nha cung cap mau */
INSERT INTO NhaCungCap(TenNhaCungCap, DiaChi, SoDienThoai, Email, NguoiLienHe, MaSoThue, DieuKhoanThanhToan) VALUES
 (N'Công ty TNHH Phân phối Linh kiện Á Châu', N'Quận 1, TP.HCM', '0281234567', 'achau@example.com', N'Nguyễn Văn An', '0301234567', N'Trả sau 30 ngày'),
 (N'Công ty CP Công nghệ Bắc Nam', N'Quận Cầu Giấy, Hà Nội', '0241234567', 'bacnam@example.com', N'Trần Thị Bình', '0101234567', N'Trả sau 15 ngày'),
 (N'Cửa hàng Linh kiện Miền Trung', N'Nha Trang, Khánh Hòa', '0258123456', 'mientrung@example.com', N'Lê Văn Cường', NULL, N'Thanh toán ngay');

/* San pham mau  */
INSERT INTO SanPham(TenSanPham, MoTa, GiaNhapThamKhao, SoLuongTon, MucTonToiThieu, MaLoaiHang, MaThuongHieu, MaDonViTinh)
SELECT N'CPU Intel Core i5 (mẫu)', N'Bộ vi xử lý để bàn', 4500000, 10, 3,
  (SELECT MaLoaiHang FROM LoaiHang WHERE TenLoaiHang=N'CPU'),
  (SELECT MaThuongHieu FROM ThuongHieu WHERE TenThuongHieu=N'Intel'),
  (SELECT MaDonViTinh FROM DonViTinh WHERE TenDonViTinh=N'Cái');

INSERT INTO SanPham(TenSanPham, MoTa, GiaNhapThamKhao, SoLuongTon, MucTonToiThieu, MaLoaiHang, MaThuongHieu, MaDonViTinh)
SELECT N'RAM Kingston 8GB DDR4 (mẫu)', N'Bộ nhớ trong 8GB', 650000, 25, 10,
  (SELECT MaLoaiHang FROM LoaiHang WHERE TenLoaiHang=N'RAM'),
  (SELECT MaThuongHieu FROM ThuongHieu WHERE TenThuongHieu=N'Kingston'),
  (SELECT MaDonViTinh FROM DonViTinh WHERE TenDonViTinh=N'Chiếc');

INSERT INTO SanPham(TenSanPham, MoTa, GiaNhapThamKhao, SoLuongTon, MucTonToiThieu, MaLoaiHang, MaThuongHieu, MaDonViTinh)
SELECT N'SSD Samsung 500GB (mẫu)', N'Ổ cứng thể rắn 500GB', 1200000, 15, 5,
  (SELECT MaLoaiHang FROM LoaiHang WHERE TenLoaiHang=N'Ổ cứng SSD'),
  (SELECT MaThuongHieu FROM ThuongHieu WHERE TenThuongHieu=N'Samsung'),
  (SELECT MaDonViTinh FROM DonViTinh WHERE TenDonViTinh=N'Chiếc');

INSERT INTO SanPham(TenSanPham, MoTa, GiaNhapThamKhao, SoLuongTon, MucTonToiThieu, MaLoaiHang, MaThuongHieu, MaDonViTinh)
SELECT N'Chuột Logitech không dây (mẫu)', N'Chuột văn phòng', 250000, 40, 15,
  (SELECT MaLoaiHang FROM LoaiHang WHERE TenLoaiHang=N'Chuột'),
  (SELECT MaThuongHieu FROM ThuongHieu WHERE TenThuongHieu=N'Logitech'),
  (SELECT MaDonViTinh FROM DonViTinh WHERE TenDonViTinh=N'Cái');


 SELECT * FROM NhaCungCap