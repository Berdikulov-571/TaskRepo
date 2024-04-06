using Microsoft.EntityFrameworkCore;
using TaskProject.Domain.Entities;
using TaskProject.Service.Abstractions.DataAccess;

namespace TaskProject.DataAccess.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Questions>().HasData
                (
                    new Questions { Id = 1, Question = "1 + 1", A = "9", B = "1", C = "3", D = "+2"},
            new Questions { Id = 2, Question = "7 + 7", A = "+14", B = "15", C = "20", D = "7"},
            new Questions { Id = 3, Question = "5 + 5", A = "0", B = "5", C = "+10", D = "20" },
            new Questions { Id = 4, Question = "20 + 20", A = "20", B = "+40", C = "50", D = "60" },
            new Questions { Id = 5, Question = "2 - 2", A = "+0", B = "2", C = "4", D = "6" }
                );
        }

        public DbSet<Questions> Questions { get; set; }
    }
}