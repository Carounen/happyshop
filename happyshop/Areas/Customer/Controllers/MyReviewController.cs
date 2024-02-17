
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
    public class MyReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MyReviewController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Review> objReviewList = _unitOfWork.Review
                 .GetAll(filter: r => r.ApplicationUserId == userId)
                 .ToList();

            return View(objReviewList);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var reviewFromDb = _unitOfWork.Review.Get(u => u.Id == id);
            if (reviewFromDb == null)
            {
                return NotFound();
            }
            return View(reviewFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Review.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Review.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Review deleted successfully";

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var reviewFromDb = _unitOfWork.Review.Get(u => u.Id == id);
            if (reviewFromDb == null)
            {
                return NotFound();
            }
            return View(reviewFromDb);
        }

        //POST
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Review obj, IFormFile file)
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

                _unitOfWork.Review.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Review edited successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}

