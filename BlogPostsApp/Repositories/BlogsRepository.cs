using BlogPostsApp.Data;
using BlogPostsApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsApp.Repositories
{
    public class BlogsRepository :IBlogsRepository<Blog>
    {
        private BloggingContext _context;
        private DbSet<Blog> dbSet;

        public BlogsRepository(BloggingContext context)
        {
            _context = context;
            dbSet = context.Set<Blog>();
        }

        public async Task Add(Blog entity)
        {
            dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Blog entity)
        {
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(Blog entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(new object[] { id });
 
        }
        public async Task<Blog> GetByEmailAsync(string email)
        {
            return await dbSet.FirstOrDefaultAsync(v=> v.OwnerName == email);

        }
        public async Task<Blog> GetByUrlAsync(string url)
        {
            return await dbSet.FirstOrDefaultAsync(v => v.Url == url);
        }
        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
