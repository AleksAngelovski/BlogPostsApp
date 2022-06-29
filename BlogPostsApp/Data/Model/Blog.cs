namespace BlogPostsApp.Data.Model
{
    public class Blog
    {
        public int Id { get; private set; }
        public string Url { get; private set; }

        public string OwnerId { get; private set; }

        public string OwnerName { get; private set; }

        public virtual List<Post> Posts { get; private set; }

        public Blog()
        {
            Posts = Posts ?? new List<Post>() { };
        }

        public Blog(string urlEndpoint, string ownerId, string ownerName)
        {
            if (string.IsNullOrEmpty(urlEndpoint))
            {
                throw new Exception("Unique Blog Url not specified");
            }
            if (string.IsNullOrEmpty(ownerName))
            {
                throw new Exception("Could not Extract ID from Logged in User");
            }
            if (string.IsNullOrEmpty(ownerName))
            {
                throw new Exception("Please provide a valid owner name");
            }
            Url = "/" + urlEndpoint;
            OwnerId = ownerId;
            OwnerName = ownerName;
            Posts = Posts ?? new List<Post>() { };

        }
        
    }
}
