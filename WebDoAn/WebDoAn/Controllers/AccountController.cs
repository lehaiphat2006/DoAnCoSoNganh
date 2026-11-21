using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebDoAn.Data;
using WebDoAn.Models;
using WebDoAn.Services;

namespace WebDoAn.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context) { _context = context; }

        // ---------- Dang nhap ----------
        [HttpGet, AllowAnonymous]
        public IActionResult DangNhap(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new DangNhapViewModel());
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> DangNhap(DangNhapViewModel vm, string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid) return View(vm);

            var user = _context.NguoiDung_TheoTen(vm.TenDangNhap.Trim());
            if (user == null || !MatKhau.KiemTra(vm.MatKhau, user.MatKhauMaHoa))
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu.");
                return View(vm);
            }
            if (!user.KichHoat)
            {
                ModelState.AddModelError("", "Tài khoản chưa được kích hoạt hoặc đã bị khóa. Hãy liên hệ Quản trị viên.");
                return View(vm);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.MaNguoiDung.ToString()),
                new Claim(ClaimTypes.Name, user.HoTen),
                new Claim(ClaimTypes.Role, user.VaiTro)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        // ---------- Dang ky ----------
        [HttpGet, AllowAnonymous]
        public IActionResult DangKy() => View(new DangKyViewModel());

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public IActionResult DangKy(DangKyViewModel vm)
        {
            // Chan truong hop sua HTML de tu chon vai tro Quan tri vien
            if (!VaiTro.DuocDangKy.Contains(vm.VaiTro))
                ModelState.AddModelError("VaiTro", "Vai trò không hợp lệ.");

            if (ModelState.IsValid && _context.NguoiDung_TheoTen(vm.TenDangNhap.Trim()) != null)
                ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã có người dùng.");

            if (!ModelState.IsValid) return View(vm);

            var nd = new NguoiDung
            {
                TenDangNhap = vm.TenDangNhap.Trim(),
                MatKhauMaHoa = MatKhau.MaHoa(vm.MatKhau),
                HoTen = vm.HoTen.Trim(),
                SoDienThoai = vm.SoDienThoai,
                Email = vm.Email,
                VaiTro = vm.VaiTro,
                KichHoat = false            // cho Quan tri vien duyet
            };
            _context.NguoiDung_Them(nd);

            TempData["ThanhCong"] = "Đăng ký thành công. Tài khoản đang chờ Quản trị viên kích hoạt.";
            return RedirectToAction("DangNhap");
        }

        // ---------- Dang xuat ----------
        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("DangNhap");
        }

        // ---------- Khong du quyen ----------
        [AllowAnonymous]
        public IActionResult TuChoi() => View();

        // ---------- Doi mat khau (nguoi dung tu doi) ----------
        [HttpGet, Authorize]
        public IActionResult DoiMatKhau() => View(new DoiMatKhauViewModel());

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult DoiMatKhau(DoiMatKhauViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            byte ma = byte.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = _context.NguoiDung_CT(ma);
            if (user == null) return RedirectToAction("DangNhap");

            if (!MatKhau.KiemTra(vm.MatKhauCu, user.MatKhauMaHoa))
            {
                ModelState.AddModelError("MatKhauCu", "Mật khẩu hiện tại không đúng.");
                return View(vm);
            }
            if (vm.MatKhauMoi == vm.MatKhauCu)
            {
                ModelState.AddModelError("MatKhauMoi", "Mật khẩu mới phải khác mật khẩu hiện tại.");
                return View(vm);
            }

            _context.NguoiDung_DoiMatKhau(ma, MatKhau.MaHoa(vm.MatKhauMoi));
            TempData["ThanhCong"] = "Đổi mật khẩu thành công.";
            return RedirectToAction("Index", "Home");
        }
    }
}
