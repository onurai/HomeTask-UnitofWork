using HomeTaskTo03._04.Data.Context;
using HomeTaskTo03._04.Data.Entity;
using HomeTaskTo03._04.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo03._04.Services.Implementation
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> Create(string blogName, string description, int postsCount)
        {
            Blog blog = new()
            {
                BlogName = blogName,
                Description = description,
                PostsCount = postsCount
            };
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<List<Blog>> GetAll()
        {
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            return blogs;
        }
       
        public Task<Blog> GetId(int id)
        {
            var result = _context.Blogs.FirstOrDefaultAsync(i => i.BlogId == id);
            return result;
        }

        public async Task<bool> Remove(int id)
        {
            var result = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            _context.Blogs.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, string blogName, string description, int postsCount)
        {
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);

            blog.BlogName = blogName;
            blog.Description = description;
            blog.PostsCount = postsCount;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
