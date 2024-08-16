using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Context;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //override yaparak DbContext sınıfının OnConfiguring metodunu eziyoruz.
        //bu sayede bu metodu miras alarak içini dolduruyoruz
    {
        optionsBuilder.UseSqlServer(
            "server=DESKTOP-BOV3B8B\\SQLEXPRESS;Database=NftDb; integrated security=true; TrustServerCertificate=True");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
}