using BusinessLayer.Absract;
using DataAccessLayer.Abstact;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal ct;
        public CategoryManager(ICategoryDal categoryDal)
        {
            ct = categoryDal;
        }

       

        public Category TGetByID(int id)
        {
           return ct.GetByID(id);
        }

        public List<Category> GetList()
        {
          return ct.GetListAll();
        }

      

        public void TAdd(Category t)
        {
            ct.Insert(t); 
        }

        public void TDelete(Category t)
        {
            ct.Delete(t);
        }

        public void TUpdate(Category t)
        {
            ct.Update(t);
        }
    }
}
