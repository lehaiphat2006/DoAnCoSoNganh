using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebDoAn.Models;

namespace WebDoAn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
        // Bang NhaCungCap -------------------------------------------------------------------
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }

        // 1. Danh sach
        public List<NhaCungCap> NhaCungCap_DS()
        {
            return NhaCungCaps.FromSqlRaw("EXEC NhaCungCap_DS").ToList();
        }

        // 2. Chi tiet
        public int NhaCungCap_CT(NhaCungCap n)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NhaCungCap_CT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNhaCungCap", n.MaNhaCungCap));
            cmd.Parameters.Add(new SqlParameter("@TenNhaCungCap", n.TenNhaCungCap));
            cmd.Parameters.Add(new SqlParameter("@DiaChi", (object)n.DiaChi ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@SoDienThoai", (object)n.SoDienThoai ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@Email", (object)n.Email ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@NguoiLienHe", (object)n.NguoiLienHe ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@MaSoThue", (object)n.MaSoThue ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@DieuKhoanThanhToan", (object)n.DieuKhoanThanhToan ?? DBNull.Value));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }
        
        // 3. Them
        public int NhaCungCap_Them(NhaCungCap n)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NhaCungCap_Them";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TenNhaCungCap", n.TenNhaCungCap));
            cmd.Parameters.Add(new SqlParameter("@DiaChi", (object)n.DiaChi ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@SoDienThoai", (object)n.SoDienThoai ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@Email", (object)n.Email ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@NguoiLienHe", (object)n.NguoiLienHe ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@MaSoThue", (object)n.MaSoThue ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@DieuKhoanThanhToan", (object)n.DieuKhoanThanhToan ?? DBNull.Value));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 4. Sua
        public int NhaCungCap_Sua(NhaCungCap n)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NhaCungCap_Sua";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNhaCungCap", n.MaNhaCungCap));
            cmd.Parameters.Add(new SqlParameter("@TenNhaCungCap", n.TenNhaCungCap));
            cmd.Parameters.Add(new SqlParameter("@DiaChi", (object)n.DiaChi ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@SoDienThoai", (object)n.SoDienThoai ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@Email", (object)n.Email ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@NguoiLienHe", (object)n.NguoiLienHe ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@MaSoThue", (object)n.MaSoThue ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@DieuKhoanThanhToan", (object)n.DieuKhoanThanhToan ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@TrangThai", n.TrangThai));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 5. Xoa
        public int NhaCungCap_Xoa(NhaCungCap n)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NhaCungCap_Xoa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNhaCungCap", n.MaNhaCungCap));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // Bang LoaiHang -------------------------------------------------------------------
        public DbSet<LoaiHang> LoaiHangs { get; set; }

        // 1. Danh sach
        public List<LoaiHang> LoaiHang_DS()
        {
            return LoaiHangs.FromSqlRaw("EXEC LoaiHang_DS").ToList();
        }

        // 2. Chi tiet
        public int LoaiHang_CT(LoaiHang l)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "LoaiHang_CT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaLoaiHang", l.MaLoaiHang));
            cmd.Parameters.Add(new SqlParameter("@TenLoaiHang", l.TenLoaiHang));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }

        // 3. Them
        public int LoaiHang_Them(LoaiHang l)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "LoaiHang_Them";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@MaLoaiHang", l.MaLoaiHang));
            cmd.Parameters.Add(new SqlParameter("@TenLoaiHang", l.TenLoaiHang));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 4. Sua
        public int LoaiHang_Sua(LoaiHang l)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "LoaiHang_Sua";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaLoaiHang", l.MaLoaiHang));
            cmd.Parameters.Add(new SqlParameter("@TenLoaiHang", l.TenLoaiHang));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 5. Xoa
        public int LoaiHang_Xoa(LoaiHang l)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "LoaiHang_Xoa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaLoaiHang", l.MaLoaiHang));
            
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }


        // Bang ThuongHieu -------------------------------------------------------------------
        public DbSet<ThuongHieu> ThuongHieus { get; set; }

        // 1. Danh sach
        public List<ThuongHieu> ThuongHieu_DS()
        {
            return ThuongHieus.FromSqlRaw("EXEC ThuongHieu_DS").ToList();
        }

        // 2. Chi tiet
        public int ThuongHieu_CT(ThuongHieu th)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "ThuongHieu_CT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaThuongHieu", th.MaThuongHieu));
            cmd.Parameters.Add(new SqlParameter("@TenThuongHieu", th.TenThuongHieu));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }

        // 3. Them
        public int ThuongHieu_Them(ThuongHieu th)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "ThuongHieu_Them";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@MaLoaiHang", l.MaLoaiHang));
            cmd.Parameters.Add(new SqlParameter("@TenThuongHieu", th.TenThuongHieu));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 4. Sua
        public int ThuongHieu_Sua(ThuongHieu th)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "ThuongHieu_Sua";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaThuongHieu", th.MaThuongHieu));
            cmd.Parameters.Add(new SqlParameter("@TenThuongHieu", th.TenThuongHieu));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 5. Xoa
        public int ThuongHieu_Xoa(ThuongHieu th)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "ThuongHieu_Xoa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaThuongHieu", th.MaThuongHieu));

            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }


        // Bang DonViTinh -------------------------------------------------------------------
        public DbSet<DonViTinh> DonViTinhs { get; set; }

        // 1. Danh sach
        public List<DonViTinh> DonViTinh_DS()
        {
            return DonViTinhs.FromSqlRaw("EXEC DonViTinh_DS").ToList();
        }

        // 2. Chi tiet
        public int DonViTinh_CT(DonViTinh dvt)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "DonViTinh_CT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaDonViTinh", dvt.MaDonViTinh));
            cmd.Parameters.Add(new SqlParameter("@TenDonViTinh", dvt.TenDonViTinh));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }

        // 3. Them
        public int DonViTinh_Them(DonViTinh dvt)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "DonViTinh_Them";
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@TenDonViTinh", dvt.TenDonViTinh));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 4. Sua
        public int DonViTinh_Sua(DonViTinh dvt)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "DonViTinh_Sua";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaDonViTinh", dvt.MaDonViTinh));
            cmd.Parameters.Add(new SqlParameter("@TenDonViTinh", dvt.TenDonViTinh));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 5. Xoa
        public int DonViTinh_Xoa(DonViTinh dvt)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "DonViTinh_Xoa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaDonViTinh", dvt.MaDonViTinh));

            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // =================== NguoiDung ===================
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        // 1. Danh sach
        public List<NguoiDung> NguoiDung_DS()
        {
            return NguoiDungs.FromSqlRaw("EXEC NguoiDung_DS").ToList();
        }

        // 2. Chi tiet (nhan ma, tra ve 1 dong; null neu khong co)
        //public NguoiDung? NguoiDung_CT(byte ma)
        //{
        //    return NguoiDungs.FromSqlRaw("EXEC NguoiDung_CT @MaNguoiDung", new SqlParameter("@MaNguoiDung", ma))
        //        .AsEnumerable().FirstOrDefault();
        //}
        //public int NguoiDung_CT(NguoiDung nd)
        //{
        //    var cmd = Database.GetDbConnection().CreateCommand();
        //    cmd.CommandText = "NguoiDung_CT";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@MaNguoiDung", nd.MaNguoiDung));
        //    cmd.Parameters.Add(new SqlParameter("@TenDangNhap", nd.TenDangNhap));
        //    cmd.Parameters.Add(new SqlParameter("@MatKhauMaHoa", nd.MatKhauMaHoa));
        //    cmd.Parameters.Add(new SqlParameter("@HoTen", nd.HoTen));
        //    cmd.Parameters.Add(new SqlParameter("@SoDienThoai", (object)nd.SoDienThoai ?? DBNull.Value));
        //    cmd.Parameters.Add(new SqlParameter("@Email", (object)nd.Email ?? DBNull.Value));
        //    cmd.Parameters.Add(new SqlParameter("@VaiTro", nd.VaiTro));
        //    cmd.Parameters.Add(new SqlParameter("@KichHoat", nd.KichHoat));
        //    Database.OpenConnection();
        //    var kq = cmd.ExecuteNonQuery();
        //    Database.CloseConnection();
        //    return kq;
        //}
        // 2. Chi tiet (nhan ma, tra ve 1 dong; null neu khong co)
        public NguoiDung? NguoiDung_CT(byte ma)
        {
            return NguoiDungs.FromSqlRaw("EXEC NguoiDung_CT @MaNguoiDung",
                    new SqlParameter("@MaNguoiDung", ma))
                .AsEnumerable().FirstOrDefault();
        }
        // 3. Them
        public int NguoiDung_Them(NguoiDung nd)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NguoiDung_Them";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TenDangNhap", nd.TenDangNhap));
            cmd.Parameters.Add(new SqlParameter("@MatKhauMaHoa", nd.MatKhauMaHoa));
            cmd.Parameters.Add(new SqlParameter("@HoTen", nd.HoTen));
            cmd.Parameters.Add(new SqlParameter("@SoDienThoai", (object)nd.SoDienThoai ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@Email", (object)nd.Email ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@VaiTro", nd.VaiTro));
            cmd.Parameters.Add(new SqlParameter("@KichHoat", nd.KichHoat));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 4. Sua
        public int NguoiDung_Sua(NguoiDung nd)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NguoiDung_Sua";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNguoiDung", nd.MaNguoiDung));
            cmd.Parameters.Add(new SqlParameter("@TenDangNhap", nd.TenDangNhap));
            cmd.Parameters.Add(new SqlParameter("@HoTen", nd.HoTen));
            cmd.Parameters.Add(new SqlParameter("@SoDienThoai", (object)nd.SoDienThoai ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@Email", (object)nd.Email ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@VaiTro", nd.VaiTro));
            cmd.Parameters.Add(new SqlParameter("@KichHoat", nd.KichHoat));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // 5. Xoa
        public int NguoiDung_Xoa(NguoiDung nd)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NguoiDung_Xoa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNguoiDung", nd.MaNguoiDung));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

        // =================== Dang nhap ===================
        public NguoiDung? NguoiDung_TheoTen(string tenDangNhap)
        {
            return NguoiDungs.FromSqlRaw("EXEC NguoiDung_TheoTen @TenDangNhap",
                    new SqlParameter("@TenDangNhap", tenDangNhap))
                .AsEnumerable().FirstOrDefault();
        }

        public int NguoiDung_DoiMatKhau(byte ma, string matKhauMaHoa)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NguoiDung_DoiMatKhau";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNguoiDung", ma));
            cmd.Parameters.Add(new SqlParameter("@MatKhauMaHoa", matKhauMaHoa));
            Database.OpenConnection();
            try { return cmd.ExecuteNonQuery(); }
            finally { Database.CloseConnection(); }
        }

    }
}
    

