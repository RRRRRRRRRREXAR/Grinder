using Grinder.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.DB
{
    public class GrinderContext:DbContext
    {
        DbSet<Image> Images { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Thumbnail> Thumbnails { get; set; }
        DbSet<Friends> Friends { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<ProfileView> ProfileViews { get; set; }
        public GrinderContext(DbContextOptions<GrinderContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thumbnail>()
                .HasKey(c => c.Id);
        }
    }
}
