using BlogPostsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsApp.Repositories
{
    public class BlogsRepository<T> :IBlogsRepository<T>, IRepository<T> where T : class
    {
        private BloggingContext context = new BloggingContext();
        private DbSet<T> dbSet;

        public BlogsRepository()
        {
            dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            dbSet.Attach(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
 
        }

        public async Task SaveAllAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
