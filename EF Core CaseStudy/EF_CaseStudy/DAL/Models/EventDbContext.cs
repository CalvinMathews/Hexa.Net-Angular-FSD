using DAL.Models;
using EventAppDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class EventDbContext : DbContext
    {
        

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }

        public DbSet<SessionInfo> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SessionInfo>()
                .HasOne<EventDetails>()
                .WithMany()
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    EmailId = "admin2003@gmail.com",
                    UserName = "Admin",
                    Password = "adminIAM",
                    Role = "Admin"
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}