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
        public GrinderContext(DbContextOptions<GrinderContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
