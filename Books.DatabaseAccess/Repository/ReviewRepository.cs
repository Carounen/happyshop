using Products.DatabaseAccess.Repository.IRepository;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.DatabaseAccess.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private ApplicationDbContext _db;
        public ReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Review obj)
        {
            var objFromDb = _db.Reviews.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                if (obj.image != null)
                {
                    objFromDb.image = obj.image;
                }
                objFromDb.Rev = obj.Rev;
                objFromDb.Date = obj.Date;



            }
        }
    }
}
