using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.ProductApi.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
