using System;
using System.Collections.Generic;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface ISLASLTsRepository : IBaseRepository<Conf_SLASLTs>
    {
        List<Conf_SLASLTs> GetList(string slaid);
    }
}
