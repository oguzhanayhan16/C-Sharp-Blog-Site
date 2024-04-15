using DataAccessLayer.Repositories;
using DataAccessLayer.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFWriterRepository : GenericRepository<Writer>, IWriterDal
    {
    }
}
