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
    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        private ApplicationDbContext _db;
        public AnnouncementRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Announcement obj)
        {
            var objFromDb = _db.Announcements.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Purpose = obj.Purpose;
                objFromDb.Announce = obj.Announce;
              
           
           
                if (obj.image != null)
                {
                    objFromDb.image = obj.image;
                }
                objFromDb.Date = obj.Date;
            }
        }
    }
}
