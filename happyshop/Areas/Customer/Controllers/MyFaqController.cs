
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
    public class MyFaqController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MyFaqController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Faq> obFaqList = _unitOfWork.Faq
                 .GetAll(filter: r => r.ApplicationUserId == userId)
                 .ToList();

            return View(obFaqList);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var faqFromDb = _unitOfWork.Faq.Get(u => u.Id == id);
            if (faqFromDb == null)
            {
                return NotFound();
            }
            return View(faqFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Faq.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Faq.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Question deleted successfully";

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var faqFromDb = _unitOfWork.Faq.Get(u => u.Id == id);
            if (faqFromDb == null)
            {
                return NotFound();
            }
            return View(faqFromDb);
        }

        //POST
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Faq obj)
        {
            if (ModelState.IsValid)
            {
              

                _unitOfWork.Faq.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Question edited successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}

