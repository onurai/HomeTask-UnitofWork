using HomeTaskTo03._04.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo03._04.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }

}
