namespace BlogPostsApp.Repositories
{
    public interface IBlogsRepository<T> : IRepository<T> where T : class
    {
        Task<T> GetByEmailAsync(string email);
        Task<T> GetByUrlAsync(string url);
    }
}