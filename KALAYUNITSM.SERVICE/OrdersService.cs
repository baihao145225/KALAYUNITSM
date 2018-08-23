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
    public class OrdersService : BaseService<Itsm_Orders>, IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            this._ordersRepository = ordersRepository;
        }
        public Itsm_Orders_Dto GetOrder(string orderid)
        {
            return _ordersRepository.GetOrder(orderid);
        }
        public List<Itsm_Orders_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            return _ordersRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord).ToList();
        }
    }
}
