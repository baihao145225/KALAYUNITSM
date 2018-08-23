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
    public class OrderTempleteController : BaseController
    {
        private readonly IOrderTempleteService _ordertempleteService;
        public OrderTempleteController(IOrderTempleteService ordertempleteService)
        {
            this._ordertempleteService = ordertempleteService;
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
            var pageData = _ordertempleteService.GetPageList(curr, nums, out count, keyWord);

            List<Itsm_OrderTemplete_Dto> output = AutoMapper.Mapper.Map<List<Itsm_OrderTemplete_Dto>>(pageData);
            var result = new LayUI<Itsm_OrderTemplete_Dto>()
            {
                result = true,
                msg = "success",
                data = output,
                count = count
            };
            return Content(result.ToJson());
        }
        public ActionResult GetJsonDataTop()
        {
            var data = _ordertempleteService.GetList().OrderByDescending(c => c.CreateTime).Take(10);

            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _ordertempleteService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm(Itsm_OrderTemplete model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _ordertempleteService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _ordertempleteService.Update(model) ? Success() : Errors();
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
            return _ordertempleteService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}