using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IOrderChkService : IBaseService<Itsm_OrderChk>
    {
        List<Itsm_OrderChk_Dto> GetDataList(string orderId);
    }
}
