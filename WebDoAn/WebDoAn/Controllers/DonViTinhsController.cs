
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDoAn.Models;
using WebDoAn.Data;

public class DonViTinhsController : Controller
{
    private readonly AppDbContext _context;

    public DonViTinhsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: DONVITINHS
    public async Task<IActionResult> Index()    
    {
        return View(_context.DonViTinh_DS());
    }

    // GET: DONVITINHS/Details/5
    public async Task<IActionResult> Details(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var donvitinh = await _context.DonViTinhs
            .FirstOrDefaultAsync(m => m.MaDonViTinh == id);
        if (donvitinh == null)
        {
            return NotFound();
        }

        return View(donvitinh);
    }

    // GET: DONVITINHS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DONVITINHS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaDonViTinh,TenDonViTinh")] DonViTinh donvitinh)
    {
        if (ModelState.IsValid)
        {
            //_context.Add(donvitinh);
            //await _context.SaveChangesAsync();
            _context.DonViTinh_Them(donvitinh);
            return RedirectToAction(nameof(Index));
        }
        return View(donvitinh);
    }

    // GET: DONVITINHS/Edit/5
    public async Task<IActionResult> Edit(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var donvitinh = await _context.DonViTinhs.FindAsync(id);
        if (donvitinh == null)
        {
            return NotFound();
        }
        return View(donvitinh);
    }

    // POST: DONVITINHS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(byte? id, [Bind("MaDonViTinh,TenDonViTinh")] DonViTinh donvitinh)
    {
        if (id != donvitinh.MaDonViTinh)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                //_context.Update(donvitinh);
                _context.DonViTinh_Sua(donvitinh);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonViTinhExists(donvitinh.MaDonViTinh))
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
        return View(donvitinh);
    }

    // GET: DONVITINHS/Delete/5
    public async Task<IActionResult> Delete(byte? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var donvitinh = await _context.DonViTinhs
            .FirstOrDefaultAsync(m => m.MaDonViTinh == id);
        if (donvitinh == null)
        {
            return NotFound();
        }

        return View(donvitinh);
    }

    // POST: DONVITINHS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(byte? id)
    {
        var donvitinh = await _context.DonViTinhs.FindAsync(id);
        if (donvitinh != null)
        {
            //_context.DonViTinhs.Remove(donvitinh);
            _context.DonViTinh_Xoa(donvitinh);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DonViTinhExists(byte? id)
    {
        return _context.DonViTinhs.Any(e => e.MaDonViTinh == id);
    }
}
