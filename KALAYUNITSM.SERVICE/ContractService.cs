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
    public class ContractService : BaseService<Commerce_Contract>, IContractService
    {
        private readonly IContractRepository _contractRepository;
        public ContractService(IContractRepository contractRepository)
        {
            this._contractRepository = contractRepository;
        }
        public List<Commerce_Contract_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            return _contractRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord).ToList();
        }
    }
}
