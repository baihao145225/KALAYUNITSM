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
    public class CustomerService : BaseService<Commerce_Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public List<Commerce_Customer> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Commerce_Customer>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Name.Contains(keyWord));
            }
            expression = expression.And(c => c.Id != "");
            return _customerRepository.GetPageData(pageIndex, pageSize, out count, expression, c => c.CreateTime).ToList();
        }
    }
}
