using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
     
        public void Delete(T item)
        {
            using var c = new Context();
                     c.Remove(item);
                     c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new Context();
                    return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var c = new Context();
                      return c.Set<T>().ToList();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
           var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public void Insert(T item)
        {
            using var c = new Context();
                      c.Add(item);
                     c.SaveChanges();
        }

        public void Update(T item)
        {
            using var c = new Context();
                      c.Update(item);
                     c.SaveChanges();
        }
    }
}
