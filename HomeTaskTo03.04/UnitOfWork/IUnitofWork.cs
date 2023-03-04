using HomeTaskTo03._04.Repository;

namespace HomeTaskTo03._04.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPostRepository postRepository { get; }
        public IBlogRepository blogRepository { get; set; }

        public Task Commit();
    }
}
