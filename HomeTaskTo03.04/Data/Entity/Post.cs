namespace HomeTaskTo03._04.Data.Entity
{
    public class Post : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int BlogId { get; set; }
        //
        public Blog? Blog { get; set; }  

    }
}
