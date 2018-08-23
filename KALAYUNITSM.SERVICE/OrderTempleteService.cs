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
    public class OrderTempleteService : BaseService<Itsm_OrderTemplete>, IOrderTempleteService
    {
        private readonly IOrderTempleteRepository _ordertempleteRepository;
        public OrderTempleteService(IOrderTempleteRepository ordertempleteRepository)
        {
            this._ordertempleteRepository = ordertempleteRepository;
        }
        public List<Itsm_OrderTemplete> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Itsm_OrderTemplete>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Name.Contains(keyWord));
            }
            expression = expression.And(c => c.Id != "");
            return _ordertempleteRepository.GetPageData(pageIndex, pageSize, out count, expression).ToList();
        } 
    }
}
