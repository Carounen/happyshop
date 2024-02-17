using Microsoft.AspNetCore.Mvc;

namespace happyshop.Areas.Admin.Controllers
{
    public class logincontroler : Controller
    {
        [Area("Admin")]
        public IActionResult loginadmin()
        {
            return View();
        }
     
    }
}
