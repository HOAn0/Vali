using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebVali.Models;

namespace WebVali.Controllers
{
    public class ProductController : Controller
    {
        private readonly QlbanVaLiContext _context;
        public ProductController(QlbanVaLiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Action hiển thị danh sách sản phẩm
        public IActionResult Product()
        {
            var products = _context.TChiTietSanPhams
            .Include(p => p.MaKichThuocNavigation)
            .Include(p => p.MaMauSacNavigation)
            .ToList();

            return View(products);
        }
        // Action hiển thị chi tiết sản phẩm
        public IActionResult Details(string id)
        {
            var product = _context.TChiTietSanPhams
                                  .Include(p => p.MaKichThuocNavigation)
                                  .Include(p => p.MaMauSacNavigation)
                                  .FirstOrDefault(p => p.MaChiTietSp == id);
            return View(product);
        }

        // Action để chỉnh sửa sản phẩm
        public IActionResult Edit(string id)
        {
            var product = _context.TChiTietSanPhams.Find(id);
            return View(product);
        }

        // Action để xóa sản phẩm
        public IActionResult Delete(string id)
        {
            var product = _context.TChiTietSanPhams.Find(id);
            return View(product); // Có thể hiển thị trang xác nhận trước khi xóa
        }
    }
}
