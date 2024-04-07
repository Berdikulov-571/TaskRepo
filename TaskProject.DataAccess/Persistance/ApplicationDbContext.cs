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
                    new Questions { Id = 1, Question = "# To‘g‘ri  to‘rtburchak shaklidagi yer maydoniga sabzi, kartoshka va piyoz ekilgan (rasmga qarang). Necha kvadrat metr maydonga sabzi, kartoshka va piyoz ekilgan?", A = "3600 ", B = "+800", C = "2400", D = "3200", ImagePath = "media\\images\\question1.png" },
                    new Questions { Id = 2, Question = "Vaqt va uzunlik orasidagi bog‘liqlik grafigida 8 soatda ishchilar tomonidan yo‘l qurilganligi tasvirlangan. Grafikda berilgan ma’lumotlardan foydalanib ishchilar qaysi oraliqda ENG UZUN yo‘l qurganligini aniqlang", A = "AB", B = "DE", C = "CD", D = "+BC", ImagePath = "media\\images\\question2.png" },
                    new Questions { Id = 3, Question = "Rasmda  berilgan ma’lumotlardan foydalanib quyidagi tengsizliklardan noto‘g‘risini aniqlang.", A = "a*b*c > 0", B = "+a + b > 0", C = "a - b > 0", D = "b + c > 0" , ImagePath = "media\\images\\question3.png" },
                    new Questions { Id = 4, Question = "20 + 20", A = "20", B = "+40", C = "50", D = "60" , ImagePath = "" },
                    new Questions { Id = 5, Question = "2 - 2", A = "+0", B = "2", C = "4", D = "6" , ImagePath = "" }
                );
        }

        public DbSet<Questions> Questions { get; set; }
    }
}