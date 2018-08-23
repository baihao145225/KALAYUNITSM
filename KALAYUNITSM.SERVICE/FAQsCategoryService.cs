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
    public class FAQsCategoryService : BaseService<Itsm_FAQsCategory>, IFAQsCategoryService
    {
        private readonly IFAQsCategoryRepository _faqscategoryRepository;
        public FAQsCategoryService(IFAQsCategoryRepository faqscategoryRepository)
        {
            this._faqscategoryRepository = faqscategoryRepository;
        }
        public List<Itsm_FAQsCategory> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Itsm_FAQsCategory>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Name.Contains(keyWord));
            }
            expression = expression.And(c => c.Id != "");
            return _faqscategoryRepository.GetPageData(pageIndex, pageSize, out count, expression, c => c.CreateTime).ToList();
        }
    }
}
