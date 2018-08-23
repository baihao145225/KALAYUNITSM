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
    public class CIRelationsService : BaseService<Conf_CIRelations>, ICIRelationsService
    {
        private readonly ICIRelationsRepository _cirelationsRepository;
        public CIRelationsService(ICIRelationsRepository cirelationsRepository)
        {
            this._cirelationsRepository = cirelationsRepository;
        }
        public IEnumerable<Conf_CIRelations_Dto> GetJoinList(string ciId)
        {
            return _cirelationsRepository.GetJoinList(ciId).ToList().OrderByDescending(c => c.CreateTime);
        }
    }
}
