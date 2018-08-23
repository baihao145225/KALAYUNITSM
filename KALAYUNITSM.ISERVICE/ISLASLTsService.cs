using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface ISLASLTsService : IBaseService<Conf_SLASLTs>
    {
        List<Conf_SLASLTs> GetList(string slaId);
        void SetSLTs(string slaId, params string[] sltIds);
    }
}
