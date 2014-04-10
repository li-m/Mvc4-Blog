using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcBlog.Models;

namespace MvcBlog.Repository
{
    public class UserRepository:RepositoryBase<User>
    {
        private MvcBlogContext dbContext;
        public UserRepository()
        {
            dbContext = new MvcBlogContext();
        }

        public override bool Add(User user)
        {
            if (user == null) return false;
            dbContext.Users.Add(user);
            if (dbContext.SaveChanges() > 0) return true;
            else return false;
        }

        public override bool Update(User user)
        {
            var _user = dbContext.Users.SingleOrDefault(u => u.Id == user.Id);
            if (_user == null) return false;
            _user = user;
            if (dbContext.SaveChanges() > 0) return true;
            else return false;
        }

    }
}