using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Itsm.Controllers
{
    public class FAQsController : BaseController
    {

        private readonly IFAQsService _faqsService;

        public FAQsController(IFAQsService faqsService)
        {
            this._faqsService = faqsService;
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
        public ActionResult Detail(string id)
        {
            var model = _faqsService.GetById(id);
            _faqsService.UpdateCount(model.Id);
            Itsm_FAQs_Dto dto = AutoMapper.Mapper.Map<Itsm_FAQs_Dto>(model);

            return View(dto);
        }
        #endregion

        #region 数据层
        public ActionResult GetJsonData(string keyWord, string parentId, int curr, int nums)
        {
            int count;
            var pageData = _faqsService.GetPageList(curr, nums, out count, keyWord, parentId);

            var result = new LayUI<Itsm_FAQs_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }
        public ActionResult GetJsonDataForKeyWord(string keyWord)
        {
            var data = _faqsService.GetList(c => c.Name.Contains(keyWord)).OrderByDescending(c => c.Hits).Take(10);

            return Content(data.ToJson());
        }


        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _faqsService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm(Itsm_FAQs model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    model.Author = OperatorProvider.Instance.Current.Account;
                    model.EnCode = Tools.CreateNoWithPreFix("KL");
                    var primaryKey = _faqsService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _faqsService.Update(model) ? Success() : Errors();
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
            return _faqsService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}