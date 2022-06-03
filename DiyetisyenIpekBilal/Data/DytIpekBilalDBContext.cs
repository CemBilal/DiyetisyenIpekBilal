using DiyetisyenIpekBilal.Models;
using Microsoft.EntityFrameworkCore;

namespace DiyetisyenIpekBilal.Data
{
    public class DytIpekBilalDBContext:DbContext
    {

        public DytIpekBilalDBContext(DbContextOptions<DytIpekBilalDBContext> options) : base(options) { }


        public DbSet<Userr> Userrs{ get; set; }
        public DbSet<Rolee> Rolees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) //seeding data 
        {
            modelBuilder.Entity<Userr>().HasData(
                new Userr { UserrID = 1, Name= "İpek", Surname="Bilal", Emaill= "admin123@hotmail.com", Password="Test123!", PhoneNumber="5459552815", RoleeID=1, ImagePath="~/AdminTemplate/images/avatar/1.jpg"}
                          );
            modelBuilder.Entity<Rolee>().HasData(
                new Rolee { RoleeID = 1, RoleeName= "Admin"},
                new Rolee { RoleeID = 2, RoleeName= "Anonim"},
                new Rolee { RoleeID = 3, RoleeName="Danışan"}
                          );

        }



        public DbSet<DiyetisyenIpekBilal.Models.AboutMe> AboutMe { get; set; }



        public DbSet<DiyetisyenIpekBilal.Models.Achievement> Achievement { get; set; }



        public DbSet<DiyetisyenIpekBilal.Models.Recipe> Recipe { get; set; }



        public DbSet<DiyetisyenIpekBilal.Models.Ingredients> Ingredients { get; set; }



        public DbSet<DiyetisyenIpekBilal.Models.Instructions> Instructions { get; set; }
    }
}
