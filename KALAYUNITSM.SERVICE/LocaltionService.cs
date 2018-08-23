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
    public class LocaltionService : BaseService<Conf_Localtion>, ILocaltionService
    {
        private readonly ILocaltionRepository _localtionRepository;
        public LocaltionService(ILocaltionRepository localtionRepository)
        {
            this._localtionRepository = localtionRepository;
        }
        public List<Conf_Localtion_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            return _localtionRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord).ToList();
        }
    }
}
