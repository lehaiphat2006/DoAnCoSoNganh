namespace WebDoAn.Services
{
    public static class VaiTro
    {
        // 4 vai tro - khop voi rang buoc CHECK trong bang NguoiDung
        
      
            public const string QuanTriVien = "Quản trị viên";
            public const string NhanVienMuaHang = "Nhân viên mua hàng";
            public const string NhanVienKho = "Nhân viên kho";
            public const string QuanLyCuaHang = "Quản lý cửa hàng";

            // Vai tro duoc phep tu chon khi dang ky (Quan tri vien do admin cap)
            public static readonly string[] DuocDangKy = { NhanVienMuaHang, NhanVienKho, QuanLyCuaHang };
        
    }
}
