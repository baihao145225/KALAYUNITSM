using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class CustomerRepository : BaseRepository<Commerce_Customer>, ICustomerRepository
    { 
    }
}
