
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDoAn.Models;
using WebDoAn.Data;

public class LoaiHangsController : Controller
{
    private readonly AppDbContext _context;

    public LoaiHangsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: LOAIHANGS
    public async Task<IActionResult> Index()    
    {
        return View(_context.LoaiHang_DS());
    }

    // GET: LOAIHANGS/Details/5
    public async Task<IActionResult> Details(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var loaihang = await _context.LoaiHangs
            .FirstOrDefaultAsync(m => m.MaLoaiHang == id);
        if (loaihang == null)
        {
            return NotFound();
        }

        return View(loaihang);
    }

    // GET: LOAIHANGS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LOAIHANGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaLoaiHang,TenLoaiHang")] LoaiHang loaihang)
    {
        if (ModelState.IsValid)
        {
            //_context.Add(loaihang);
            //await _context.SaveChangesAsync();
            _context.LoaiHang_Them(loaihang);
            return RedirectToAction(nameof(Index));
        }
        return View(loaihang);
    }

    // GET: LOAIHANGS/Edit/5
    public async Task<IActionResult> Edit(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var loaihang = await _context.LoaiHangs.FindAsync(id);
        if (loaihang == null)
        {
            return NotFound();
        }
        return View(loaihang);
    }

    // POST: LOAIHANGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(byte? id, [Bind("MaLoaiHang,TenLoaiHang")] LoaiHang loaihang)
    {
        if (id != loaihang.MaLoaiHang)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.LoaiHang_Sua(loaihang);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiHangExists(loaihang.MaLoaiHang))
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
        return View(loaihang);
    }

    // GET: LOAIHANGS/Delete/5
    public async Task<IActionResult> Delete(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var loaihang = await _context.LoaiHangs
            .FirstOrDefaultAsync(m => m.MaLoaiHang == id);
        if (loaihang == null)
        {
            return NotFound();
        }

        return View(loaihang);
    }

    // POST: LOAIHANGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(byte? id)
    {
        var loaihang = await _context.LoaiHangs.FindAsync(id);
        if (loaihang != null)
        {
            _context.LoaiHang_Xoa(loaihang);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LoaiHangExists(byte? id)
    {
        return _context.LoaiHangs.Any(e => e.MaLoaiHang == id);
    }
}
