using Microsoft.AspNetCore.Mvc;

namespace happyshop.Controllers
{
    public class logincontroler : Controller
    {
        public IActionResult login()
        {
            return View();
        }

        public IActionResult loginadmin()
        {
            return View();
        }
        public IActionResult loginstaff()
        {
            return View();
        }
    }
}
