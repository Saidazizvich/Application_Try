using Application_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Application_Core.Data
{
    public class DepartContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-8S475CNH\\MSSQLSERVER01;  Database=Core_Data; Integrated Security=True; TrustServerCertificate=True; Trusted_Connection=True;");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasOne(x=>x.Departments).WithMany(z=>z.Personels).HasForeignKey(x=>x.DepartmentId); 
            base.OnModelCreating(modelBuilder);
        }
    }

}