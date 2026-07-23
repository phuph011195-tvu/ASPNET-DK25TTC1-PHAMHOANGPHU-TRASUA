using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrasuaMON.Models;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Lấy danh sách sản phẩm kèm thông tin danh mục ra trang chủ
        var products = await _context.Products.Include(p => p.Category).ToListAsync();
        return View(products);
    }
}