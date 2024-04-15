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
    public class EFMessage2Reposityory : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {

                return c.Message2s.Include(b => b.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }

        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {

                return c.Message2s.Include(b => b.ReceiverUser).Where(x => x.SenderID == id).ToList();
            }
        }
    }
}
