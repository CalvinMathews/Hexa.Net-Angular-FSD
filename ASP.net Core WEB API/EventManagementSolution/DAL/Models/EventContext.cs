using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Models
{
    public class EventContext : DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<SpeakersDetails> SpeakersDetails { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEventDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(
                    DatabaseHelper.GetConStr(),
                    opts => opts.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                );
            }

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            // One-to-Many
            model.Entity<Session>()
                .HasOne<EventDetails>()
                .WithMany()
                .HasForeignKey(s => s.EId);

            // Seed default admin
            model.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    EmailId = "admin@gmail.com",
                    UserName = "Admin",
                    Password = "admin123",
                    Role = "Admin"
                });

            base.OnModelCreating(model);
        }
    }
}
