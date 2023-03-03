using HomeTaskTo03._04.Data.Context;
using HomeTaskTo03._04.Data.Entity;
using HomeTaskTo03._04.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo03._04.Services.Implementation
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public Task<Post> GetId(int id)
        {
            var result = _context.Posts.FirstOrDefaultAsync(i => i.BlogId == id);
            return result;
        }

        public async Task<Post> Create(string title, string subtitle, string content, string description, int blogId)
        {
            Post post = new()
            {
                Title = title,
                Subtitle = subtitle,
                Content = content,
                Description = description,
                BlogId = blogId
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Remove(int id)
        {
            var result = await _context.Posts.FirstOrDefaultAsync(x => x.BlogId == id);
            _context.Posts.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, string title, string subtitle, string content, string description, int blogId)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            post.Title = title;
            post.Subtitle=subtitle;
            post.Content=content;
            post.Description=description;
            post.BlogId=blogId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
