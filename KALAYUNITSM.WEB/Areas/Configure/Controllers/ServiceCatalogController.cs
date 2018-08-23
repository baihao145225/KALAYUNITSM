using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE; 

namespace KALAYUNITSM.WEB.Areas.Configure.Controllers
{
    public class ServiceCatalogController : BaseController
    {
        private readonly IServiceCatalogService _serviceCatalogService;

        public ServiceCatalogController(IServiceCatalogService serviceCatalogService)
        {
            this._serviceCatalogService = serviceCatalogService;
        }

        #region 视图层
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 数据层

        [HttpPost]
        public ActionResult GetParent()
        {
            var data = _serviceCatalogService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (Conf_ServiceCatalog item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.EnCode + " : " + item.Name;
                model.parentId = item.ParentId;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }
        [HttpPost]
        public ActionResult GetListTree()
        {
            var listAllItems = _serviceCatalogService.GetList();
            List<ZTreeNode> result = new List<ZTreeNode>();
            foreach (var item in listAllItems)
            {
                ZTreeNode model = new ZTreeNode();
                model.id = item.Id;
                model.pId = item.ParentId;
                model.name = item.Name;
                model.open = true;
                result.Add(model);
            }
            return Content(result.ToJson());
        }
        [HttpPost]
        public ActionResult GetListTreeSelect()
        {
            var lists = _serviceCatalogService.GetList();
            var listTree = new List<TreeSelectModel>();
            foreach (var item in lists)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                listTree.Add(model);
            }
            return Content(listTree.ToJson());
        }
        public ActionResult Get(string id)
        {
            var model = _serviceCatalogService.Get(id);
            return Content(model.ToJson());
        }
        public ActionResult GetJsonData(string keyWord, string parentId)
        {
            var pageData = _serviceCatalogService.GetList(keyWord, parentId);
            var result = new LayUI<Conf_ServiceCatalog_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _serviceCatalogService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Conf_ServiceCatalog model)
        {
            if (model.Id.IsNullOrEmpty())
            {
                var primaryKey = _serviceCatalogService.Insert(model);
                return primaryKey != null ? Success() : Errors();
            }
            else
            {
                return _serviceCatalogService.Update(model) ? Success() : Errors();
            }
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _serviceCatalogService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}