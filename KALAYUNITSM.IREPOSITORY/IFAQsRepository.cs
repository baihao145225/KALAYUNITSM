using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IFAQsRepository : IBaseRepository<Itsm_FAQs>
    {
        Itsm_FAQs_Dto GetById(string Id);
        bool UpdateCount(string Id);
        IEnumerable<Itsm_FAQs_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string categoryId);
    }
}
