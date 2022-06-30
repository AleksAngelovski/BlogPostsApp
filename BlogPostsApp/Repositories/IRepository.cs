namespace BlogPostsApp.Repositories
{
    public interface IRepository<T> where T:class 
    {
        Task<T> GetByIdAsync(int id);
        Task Add(T entity);
        Task Edit(T entity);
        Task Delete(T entity);

        Task<List<T>> GetAllAsync();
        Task SaveAllAsync();

    }
}
