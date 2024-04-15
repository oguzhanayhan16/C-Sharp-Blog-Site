using BusinessLayer.Absract;
using DataAccessLayer.Abstact;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentManager : ICommentServices
	{
		ICommentDal _commentDal;
		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}
	
		public void CommentAdd(Comment comment)
		{
			_commentDal.Insert(comment);
		}

        public List<Comment> GetCommentWithBlog()
        {
          return _commentDal.GetListWithBlog();
        }

        public List<Comment> GetList(int id)
		{
			return _commentDal.GetListAll(x => x.BlogID == id);
		}
	}
}
