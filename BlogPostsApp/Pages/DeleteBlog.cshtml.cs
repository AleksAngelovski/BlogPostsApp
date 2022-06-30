using BlogPostsApp.Data.Model;
using BlogPostsApp.Pages.ViewModels;
using BlogPostsApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BlogPostsApp.Pages
{
    public class DeleteBlogModel : PageModel
    {

        public string ErrorMessage { get; set; }

        public BlogVM BlogVm { get; set; }

        private IBlogsRepository<Blog> _blogsRepository { get; set; }

        public DeleteBlogModel(IBlogsRepository<Blog> blogsRepository)
        {
            BlogVm = new BlogVM();
            _blogsRepository = blogsRepository;
        }
        [Authorize]
        public IActionResult OnGet(string ownerId, string blogUrl)
        {
            if (string.IsNullOrEmpty(ownerId))
            {
                ErrorMessage = "Invalid Owner, You cannot delete the blog";
                return Page();
            }
            if (string.IsNullOrEmpty(blogUrl))
            {
                ErrorMessage = "Invalid BlogUrl, Please provide the blog you want to remove";
                return Page();
            }
            BlogVm.OwnerId = ownerId;
            BlogVm.Url = blogUrl;

            return Page();

        }
        [Authorize]
        public async Task<IActionResult> OnPost(string ownerId,string blogUrl)
        {
            if (string.IsNullOrEmpty(ownerId) || string.IsNullOrEmpty(blogUrl))
            {
                ErrorMessage = "No Blog Details provided";
                return Page();
            }

            string CurrentUserEmail = User.Identity.Name;
            string CurrentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Blog blog = await _blogsRepository.GetByEmailAsync(CurrentUserEmail);
            if(blog == null)
            {
                ErrorMessage = "Blog doesnt exist";
                return Page();
            }
            if(blog.OwnerId != CurrentUserId)
            {
                ErrorMessage = "Cannot Delete Blogs that arent your own";
                return Page();
            }
            if(blogUrl != blog.Url)
            {
                ErrorMessage = "Invalid Blog Name, There isnt a blog for that user";
                return Page();
            }

            _blogsRepository.Delete(blog);

            return Redirect("AllBlogs");
        }
    }
}
