using BlogPostsApp.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace BlogPostsApp.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public BloggingContext(DbContextOptions<BloggingContext> options)
            :base(options)
        {

        }

    }
}
