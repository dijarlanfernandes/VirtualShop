using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.ProductApi.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
