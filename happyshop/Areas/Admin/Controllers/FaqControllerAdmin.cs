
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Products.DatabaseAccess;
using Products.DatabaseAccess.Repository;
using Products.DatabaseAccess.Repository.IRepository;
using Products.Models;
using Products.Models.ViewModels;
using Products.Utility;

namespace happyshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
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
            // List<Product> objProductList = _db.Categories.ToList(); 
            return View(objFaqList);
        }

        //GET
        public IActionResult Upsert(int? id)
        {

            Faq faq = new()
            {
                Question = "",
                Answer = "",
             



            };

            if (id == null || id == 0)
            {
                //create
                return View(faq);
            }
            else
            {
                //update
                faq = _unitOfWork.Faq.Get(u => u.Id == id);
                return View(faq);
            }

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Faq faq)
        {



            if (ModelState.IsValid)
            {
               

                if (faq.Id == 0)
                {
                    _unitOfWork.Faq.Add(faq);
                }
                else
                {
                    _unitOfWork.Faq.Update(faq);
                }

                _unitOfWork.Save();
                TempData["success"] = "Question Answered successfully";

                return RedirectToAction("Index");
            }

            return View(faq);
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Faq> objFaqList = _unitOfWork.Faq.GetAll().ToList();
            return Json(new { data = objFaqList });
        }





        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var faqToBeDeleted = _unitOfWork.Faq.Get(u => u.Id == id);
            if (faqToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Faq.Remove(faqToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion



    }
}

