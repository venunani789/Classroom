using Microsoft.EntityFrameworkCore;
using StudentServices.Api.Models; // only if Student is in Models

namespace StudentServices.Api.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<student1> Students => Set<student1>();
    }
}

