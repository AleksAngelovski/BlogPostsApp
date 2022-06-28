using BlogPostsApp.Data.Model;
using BlogPostsApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogPostsApp.Pages
{
    
    public class AllBlogsModel : PageModel
    {
        private readonly ILogger<AllBlogsModel> _logger;
        private readonly IRepository<Blog> _blogsRepository;

        [BindProperty]
        public IEnumerable<Blog> AllBlogs { get; set; }
        public AllBlogsModel(ILogger<AllBlogsModel> logger, IRepository<Blog> blogsRepository)
        {
            this._logger = logger;
            this._blogsRepository = blogsRepository;
        }

        //TODO: Instead of the if statement on the blog name, why dont we create separate pages, one for AllBlogs and other for individual blogs.
        public async Task OnGet()
        {
            AllBlogs = await _blogsRepository.GetAllAsync();
        }

    }

}
