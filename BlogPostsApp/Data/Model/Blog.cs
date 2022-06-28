namespace BlogPostsApp.Data.Model
{
    public class Blog
    {
        public int Id { get; private set; }
        public string Url { get; private set; }

        public int OwnerId { get; private set; }

        public string OwnerName { get; private set; }

        public List<Post> Posts { get; private set; }

        public Blog()
        {
            Posts = Posts ?? new List<Post>() { };
        }
    }
}
