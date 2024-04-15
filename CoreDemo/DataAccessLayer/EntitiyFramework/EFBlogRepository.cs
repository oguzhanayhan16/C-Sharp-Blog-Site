using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFBlogRepository : GenericRepository<Blog>,IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
          using(var c = new Context())
            {

                return c.Blogs.Include(b => b.Category).ToList();
            }
            
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {

                return c.Blogs.Include(b => b.Category).Where(x=>x.WriterID==id).ToList();
            }
        }
    }
}
