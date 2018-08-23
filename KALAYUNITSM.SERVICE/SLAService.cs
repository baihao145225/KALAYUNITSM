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
    public class SLAService : BaseService<Conf_SLA>, ISLAService
    {
        private readonly ISLARepository _slaRepository;
        public SLAService(ISLARepository slaRepository)
        {
            this._slaRepository = slaRepository;
        }
        public List<Conf_SLA_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            return _slaRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord).ToList();
        }
    }
}
