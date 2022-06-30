using BlogPostsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsApp.Repositories
{
    public class BlogsRepository<T> :IBlogsRepository<T> where T : class
    {
        private BloggingContext context;
        private DbSet<T> dbSet;

        public BlogsRepository()
        {
            context = new BloggingContext();
            dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task Edit(T entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(new object[] { id });
 
        }
        public async Task<T> GetByEmailAsync(string email)
        {
            return await dbSet.FindAsync(email);

        }

        public async Task SaveAllAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
