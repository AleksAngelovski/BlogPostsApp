namespace BlogPostsApp.Data.Model
{
    public class Post
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }

        public int? BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public Post()
        {

        }

        public Post(string title, string content, int? blogId) 
        {
            if (string.IsNullOrEmpty(title)) { throw new Exception("please provide a title"); }
            if (string.IsNullOrEmpty(content)) { throw new Exception("please provide a content"); }
            if (blogId == null) { throw new Exception("a post has to be associated with a blog"); }

            Title = title;
            Content = content;
            DateCreated = DateTime.Now;
            BlogId = blogId;
        }

    }
}
