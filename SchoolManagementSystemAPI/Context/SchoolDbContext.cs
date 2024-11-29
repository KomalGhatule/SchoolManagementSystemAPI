using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemAPI.Entities;

namespace SchoolManagementSystemAPI.Context
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options)
        {

        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=DESKTOP-QM00SQR;Initial Catalog=EFSchoolDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

    }
}
