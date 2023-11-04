using Microsoft.AspNetCore.Mvc;

namespace happyshop.Controllers
{
    public class registercontroler : Controller
    {
        public IActionResult register()
        {
            return View();
        }
    }
}
