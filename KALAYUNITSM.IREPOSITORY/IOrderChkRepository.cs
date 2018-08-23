using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IOrderChkRepository : IBaseRepository<Itsm_OrderChk>
    {
        List<Itsm_OrderChk_Dto> GetDataList(string orderId);
    }
}
