using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.DATA;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class ContactsService : BaseService<Conf_Contacts>, IContactsService
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsService(IContactsRepository contactsRepository)
        {
            this._contactsRepository = contactsRepository;
        }
        public List<Conf_Contacts_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            return _contactsRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord).ToList();
        }
    }
}
