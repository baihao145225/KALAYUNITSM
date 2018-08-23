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
    public class FAQsService : BaseService<Itsm_FAQs>, IFAQsService
    {
        private readonly IFAQsRepository _faqsRepository;
        public FAQsService(IFAQsRepository faqsRepository)
        {
            this._faqsRepository = faqsRepository;
        }
        public Itsm_FAQs_Dto GetById(string Id)
        {
            return _faqsRepository.GetById(Id);
        }
        public bool UpdateCount(string Id)
        {
            return _faqsRepository.UpdateCount(Id);
        }
        public List<Itsm_FAQs_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string categoryId)
        {
            return _faqsRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord, categoryId).ToList();
        }
    }
}
