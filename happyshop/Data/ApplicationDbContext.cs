using happyshop.Models;
using Microsoft.EntityFrameworkCore;

namespace happyshop.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Tech", DisplayOrder = 1 },
            new Category { Id = 2, Name = "wood", DisplayOrder = 2 },
            new Category { Id = 3, Name = "interior", DisplayOrder = 3 },
            new Category { Id = 4, Name = "extrior", DisplayOrder = 4 }
            );
        }
    }
}
