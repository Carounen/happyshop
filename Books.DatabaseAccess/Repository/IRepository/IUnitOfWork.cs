using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DatabaseAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

		IShoppingCartRepository ShoppingCart { get; }

		IApplicationUserRepository ApplicationUser { get; }

        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; }

        ICompanyRepository Company { get; }

        IStaffRepository Staff { get; }

        IReviewRepository Review { get; }

        IAnnouncementRepository Announcement { get; }

        IFaqRepository Faq { get; }





        void Save();
    }
}
