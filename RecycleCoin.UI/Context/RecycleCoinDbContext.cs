using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Enums;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Utilities.Hashing;

namespace RecycleCoin.UI.Context
{
    public class RecycleCoinDbContext : DbContext
    {
        public DbSet<Aluminum> Aluminums { get; set; }
        public DbSet<Iron> Irons { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Pine> Pines { get; set; }
        public DbSet<Plastic> Plastics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                "Data Source=MURATAGYUZ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluminum>()
                .Property(p => p.CarbonValue)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Iron>()
                .Property(p => p.CarbonValue)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Paper>()
                .Property(p => p.CarbonValue)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Pine>()
                .Property(p => p.CarbonValue)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Plastic>()
                .Property(p => p.CarbonValue)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<User>()
                .Property(p => p.RecycleCoinAccount)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Aluminum
            >().HasData(new Aluminum
            {
                Id = Guid.NewGuid(),
                Object = "Kola Kutusu",
                CarbonValue = 330
            });

            modelBuilder.Entity<Iron>().HasData(new Iron
            {
                Id = Guid.NewGuid(),
                Object = "Pil",
                CarbonValue = 400
            });

            modelBuilder.Entity<Paper>().HasData(new Paper
            {
                Id = Guid.NewGuid(),
                Object = "Gazete",
                CarbonValue = 50
            });

            modelBuilder.Entity<Pine>().HasData(new Pine
            {
                Id = Guid.NewGuid(),
                Object = "Gazoz Şisesi",
                CarbonValue = 200
            });

            modelBuilder.Entity<Plastic>().HasData(new Plastic
            {
                Id = Guid.NewGuid(),
                Object = "Su Şişesi",
                CarbonValue = 50
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                FullName = "Admin",
                UserName = "Admin",
                Password = "Admin",
                Identity = HashingHelper.SHA256Hash(),
                RecycleCoinAccount = 0,
                Roles = Roles.Admin
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}