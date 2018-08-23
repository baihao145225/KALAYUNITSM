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
    public class SLTsController : BaseController
    {
       private readonly ISLTsService _sltsService;

       public SLTsController(ISLTsService sltsService)
        {
            this._sltsService = sltsService;
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
            var pageData = _sltsService.GetPageList(curr, nums, out count, keyWord);

            List<Conf_SLTs_Dto> output = AutoMapper.Mapper.Map<List<Conf_SLTs_Dto>>(pageData);
            foreach (var item in output)
            {
                item.EffectLevel = item.EffectLevel.ToString();
            }
            var result = new LayUI<Conf_SLTs_Dto>()
            {
                result = true,
                msg = "success",
                data = output,
                count = count
            };
            return Content(result.ToJson());
        }
        [HttpPost]
        public ActionResult GetListTreeSelect()
        {
            List<Conf_SLTs> lists = _sltsService.GetList();
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
            var entity = _sltsService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Conf_SLTs model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _sltsService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _sltsService.Update(model) ? Success() : Errors();
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
            return _sltsService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}