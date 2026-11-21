using System.Security.Cryptography;

namespace WebDoAn.Services
{
    public  static class MatKhau
    {
      
            private const int SoVong = 100000;
            private const int DoDaiMuoi = 16;
            private const int DoDaiBam = 32;

            public static string MaHoa(string matKhau)
            {
                byte[] muoi = RandomNumberGenerator.GetBytes(DoDaiMuoi);
                byte[] bam = Rfc2898DeriveBytes.Pbkdf2(matKhau, muoi, SoVong, HashAlgorithmName.SHA256, DoDaiBam);
                return SoVong + "." + Convert.ToBase64String(muoi) + "." + Convert.ToBase64String(bam);
            }

            public static bool KiemTra(string matKhau, string chuoiDaLuu)
            {
                if (string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(chuoiDaLuu)) return false;
                var phan = chuoiDaLuu.Split('.');
                if (phan.Length != 3 || !int.TryParse(phan[0], out int soVong)) return false;
                byte[] muoi, bamDaLuu;
                try { muoi = Convert.FromBase64String(phan[1]); bamDaLuu = Convert.FromBase64String(phan[2]); }
                catch (FormatException) { return false; }
                byte[] bam = Rfc2898DeriveBytes.Pbkdf2(matKhau, muoi, soVong, HashAlgorithmName.SHA256, bamDaLuu.Length);
                return CryptographicOperations.FixedTimeEquals(bam, bamDaLuu);
            }
    }
}
