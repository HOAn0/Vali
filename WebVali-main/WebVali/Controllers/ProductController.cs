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
        public IActionResult Product()
        {
            var products = _context.TChiTietSanPhams
            .Include(p => p.MaKichThuocNavigation)
            .Include(p => p.MaMauSacNavigation)
            .ToList();

            return View(products);
        }
    }
}
