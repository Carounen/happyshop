
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.DatabaseAccess;
using Products.DatabaseAccess.Repository;
using Products.DatabaseAccess.Repository.IRepository;
using Products.Models;
using Products.Utility;
using System.Security.Claims;

namespace happyshop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReviewController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            IEnumerable<Review> objReviewList = _unitOfWork.Review.GetAll()
         .OrderByDescending(r => r.Date)
         .ToList();
            return View(objReviewList);
        }

        //GET
        public IActionResult Create()
        {
            string Name = User.FindFirstValue(ClaimTypes.Name);

            var review = new Review
            {
                Name = Name

            };


            return View(review);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review obj, IFormFile file)
        {


            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    try
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string uploadPath = Path.Combine(wwwRootPath, @"images\review");

                        using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        obj.image = @"\images\review\" + fileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, $"An error occurred while uploading the image: {ex.Message}");
                        return View(obj);
                    }
                }

                _unitOfWork.Review.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Review posted successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

    }
}

