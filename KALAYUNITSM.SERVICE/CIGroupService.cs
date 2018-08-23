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
    public class CIGroupService : BaseService<Conf_CIGroup>, ICIGroupService
    {
        private readonly ICIGroupRepository _cigroupRepository;
        public CIGroupService(ICIGroupRepository cigroupRepository)
        {
            this._cigroupRepository = cigroupRepository;
        }
        public List<Conf_CIGroup_Dto> GetListCount()
        {
            return _cigroupRepository.GetListCount().ToList();
        }
        public List<Conf_CIGroup_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string parentId)
        {
            return _cigroupRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord, parentId).ToList();
        }
    }
}
