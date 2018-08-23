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
    public class CIService : BaseService<Conf_CI>, ICIService
    {
        private readonly ICIRepository _ciRepository;
        public CIService(ICIRepository ciRepository)
        {
            this._ciRepository = ciRepository;
        }
        public List<Conf_CI_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string ciGroupId)
        {
            return _ciRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord, ciGroupId).ToList();
        }
    }
}
