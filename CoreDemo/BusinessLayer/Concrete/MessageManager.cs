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
    public class MessageManager:IMessageService
    {
        IMessageDal _message;
     public   MessageManager(IMessageDal meesage) 
        { 
            _message = meesage;
        }

        public List<Message> GetList()
        {
            return _message.GetListAll();
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return _message.GetListAll(x=>x.Receiver==p);
        }

        public void TAdd(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            throw new NotImplementedException();
        }

        public Message TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
