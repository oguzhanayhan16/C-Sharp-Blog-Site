using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);
        List<Message2> GetSendBoxWithMessageByWriter(int id);


    }
}
