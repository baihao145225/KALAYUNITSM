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
    public class SLTsService : BaseService<Conf_SLTs>, ISLTsService
    {
        private readonly ISLTsRepository _sltsRepository;
        public SLTsService(ISLTsRepository sltsRepository)
        {
            this._sltsRepository = sltsRepository;
        }
        public List<Conf_SLTs> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Conf_SLTs>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Name.Contains(keyWord));
            }
            expression = expression.And(c => c.Id != "");
            return _sltsRepository.GetPageData(pageIndex, pageSize, out count, expression).ToList();
        } 
    }
}
