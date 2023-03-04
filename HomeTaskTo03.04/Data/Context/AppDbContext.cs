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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(b =>
            {
                b.ToTable("tblPost");
                b.HasKey(k => k.Id);
                b.Property(q => q.Title).HasColumnName("Title");
                b.Property(q => q.Subtitle).HasColumnName("Subtitle");
                b.Property(q => q.Content).HasColumnName("Content");
                b.Property(l => l.Description).HasColumnName("Description").HasMaxLength(30);
                b.HasIndex(i => i.Title).IsUnique();

                b.HasOne(x => x.Blog).WithMany(x => x.Posts).HasForeignKey(x => x.BlogId);
                b.Property(x => x.CreationDate).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<Blog>(b =>
            {
                b.ToTable("tblBlog");
                b.HasKey(k => k.Id);
                b.Property(q => q.BlogName).HasColumnName("Name");
                b.Property(l => l.Description).HasColumnName("Description").HasMaxLength(30);
                b.HasIndex(i => i.BlogName).IsUnique();

                b.HasMany(x => x.Posts).WithOne(x => x.Blog);
            });

            
        }
    }

}
