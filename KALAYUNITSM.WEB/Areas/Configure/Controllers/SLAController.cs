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
    public class SLAController : BaseController
    {
        private readonly ISLAService _slaService;
        private readonly ISLASLTsService _slaSltsService;

        public SLAController(ISLAService slaService, ISLASLTsService slaSltsService)
        {
            this._slaService = slaService;
            this._slaSltsService = slaSltsService;
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
            var pageData = _slaService.GetPageList(curr, nums, out count, keyWord);
            var result = new LayUI<Conf_SLA_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _slaService.Get(primaryKey);
            Conf_SLA_Dto dto = AutoMapper.Mapper.Map<Conf_SLA_Dto>(entity);
            dto.SLTsId = _slaSltsService.GetList(entity.Id).Select(c => c.SLTsId).ToList();
            return Content(dto.ToJson());
        }
        #endregion


        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Conf_SLA model, string sltIds)
        {
            if (model.Id.IsNullOrEmpty())
            {
                _slaService.Insert(model);
                var slaId = _slaService.GetFirst(c => c.Name == model.Name).Id;
                _slaSltsService.SetSLTs(slaId, sltIds.ToStrArray());

                return slaId != null ? Success() : Errors();
            }
            else
            {
                _slaSltsService.SetSLTs(model.Id, sltIds.ToStrArray());
                return _slaService.Update(model) ? Success() : Errors();
            }
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _slaService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}