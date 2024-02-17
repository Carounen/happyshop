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
    public class FaqRepository : Repository<Faq>, IFaqRepository
    {
        private ApplicationDbContext _db;
        public FaqRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Faq obj)
        {
            var objFromDb = _db.Faqs.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Question = obj.Question;
              
                objFromDb.Answer = obj.Answer;
                objFromDb.Date = obj.Date;



            }
        }
    }
}
