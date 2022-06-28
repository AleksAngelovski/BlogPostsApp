namespace BlogPostsApp.Data.Model
{
    public class Post
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
