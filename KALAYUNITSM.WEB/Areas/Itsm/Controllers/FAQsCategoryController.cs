using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Itsm
{
    public class FAQsCategoryController : BaseController
    {
        private readonly IFAQsCategoryService _faqsCategoryService;

        public FAQsCategoryController(IFAQsCategoryService faqsCategoryService)
        {
            this._faqsCategoryService = faqsCategoryService;
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
            var pageData = _faqsCategoryService.GetPageList(curr, nums, out count, keyWord);
            var result = new LayUI<Itsm_FAQsCategory>()
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
            List<Itsm_FAQsCategory> lists = _faqsCategoryService.GetList();
            var listTree = new List<TreeSelectModel>();
            foreach (var item in lists)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                model.parentId = "1000";
                listTree.Add(model);
            }
            return Content(listTree.ToJson());
        }
        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _faqsCategoryService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion
        #region 操作层

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Itsm_FAQsCategory model)
        {
            if (model.Id.IsNullOrEmpty())
            {
                var primaryKey = _faqsCategoryService.Insert(model);
                return primaryKey != null ? Success() : Errors();
            }
            else
            {
                return _faqsCategoryService.Update(model) ? Success() : Errors();
            }
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _faqsCategoryService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}