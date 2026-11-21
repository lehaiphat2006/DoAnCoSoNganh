
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDoAn.Models;
using WebDoAn.Data;

public class ThuongHieusController : Controller
{
    private readonly AppDbContext _context;

    public ThuongHieusController(AppDbContext context)
    {
        _context = context;
    }

    // GET: THUONGHIEUS
    public async Task<IActionResult> Index()    
    {
        return View(_context.ThuongHieu_DS());
    }

    // GET: THUONGHIEUS/Details/5
    public async Task<IActionResult> Details(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var thuonghieu = await _context.ThuongHieus
            .FirstOrDefaultAsync(m => m.MaThuongHieu == id);
        if (thuonghieu == null)
        {
            return NotFound();
        }

        return View(thuonghieu);
    }

    // GET: THUONGHIEUS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: THUONGHIEUS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaThuongHieu,TenThuongHieu")] ThuongHieu thuonghieu)
    {
        if (ModelState.IsValid)
        {
            //_context.Add(thuonghieu);
            //await _context.SaveChangesAsync();
            _context.ThuongHieu_Them(thuonghieu);
            return RedirectToAction(nameof(Index));
        }
        return View(thuonghieu);
    }

    // GET: THUONGHIEUS/Edit/5
    public async Task<IActionResult> Edit(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var thuonghieu = await _context.ThuongHieus.FindAsync(id);
        if (thuonghieu == null)
        {
            return NotFound();
        }
        return View(thuonghieu);
    }

    // POST: THUONGHIEUS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(byte? mathuonghieu, [Bind("MaThuongHieu,TenThuongHieu")] ThuongHieu thuonghieu)
    {
        if (mathuonghieu != thuonghieu.MaThuongHieu)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                //_context.Update(thuonghieu);
                _context.ThuongHieu_Sua(thuonghieu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuongHieuExists(thuonghieu.MaThuongHieu))
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
        return View(thuonghieu);
    }

    // GET: THUONGHIEUS/Delete/5
    public async Task<IActionResult> Delete(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var thuonghieu = await _context.ThuongHieus
            .FirstOrDefaultAsync(m => m.MaThuongHieu == id);
        if (thuonghieu == null)
        {
            return NotFound();
        }

        return View(thuonghieu);
    }

    // POST: THUONGHIEUS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(byte? id)
    {
        var thuonghieu = await _context.ThuongHieus.FindAsync(id);
        if (thuonghieu != null)
        {
            //_context.ThuongHieus.Remove(thuonghieu);
            _context.ThuongHieu_Xoa(thuonghieu);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ThuongHieuExists(byte? id)
    {
        return _context.ThuongHieus.Any(e => e.MaThuongHieu == id);
    }
}
