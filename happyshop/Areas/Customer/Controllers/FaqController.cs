
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.DatabaseAccess;
using Products.DatabaseAccess.Repository;
using Products.DatabaseAccess.Repository.IRepository;
using Products.Models;
using Products.Utility;

namespace happyshop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class FaqController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FaqController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            IEnumerable<Faq> objFaqList = _unitOfWork.Faq.GetAll().ToList();
            //or instead of var you can also use List (preferred)
            // List<Category> objCategoryList = _db.Categories.ToList(); 
            return View(objFaqList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Faq obj)
        {


            if (ModelState.IsValid)
            {
               

                _unitOfWork.Faq.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Review posted successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

    }
}

