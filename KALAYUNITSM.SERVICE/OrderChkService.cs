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
    public class OrderChkService : BaseService<Itsm_OrderChk>, IOrderChkService
    {
        private readonly IOrderChkRepository _ordersRepository;
        public OrderChkService(IOrderChkRepository ordersRepository)
        {
            this._ordersRepository = ordersRepository;
        }
        public List<Itsm_OrderChk_Dto> GetDataList(string orderId)
        {
            return _ordersRepository.GetDataList(orderId).ToList();
        }
    }
}
