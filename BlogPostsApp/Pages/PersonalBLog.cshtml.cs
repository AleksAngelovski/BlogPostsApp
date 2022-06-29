using BlogPostsApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogPostsApp.Pages
{
    public class PersonalBlogModel : PageModel
    {
        private readonly ILogger<PersonalBlogModel> logger;

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string OwnerName { get; set; }

        [BindProperty]
        public List<Post> BloggerPosts { get; set; } 

        public PersonalBlogModel(ILogger<PersonalBlogModel> logger)
        {
            this.logger = logger;
        }

        public void OnGet(string blogFilter)
        {
            //First try to search the db if there are blogs by this user, 

            //Then search by the blogName

            ViewData["Title"] = (blogFilter) + " Blog";
            Name = blogFilter;

        }
    }
}
