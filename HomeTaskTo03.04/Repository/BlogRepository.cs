using HomeTaskTo03._04.Data.Context;
using HomeTaskTo03._04.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo03._04.Repository
{
    public class BlogRepository : EfRepository<Blog, int>, IBlogRepository
    {
        private AppDbContext _db;

        public BlogRepository(AppDbContext DbContext) : base(DbContext)
        {
            _db=DbContext;
        }

        public async Task<Blog> Create(string blogName, string description, int postsCount)
        {
            Blog blog = new()
            {
                BlogName = blogName,
                Description = description,
                PostsCount = postsCount
            };
            _db.Blogs.Add(blog);
            await _db.SaveChangesAsync();
            return blog;
        }

        public async Task<List<Blog>> GetAll()
        {
            List<Blog> blogs = await _db.Blogs.ToListAsync();
            return blogs;
        }

        public Task<Blog> GetId(int id)
        {
            var result = _db.Blogs.FirstOrDefaultAsync(i => i.Id == id);
            return result;
        }

        public async Task<bool> Remove(int id)
        {
            var result = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            _db.Blogs.Remove(result);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, string blogName, string description, int postsCount)
        {
            Blog blog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);

            blog.BlogName = blogName;
            blog.Description = description;
            blog.PostsCount = postsCount;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
