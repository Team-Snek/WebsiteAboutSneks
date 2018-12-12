using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebsiteAboutSneks.Models;

namespace WebsiteAboutSneks.DAL
{
    public class SnekContext : DbContext
    {
        public DbSet<Snake> Snakes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}