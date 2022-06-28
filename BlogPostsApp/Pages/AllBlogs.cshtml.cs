using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogPostsApp.Pages
{
    
    public class AllBlogsModel : PageModel
    {
        private readonly ILogger<AllBlogsModel> logger;

        public AllBlogsModel(ILogger<AllBlogsModel> logger)
        {
            this.logger = logger;
        }

        //TODO: Instead of the if statement on the blog name, why dont we create separate pages, one for AllBlogs and other for individual blogs.
        public void OnGet()
        {
            
            
        }

    }

}
