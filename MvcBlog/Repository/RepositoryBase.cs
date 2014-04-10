using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.Repository
{
    public class RepositoryBase<TModel>
    {
        private MvcBlogContext dbContext;
        public RepositoryBase()
        {
            dbContext = new MvcBlogContext();
        }

        public virtual bool Add(TModel Tmodel) { return false; }

        public virtual bool Update(TModel Tmodel) { return false; }

        public virtual bool Delete(int Id) { return false; }

        public virtual TModel Find(int Id) { return default(TModel); }
        ~RepositoryBase()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }

    }
}