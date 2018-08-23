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
    public class RelationsController : BaseController
    {

        private readonly IRelationsService _relationsService;
        private readonly ICIRelationsService _ciRelationsService;

        public RelationsController(IRelationsService relationsService, ICIRelationsService ciRelationsService)
        {
            this._relationsService = relationsService;
            this._ciRelationsService = ciRelationsService;
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
        public ActionResult Distribution()
        {
            return View();
        }
        #endregion

        #region 数据层
        public ActionResult GetJsonData(int curr, int nums, string keyWord)
        {
            int count;
            var pageData = _relationsService.GetPageList(curr, nums, out count, keyWord);
            var result = new LayUI<Conf_Relations>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }
        public ActionResult GetJsonDataForCI(string id)
        {
            var data = _ciRelationsService.GetJoinList(id);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult GetListTree()
        {
            var listAllItems = _relationsService.GetList();
            List<ZTreeNode> result = new List<ZTreeNode>();
            foreach (var item in listAllItems)
            {
                ZTreeNode model = new ZTreeNode();
                model.id = item.Id;
                model.pId = "1000";
                model.name = item.Name;
                model.open = true;
                result.Add(model);
            }
            return Content(result.ToJson());
        }
        [HttpPost]
        public ActionResult GetListTreeSelect()
        {
            List<Conf_Relations> lists = _relationsService.GetList();
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
        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _relationsService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Conf_Relations model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _relationsService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _relationsService.Update(model) ? Success() : Errors();
                }
            }
            catch (Exception ex)
            {
                return Exception(ex.Message);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveRelation(Conf_CIRelations model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _ciRelationsService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _ciRelationsService.Update(model) ? Success() : Errors();
                }
            }
            catch (Exception ex)
            {
                return Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _relationsService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}