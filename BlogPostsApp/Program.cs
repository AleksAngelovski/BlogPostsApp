using BlogPostsApp.Data;
using BlogPostsApp.Data.Model;
using BlogPostsApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//TODO: Learn How to Make this work: by adding options constructor to our blogging context.
//builder.Services.AddDbContext<BloggingContext>(options =>
//    options.UseSqlite(connectionString))
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IBlogsRepository<Blog>, BlogsRepository>();
//builder.Services.AddScoped<IRepository<Post>, PostRepository>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages(options =>
{
    //options.Conventions.AddPageRoute("/PersonalBlog/{blogName?}", "/Blog/{blogName?}");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
