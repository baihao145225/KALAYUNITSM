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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
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
            var pageData = _customerService.GetPageList(curr, nums, out count, keyWord);
            var result = new LayUI<Commerce_Customer>()
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
            List<Commerce_Customer> lists = _customerService.GetList();
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
            var entity = _customerService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Commerce_Customer model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _customerService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _customerService.Update(model) ? Success() : Errors();
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
            return _customerService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}