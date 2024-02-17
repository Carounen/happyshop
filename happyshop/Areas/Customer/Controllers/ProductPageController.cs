
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.DatabaseAccess.Repository.IRepository;
using Products.Models;
using Products.Utility;
using System.Diagnostics;
using System.Security.Claims;

namespace happyshop.Controllers
{
    [Area("Customer")]
    public class ProductPageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductPageController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:
            "Category");            //or instead of var you can also use List (preferred)
            // List<Product> objProductList = _db.Categories.ToList(); 
            return View(productList);
        }
       

      

       
        public IActionResult Details(int productId)
        {
			ShoppingCart cart = new()
			{
				Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties:
  "Category"),
				Count = 1,
				ProductId = productId
			};
			return View(cart);
		}




		[HttpPost]
		[Authorize]
		public IActionResult Details(ShoppingCart shoppingCart)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			shoppingCart.ApplicationUserId = userId;
			ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId ==
 userId && u.ProductId == shoppingCart.ProductId);
			if (cartFromDb != null)
			{

				cartFromDb.Count += shoppingCart.Count;
				_unitOfWork.ShoppingCart.Update(cartFromDb);
			}
			else
			{
                //add cart record
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }
            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Index));
        }


    }
}