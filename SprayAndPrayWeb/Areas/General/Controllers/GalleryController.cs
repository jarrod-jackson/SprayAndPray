using Microsoft.AspNetCore.Mvc;

namespace SprayAndPrayWeb.Areas.General.Controllers
{
    public class GalleryController : Controller
    {
        [Area("General")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
