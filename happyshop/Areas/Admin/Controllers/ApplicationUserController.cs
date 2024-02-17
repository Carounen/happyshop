using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Products.DatabaseAccess.Repository.IRepository;
using Products.Models;
using Products.Utility;

namespace happyshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ApplicationUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApplicationUserController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> objApplicationUserList = _unitOfWork.ApplicationUser.GetAll();
            //or instead of var you can also use List (preferred)
            //List<Product> objProductList = _db.Categories.ToList();
            return View(objApplicationUserList);
        }

     


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objApplicationList = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Company").ToList();

            foreach (var user in objApplicationList)
            {


                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }

            return Json(new { data = objApplicationList });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {

            var objFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _unitOfWork.ApplicationUser.Update(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Operation Successful" });
        }

        #endregion
    }
}