﻿using HomeTaskTo03._04.Data.Context;
using HomeTaskTo03._04.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeTaskTo03._04.Repository
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext; 
        }

        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _dbContext.Posts.ToListAsync();
            return posts;
        }

        public Task<Post> GetId(int id)
        {
            var result = _dbContext.Posts.FirstOrDefaultAsync(i => i.BlogId == id);
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
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Remove(int id)
        {
            var result = await _dbContext.Posts.FirstOrDefaultAsync(x => x.BlogId == id);
            _dbContext.Posts.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, string title, string subtitle, string content, string description, int blogId)
        {
            Post post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            post.Title = title;
            post.Subtitle = subtitle;
            post.Content = content;
            post.Description = description;
            post.BlogId = blogId;
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
