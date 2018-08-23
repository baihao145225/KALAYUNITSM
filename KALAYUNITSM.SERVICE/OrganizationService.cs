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
    public class OrganizationService : BaseService<Sys_Organization>, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            this._organizationRepository = organizationRepository;
        }
        public List<Sys_Organization_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string parentId)
        {
            /* var expression = ExtLinq.True<Sys_Organization>();
             if (!keyword.IsNullOrEmpty())
             {
                 expression = expression.And(c => c.Name.Contains(keyword));
             }
             expression = expression.And(c => c.Id != "");
             return _organizationRepository.GetPageData(pageIndex, pageSize, out count, expression).ToList();
             */

            return _organizationRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord, parentId).ToList();
        }

        public long GetChildCount(string parentId)
        {
            return _organizationRepository.GetChildCount(parentId);
        }


    }
}
