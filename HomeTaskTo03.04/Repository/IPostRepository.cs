﻿using HomeTaskTo03._04.Data.Entity;

namespace HomeTaskTo03._04.Repository
{
    public interface IPostRepository : IRepository<Post, int>
    {
        Task<List<Post>> GetAll();
        Task<Post> GetId(int id);
        Task<Post> Create(string title, string subtitle, string content, string description, int blogId);
        Task<bool> Update(int id, string title, string subtitle, string content, string description, int blogId);
        Task<bool> Remove(int id);
    }
}
