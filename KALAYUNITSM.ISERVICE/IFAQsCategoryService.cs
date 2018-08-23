using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IFAQsCategoryService : IBaseService<Itsm_FAQsCategory>
    {
        List<Itsm_FAQsCategory> GetPageList(int pageIndex, int pageSize, out int count, string keyWord);
    }
}
