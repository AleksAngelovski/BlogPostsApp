using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogPostsApp.Pages
{
    public class BlogsModel : PageModel
    {
        private readonly ILogger<BlogsModel> logger;

        public BlogsModel(ILogger<BlogsModel> logger)
        {
            this.logger = logger;
        }

        public void OnGet()
        {
        }

    }
}
