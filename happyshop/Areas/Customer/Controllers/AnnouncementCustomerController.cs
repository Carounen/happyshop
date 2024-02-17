
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Products.DatabaseAccess;
using Products.DatabaseAccess.Repository;
using Products.DatabaseAccess.Repository.IRepository;
using Products.Models;
using Products.Models.ViewModels;
using Products.Utility;

namespace happyshop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class AnnouncementCustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AnnouncementCustomerController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Announcement> objAnnouncementList = _unitOfWork.Announcement.GetAll().OrderByDescending(r => r.Date).ToList();
            //or instead of var you can also use List (preferred)
            // List<Product> objProductList = _db.Categories.ToList(); 
            return View(objAnnouncementList);
        }

        //GET
       

    }
}

