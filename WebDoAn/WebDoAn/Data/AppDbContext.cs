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
        //public NhaCungCap NhaCungCap_CT(int ma)
        //{
        //    return NhaCungCaps.FromSqlRaw("EXEC NhaCungCap_CT @MaNhaCungCap",
        //            new SqlParameter("@MaNhaCungCap", ma))
        //        .AsEnumerable().FirstOrDefault();
        //}
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
    }
}
    

