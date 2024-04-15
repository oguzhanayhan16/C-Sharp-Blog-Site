﻿using BusinessLayer.Absract;
using DataAccessLayer.Abstact;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
     
		public List<Blog> GetListWithCategoryByWriterBm(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}

        public Blog TGetByID(int id)
		{
			return _blogDal.GetByID(id);
		}
		public List<Blog> GetBlogByID(int id)
		{
		
			return _blogDal.GetListAll(X => X.BlogID == id);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}
		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetListAll().Take(3).ToList();
		}

		

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterID == id);
		}

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
           _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
           _blogDal.Update(t);
        }
    }
}
