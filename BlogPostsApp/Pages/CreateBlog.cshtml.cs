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
        private readonly IRepository<Blog> _blogRepository;

        public CreateBlogModel(IRepository<Blog> blogRepository)
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
            await _blogRepository.Add(new Blog(BlogVM.Url, User.FindFirst(ClaimTypes.NameIdentifier).Value, User.Identity.Name));
            await _blogRepository.SaveAllAsync();
            return Redirect("AllBlogs");
        }
    }
}
