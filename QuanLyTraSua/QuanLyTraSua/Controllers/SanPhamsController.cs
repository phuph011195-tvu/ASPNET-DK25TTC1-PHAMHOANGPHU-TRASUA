
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyTraSua.Models;
using QuanLyTraSua.Data;

public class SanPhamsController : Controller
{
    private readonly QuanLyTraSuaContext _context;

    public SanPhamsController(QuanLyTraSuaContext context)
    {
        _context = context;
    }

    // GET: SANPHAMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.SanPhams.ToListAsync());
    }

    // GET: SANPHAMS/Details/5
    public async Task<IActionResult> Details(int? masp)
    {
        if (masp == null)
        {
            return NotFound();
        }

        var sanpham = await _context.SanPhams
            .FirstOrDefaultAsync(m => m.MaSP == masp);
        if (sanpham == null)
        {
            return NotFound();
        }

        return View(sanpham);
    }

    // GET: SANPHAMS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SANPHAMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaSP,TenSP,Gia,HinhAnh,MoTa,MaLoai,LoaiTraSua")] SanPham sanpham)
    {
        if (ModelState.IsValid)
        {
            _context.Add(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(sanpham);
    }

    // GET: SANPHAMS/Edit/5
    public async Task<IActionResult> Edit(int? masp)
    {
        if (masp == null)
        {
            return NotFound();
        }

        var sanpham = await _context.SanPhams.FindAsync(masp);
        if (sanpham == null)
        {
            return NotFound();
        }
        return View(sanpham);
    }

    // POST: SANPHAMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? masp, [Bind("MaSP,TenSP,Gia,HinhAnh,MoTa,MaLoai,LoaiTraSua")] SanPham sanpham)
    {
        if (masp != sanpham.MaSP)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(sanpham);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(sanpham.MaSP))
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
        return View(sanpham);
    }

    // GET: SANPHAMS/Delete/5
    public async Task<IActionResult> Delete(int? masp)
    {
        if (masp == null)
        {
            return NotFound();
        }

        var sanpham = await _context.SanPhams
            .FirstOrDefaultAsync(m => m.MaSP == masp);
        if (sanpham == null)
        {
            return NotFound();
        }

        return View(sanpham);
    }

    // POST: SANPHAMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? masp)
    {
        var sanpham = await _context.SanPhams.FindAsync(masp);
        if (sanpham != null)
        {
            _context.SanPhams.Remove(sanpham);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SanPhamExists(int? masp)
    {
        return _context.SanPhams.Any(e => e.MaSP == masp);
    }
}
