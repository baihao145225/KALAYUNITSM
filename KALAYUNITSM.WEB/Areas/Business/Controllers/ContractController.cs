using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Business.Controllers
{
    public class ContractController : BaseController
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            this._contractService = contractService;
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
        public ActionResult GetJsonData(int curr, int nums, string keyWord)
        {
            int count;
            var pageData = _contractService.GetPageList(curr, nums, out count, keyWord);
            var result = new LayUI<Commerce_Contract_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetListTreeSelect()
        {
            List<Commerce_Contract> lists = _contractService.GetList();
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
            var entity = _contractService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Commerce_Contract model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _contractService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _contractService.Update(model) ? Success() : Errors();
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
            return _contractService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}