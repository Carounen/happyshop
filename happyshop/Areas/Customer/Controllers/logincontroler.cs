using Microsoft.AspNetCore.Mvc;

namespace happyshop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class logincontroler : Controller
    {
       
        public IActionResult login()
        {
            return View();
        }

       
    }
}
