
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDoAn.Data;
using WebDoAn.Models;
using WebDoAn.Services;
// Trang quan ly nguoi dung: chi Quan tri vien
//[Authorize(Roles = VaiTro.QuanTriVien)]
public class NguoiDungsController : Controller
{
    private readonly AppDbContext _context;

    public NguoiDungsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: NGUOIDUNGS
    public async Task<IActionResult> Index()    
    {
        return View(_context.NguoiDung_DS());
    }

    // GET: NGUOIDUNGS/Details/5
    public async Task<IActionResult> Details(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nguoidung = await _context.NguoiDungs
            .FirstOrDefaultAsync(m => m.MaNguoiDung == id);
        if (nguoidung == null)
        {
            return NotFound();
        }

        return View(nguoidung);
    }

    // GET: NGUOIDUNGS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NGUOIDUNGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaNguoiDung,TenDangNhap,HoTen,SoDienThoai,Email,VaiTro,KichHoat")] NguoiDung nguoidung, string matKhau)
    {
        ModelState.Remove("MatKhauMaHoa");
        if (string.IsNullOrWhiteSpace(matKhau) || matKhau.Length < 6)
            ModelState.AddModelError("", "Mật khẩu phải có ít nhất 6 ký tự.");
        if (_context.NguoiDung_TheoTen(nguoidung.TenDangNhap?.Trim() ?? "") != null)
            ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại.");
        if (ModelState.IsValid)
        {
            //_context.Add(nguoidung);
            //await _context.SaveChangesAsync();
            nguoidung.TenDangNhap = nguoidung.TenDangNhap.Trim();
            nguoidung.MatKhauMaHoa = MatKhau.MaHoa(matKhau);   // tạo giá trị thật
            _context.NguoiDung_Them(nguoidung);
            return RedirectToAction(nameof(Index));
        }
        return View(nguoidung);
    }

    // GET: NGUOIDUNGS/Edit/5
    public async Task<IActionResult> Edit(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nguoidung = await _context.NguoiDungs.FindAsync(id);
        if (nguoidung == null)
        {
            return NotFound();
        }
        return View(nguoidung);
    }

    // POST: NGUOIDUNGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(byte? id, [Bind("MaNguoiDung,TenDangNhap,HoTen,SoDienThoai,Email,VaiTro,KichHoat")] NguoiDung nguoidung)
    {
        if (id != nguoidung.MaNguoiDung)
        {
            return NotFound();
        }
        ModelState.Remove("MatKhauMaHoa");
        if (ModelState.IsValid)
        {
            try
            {
                //_context.Update(nguoidung);
                _context.NguoiDung_Sua(nguoidung);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(nguoidung.MaNguoiDung))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(nguoidung);
    }

    // GET: NGUOIDUNGS/Delete/5
    public async Task<IActionResult> Delete(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nguoidung = await _context.NguoiDungs
            .FirstOrDefaultAsync(m => m.MaNguoiDung == id);
        if (nguoidung == null)
        {
            return NotFound();
        }

        return View(nguoidung);
    }

    // POST: NGUOIDUNGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(byte? id)
    {
        var nguoidung = await _context.NguoiDungs.FindAsync(id);
        if (nguoidung != null)
        {
            //_context.NguoiDungs.Remove(nguoidung);
            _context.NguoiDung_Xoa(nguoidung);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NguoiDungExists(byte? id)
    {
        return _context.NguoiDungs.Any(e => e.MaNguoiDung == id);
    }

    // ----- Dat lai mat khau (Quan tri vien dat mat khau moi cho nguoi khac) -----
    public IActionResult DatLaiMatKhau(byte? id)
    {
        if (id == null) return NotFound();
        var nd = _context.NguoiDung_CT(id.Value);
        return nd == null ? NotFound() : View(nd);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult DatLaiMatKhau(byte id, string matKhauMoi)
    {
        var nd = _context.NguoiDung_CT(id);
        if (nd == null) return NotFound();
        if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
        {
            ModelState.AddModelError("", "Mật khẩu mới phải có ít nhất 6 ký tự.");
            return View(nd);
        }
        _context.NguoiDung_DoiMatKhau(id, MatKhau.MaHoa(matKhauMoi));
        TempData["ThanhCong"] = "Đã đặt lại mật khẩu cho " + nd.TenDangNhap + ".";
        return RedirectToAction(nameof(Index));
    }
}
