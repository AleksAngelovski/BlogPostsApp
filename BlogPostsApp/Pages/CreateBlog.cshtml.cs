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
                if ((await _blogRepository.GetByEmailAsync(userName)) != null)
                {
                    ViewData["Error"] = "Blog associated with this account already exists, Max blog limit = 1";
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
