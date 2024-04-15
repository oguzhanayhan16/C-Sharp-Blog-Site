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
	public class ContactManager : IContactService
	{
		IContactDal _contact;
		public ContactManager(IContactDal contact) 
		{
			_contact= contact;


		}
		public void ContactAdd(Contact contact)
		{
		_contact.Insert(contact);
		}
	}
}
