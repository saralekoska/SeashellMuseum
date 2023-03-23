using Microsoft.EntityFrameworkCore;
using SeashellMuseumWeb.Models;

namespace SeashellMuseumWeb.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Seashell> Seashells { get; set; }

    }
}
