using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using MvcBlog.Models;

namespace MvcBlog.Repository
{
    public class MvcBlogContext:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}