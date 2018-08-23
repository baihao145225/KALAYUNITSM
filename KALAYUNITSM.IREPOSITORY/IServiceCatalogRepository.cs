using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IServiceCatalogRepository : IBaseRepository<Conf_ServiceCatalog>
    {
        Conf_ServiceCatalog_Dto Get(string Id);
        List<Conf_ServiceCatalog_Dto> GetList(string keyWord, string parentId);
    }
}
