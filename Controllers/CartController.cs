using Microsoft.AspNetCore.Mvc;
 // Thay bằng đường dẫn DbContext của bạn nếu khác
using TrasuaMON.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace TrasuaMON.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context; // Đổi tên DbContext nếu dự án của bạn đặt khác

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Xem danh sách giỏ hàng
        public IActionResult Index()
        {
            var cart = GetCartItems();
            ViewBag.Total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View(cart);
        }

        // Xử lý thêm món vào giỏ
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var product = _context.Products.Find(productId);
            if (product == null) return NotFound();

            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(p => p.Product.Id == productId);

            if (cartItem == null)
            {
                cart.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        // Xóa một món khỏi giỏ
        public IActionResult RemoveItem(int productId)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(p => p.Product.Id == productId);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        // Hỗ trợ đọc/ghi Session bằng JSON
        private List<CartItem> GetCartItems()
        {
            var sessionData = HttpContext.Session.GetString("GioHang");
            return sessionData == null ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(sessionData);
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("GioHang", JsonSerializer.Serialize(cart));
        }
    }

    // Lớp phụ lưu cấu trúc item giỏ hàng
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}