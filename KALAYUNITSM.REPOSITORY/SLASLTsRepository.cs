using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    class SLASLTsRepository : BaseRepository<Conf_SLASLTs>, ISLASLTsRepository
    {
        public List<Conf_SLASLTs> GetList(string slaid)
        {
            return base.GetDataList(t => t.SLAId == slaid);
        }
    }
}
