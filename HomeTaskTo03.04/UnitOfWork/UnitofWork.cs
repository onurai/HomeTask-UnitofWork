using HomeTaskTo03._04.Data.Context;
using HomeTaskTo03._04.Repository;
using HomeTaskTo03._04.Repository.Implementation;
using HomeTaskTo03._04.Repository.Interface;

namespace HomeTaskTo03._04.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPostRepository postRepository { get; }
        public IBlogRepository blogRepository { get; set; }

        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            postRepository = new PostRepository(_appDbContext);
            blogRepository = new BlogRepository(_appDbContext);
        }

        public async Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
