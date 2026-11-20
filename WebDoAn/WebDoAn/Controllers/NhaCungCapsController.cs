
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDoAn.Models;
using WebDoAn.Data;

public class NhaCungCapsController : Controller
{
    private readonly AppDbContext _context;

    public NhaCungCapsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: NHACUNGCAPS
    public async Task<IActionResult> Index()    
    {
        //return View(await _context.NhaCungCaps.ToListAsync());
        return View(_context.NhaCungCap_DS());
    }

    // GET: NHACUNGCAPS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nhacungcap = await _context.NhaCungCaps
            .FirstOrDefaultAsync(m => m.MaNhaCungCap == id);
        if (nhacungcap == null)
        {
            return NotFound();
        }

        return View(nhacungcap);
    }

    // GET: NHACUNGCAPS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NHACUNGCAPS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaNhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai,Email,NguoiLienHe,MaSoThue,DieuKhoanThanhToan,TrangThai")] NhaCungCap nhacungcap)
    {
        if (ModelState.IsValid)
        {
            //_context.Add(nhacungcap);
            //await _context.SaveChangesAsync();
            _context.NhaCungCap_Them(nhacungcap);
            return RedirectToAction(nameof(Index));
        }
        return View(nhacungcap);
    }

    // GET: NHACUNGCAPS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nhacungcap = await _context.NhaCungCaps.FindAsync(id);
        if (nhacungcap == null)
        {
            return NotFound();
        }
        return View(nhacungcap);
    }

    // POST: NHACUNGCAPS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("MaNhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai,Email,NguoiLienHe,MaSoThue,DieuKhoanThanhToan,TrangThai")] NhaCungCap nhacungcap)
    {
        if (id != nhacungcap.MaNhaCungCap)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                //_context.Update(nhacungcap);
                _context.NhaCungCap_Sua(nhacungcap);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaCungCapExists(nhacungcap.MaNhaCungCap))
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
        return View(nhacungcap);
    }

    // GET: NHACUNGCAPS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nhacungcap = await _context.NhaCungCaps
            .FirstOrDefaultAsync(m => m.MaNhaCungCap == id);
        if (nhacungcap == null)
        {
            return NotFound();
        }

        return View(nhacungcap);
    }

    // POST: NHACUNGCAPS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var nhacungcap = await _context.NhaCungCaps.FindAsync(id);
        if (nhacungcap != null)
        {
            //_context.NhaCungCaps.Remove(nhacungcap);
            _context.NhaCungCap_Xoa(nhacungcap);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NhaCungCapExists(int? id)
    {
        return _context.NhaCungCaps.Any(e => e.MaNhaCungCap == id);
    }
}
