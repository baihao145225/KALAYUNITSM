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
    public class ServiceCatalogService : BaseService<Conf_ServiceCatalog>, IServiceCatalogService
    {
        private readonly IServiceCatalogRepository _serviceCatalogRepository;
        public ServiceCatalogService(IServiceCatalogRepository serviceCatalogRepository)
        {
            this._serviceCatalogRepository = serviceCatalogRepository;
        }
        public Conf_ServiceCatalog_Dto Get(string Id)
        {
            return _serviceCatalogRepository.Get(Id);
        }
        public List<Conf_ServiceCatalog_Dto> GetList(string keyWord, string parentId)
        {
            return _serviceCatalogRepository.GetList(keyWord, parentId);
        }
    }
}
