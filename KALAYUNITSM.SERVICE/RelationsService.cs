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
    public class RelationsService : BaseService<Conf_Relations>, IRelationsService
    {
        private readonly IRelationsRepository _relationsRepository;
        public RelationsService(IRelationsRepository relationsRepository)
        {
            this._relationsRepository = relationsRepository;
        }
        public List<Conf_Relations> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Conf_Relations>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Name.Contains(keyWord));
            }
            return _relationsRepository.GetPageData(pageIndex, pageSize, out count, expression).ToList();
        }
    }
}
