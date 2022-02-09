using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCourse.Models;
using MyCourse.ViewModels;

namespace MyCourse.Data
{
    //public class AppDbContext : DbContext
    //{
    //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)    
    //    {
            
    //    }
    //    public DbSet<Item> Items { get; set; }
    //    public DbSet<Category> Category { get; set; }
    //}


    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<MyCourse.ViewModels.DoctorVM> DoctorVM { get; set; }

    }
}



