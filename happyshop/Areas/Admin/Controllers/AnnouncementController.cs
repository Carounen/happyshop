
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
    public class AnnouncementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AnnouncementController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Announcement> objAnnouncementList = _unitOfWork.Announcement.GetAll().ToList();
            //or instead of var you can also use List (preferred)
            // List<Product> objProductList = _db.Categories.ToList(); 
            return View(objAnnouncementList);
        }

        //GET
        public IActionResult Upsert(int? id)
        {

            Announcement announcement = new()
            {
                Purpose = "",
                Announce = "",
                image = "",
          


            };

            if (id == null || id == 0)
            {
                //create
                return View(announcement);
            }
            else
            {
                //update
                announcement = _unitOfWork.Announcement.Get(u => u.Id == id);
                return View(announcement);
            }

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Announcement announcement, IFormFile file)
        {



            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    try
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string uploadPath = Path.Combine(wwwRootPath, @"images\announcement");

                        using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        announcement.image = @"\images\announcement\" + fileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, $"An error occurred while uploading the image: {ex.Message}");
                        return View(announcement);
                    }
                }

                if (announcement.Id == 0)
                {
                    _unitOfWork.Announcement.Add(announcement);
                }
                else
                {
                    _unitOfWork.Announcement.Update(announcement);
                }

                _unitOfWork.Save();
                TempData["success"] = "Announcement posted successfully";

                return RedirectToAction("Index");
            }

            return View(announcement);
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Announcement> objAnnouncementList = _unitOfWork.Announcement.GetAll().ToList();
            return Json(new { data = objAnnouncementList });
        }





        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var announcementToBeDeleted = _unitOfWork.Announcement.Get(u => u.Id == id);
            if (announcementToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Announcement.Remove(announcementToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion



    }
}

