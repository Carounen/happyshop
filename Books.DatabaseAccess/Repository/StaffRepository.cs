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
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        private ApplicationDbContext _db;
        public StaffRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Staff obj)
        {
            var objFromDb = _db.Staffs.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.StreetAddress = obj.StreetAddress;
                objFromDb.City = obj.City;
                objFromDb.State = obj.State;
             
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.EmailAddress = obj.EmailAddress;
                objFromDb.Password = obj.Password;



            }
        }
    }
}
