using HomeTaskTo03._04.Data.Entity;

namespace HomeTaskTo03._04.Repository.Interface
{
    public interface IBlogRepository : IRepository<Blog, int>
    {
        Task<List<Blog>> GetAll();
        Task<Blog> GetId(int id);
        Task<Blog> Create(string blogName, string description, int postsCount);
        Task<bool> Update(int id, string blogName, string description, int postsCount);
        Task<bool> Remove(int id);
    }
}
