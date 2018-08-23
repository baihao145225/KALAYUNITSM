using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IFAQsService : IBaseService<Itsm_FAQs>
    {
        Itsm_FAQs_Dto GetById(string Id);
        bool UpdateCount(string Id);
        List<Itsm_FAQs_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string categoryId);
    }
}
