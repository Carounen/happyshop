using Books.DatabaseAccess.Repository;
using Products.DatabaseAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DatabaseAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

		public IShoppingCartRepository ShoppingCart { get; private set; }
		public IApplicationUserRepository ApplicationUser { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IStaffRepository Staff { get; private set; }
        public IReviewRepository Review { get; private set; }

        public IAnnouncementRepository Announcement { get; private set; }
        public IFaqRepository Faq { get; private set; }






        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
			ShoppingCart = new ShoppingCartRepository(_db);
			ApplicationUser = new ApplicationUserRepository(_db);
            Company = new CompanyRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            Staff = new StaffRepository(_db);
            Review = new ReviewRepository(_db);
            Announcement = new AnnouncementRepository(_db);
            Faq = new FaqRepository(_db);



        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
