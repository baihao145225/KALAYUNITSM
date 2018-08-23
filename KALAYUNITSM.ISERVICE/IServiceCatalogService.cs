using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IServiceCatalogService : IBaseService<Conf_ServiceCatalog>
    {
        Conf_ServiceCatalog_Dto  Get(string Id);
        List<Conf_ServiceCatalog_Dto> GetList(string keyWord, string parentId);
    }
}
