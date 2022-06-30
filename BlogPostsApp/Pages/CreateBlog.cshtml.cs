using BlogPostsApp.Data.Model;
using BlogPostsApp.Pages.ViewModels;
using BlogPostsApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BlogPostsApp.Pages
{
    [Authorize]
    public class CreateBlogModel : PageModel
    {
        private readonly IBlogsRepository<Blog> _blogRepository;

        public CreateBlogModel(IBlogsRepository<Blog> blogRepository)
        {
            this._blogRepository = blogRepository;
        }
        public string ErrorMessage { get; set; }
        [BindProperty]
        public BlogVM BlogVM {get;set;}
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                string userName = User.Identity.Name;

                Blog loggedInUserBlog = await _blogRepository.GetByEmailAsync(userName);
                if (loggedInUserBlog != null)
                {
                    ErrorMessage = "Blog associated with this account already exists, Max blog limit = 1";
                    return Page();
                }
                if (string.IsNullOrWhiteSpace(BlogVM.Url))
                {
                    ErrorMessage = "Please provide a good Blog Url";
                    return Page();
                }
                string url = "/" + BlogVM.Url;
                Blog existingBlogUrl = await _blogRepository.GetByUrlAsync(url);
                if (existingBlogUrl != null)
                {
                    ErrorMessage = "Find a Unique Blog Name, Blog name already in use";
                    return Page();
                }

                await _blogRepository.Add(new Blog(BlogVM.Url, userId, userName));
                await _blogRepository.SaveAllAsync();
                return Redirect("AllBlogs");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                ViewData["Error"] = ex.Message;
                return Page();
            }

            //return Redirect("AllBlogs");
        }
    }
}
