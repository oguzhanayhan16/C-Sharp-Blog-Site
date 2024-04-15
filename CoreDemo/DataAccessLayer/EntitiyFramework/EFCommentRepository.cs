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
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var c = new Context())
            {

                return c.Comments.Include(b => b.Blog).ToList();
            }
        }
    }
}
