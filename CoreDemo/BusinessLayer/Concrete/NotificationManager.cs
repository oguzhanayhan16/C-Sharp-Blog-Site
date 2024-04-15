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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notification;
        public NotificationManager(INotificationDal notificationDal) {
            _notification = notificationDal;
        }
        public List<Notification> GetList()
        {
            return _notification.GetListAll();
        }

        public void TAdd(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new NotImplementedException();
        }

        public Notification TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
