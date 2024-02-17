using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Products.DatabaseAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Faq> Faqs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Tech", DisplayOrder = 1 },
            new Category { Id = 2, Name = "wood", DisplayOrder = 2 },
            new Category { Id = 3, Name = "interior", DisplayOrder = 3 },
            new Category { Id = 4, Name = "extrior", DisplayOrder = 4 }
            );
            modelBuilder.Entity<Product>().HasData(

               new Product
               {
                   Id = 1,
                   Name = "Iphone",

                   Description = "Very nice phone",

                   Price = 99,
                   image = "~/images/ip12.jpg",
                  Date = DateTime.Now,
                  CategoryId = 1
        },
               new Product
               {
                   Id = 2,
                   Name = "Gopro",

                   Description = "Very nice phone",

                   Price = 99,
                   image = "~/images/gopro.jpg",
                   Date = DateTime.Now,
                   CategoryId = 2
               },
               new Product
               {
                   Id = 3,
                   Name = "Canon",

                   Description = "Very nice Camera",

                   Price = 99,
                   image = "~/images/canon.jpg",
                   Date = DateTime.Now,
                   CategoryId = 2
               },
               new Product
               {
                   Id = 4,
                   Name = "Xiaomi",

                   Description = "Very nice phone",

                   Price = 99,
                   image = "~/images/Xiaomi.jpg",
                   Date = DateTime.Now,
                   CategoryId = 3
               }

               );


        }
    }
}
