namespace HomeTaskTo03._04.Data.Entity
{
    public class Blog : BaseEntity<int>
    {
        public virtual int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Description { get; set; }
        public int PostsCount { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
    }
}
