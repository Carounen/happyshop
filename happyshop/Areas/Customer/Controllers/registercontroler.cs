using Microsoft.AspNetCore.Mvc;

namespace happyshop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class registercontroler : Controller
    {
        public IActionResult register()
        {
            return View();
        }
    }
}
