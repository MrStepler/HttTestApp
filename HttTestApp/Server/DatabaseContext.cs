using Microsoft.EntityFrameworkCore;
using HttTestApp.Shared;
using Microsoft.Extensions.Configuration;

namespace HttTestApp.Server
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        private IConfiguration? configuration;
        public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Database.EnsureCreated();
            this.configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => new {p.Article});
            modelBuilder.Entity<Category>().HasKey(p => new {p.Id});
        }
    }
}
