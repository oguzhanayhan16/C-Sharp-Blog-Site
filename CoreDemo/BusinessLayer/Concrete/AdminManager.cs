using BusinessLayer.Absract;
using DataAccessLayer.Abstact;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _admin;

        public AdminManager(IAdminDal admin)
        {
            _admin = admin;
        }
        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Admin t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Admin t)
        {
            throw new NotImplementedException();
        }

        public Admin TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin t)
        {
            throw new NotImplementedException();
        }
    }
}
