using CapturedMoments.Models.CommonProp;
using CapturedMoments.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMSArtiKeys.Models.ViewModels;

namespace CapturedMoments.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<PhotographerSection> Sections { get; set; }

    

    }
}
