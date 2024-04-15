using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
    public interface INewsletterServices
    {
        void AddNewsletter(NewsLatter newsletter);
    }
}
