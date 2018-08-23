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
    public class CIController : BaseController
    {
        private readonly ICIService _ciService;
        private readonly ICIGroupService _ciGroupService;

        public CIController(ICIService ciService, ICIGroupService ciGroupService)
        {
            this._ciService = ciService;
            this._ciGroupService = ciGroupService;
        }

        #region 视图层
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Form(string ciGroupId = "")
        {
            if (!ciGroupId.IsNullOrEmpty())
            {
                Conf_CIGroup model = _ciGroupService.Get(c => c.Id == ciGroupId);
                ViewData["page"] = model.EnCode;
            }
            return View();
        }
        #endregion

        #region 数据层
        public ActionResult GetJsonData(int curr, int nums, string keyWord, string ciGroupId)
        {
            int count;
            var pageData = _ciService.GetPageList(curr, nums, out count, keyWord, ciGroupId);
            var result = new LayUI<Conf_CI_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetListTree()
        {
            var listAllItems = _ciService.GetList();
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
            List<Conf_CI> lists = _ciService.GetList();
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
        public ActionResult GetListCombo()
        {
            List<Conf_CI> lists = _ciService.GetList();
            var listTree = new List<Conf_CI_Combo>();
            foreach (var item in lists)
            {
                Conf_CI_Combo combo = new Conf_CI_Combo();
                combo.id = item.Id;
                combo.name = item.Name;
                combo.desc = item.Label;
                listTree.Add(combo);
            }
            return Content(listTree.ToJson());
        }
        public ActionResult GetListPosition()
        {
            var listAllItems = _ciGroupService.GetList(t => t.ParentId == "1000");
            List<position> allposition = new List<position>();
            foreach (var aitem in listAllItems)
            {
                var position = new position();

                List<string> ps = new List<string>();
                ps.Add(aitem.Name);

                position.p = ps;

                List<c> allc = new List<c>();


                var listItems = _ciGroupService.GetList(t => t.ParentId == aitem.Id);

                foreach (var item in listItems)
                {
                    c c = new c();
                    c.n = item.Name;
                    var Items = _ciService.GetList(t => t.CIGroupId == item.Id);

                    List<a> alla = new List<a>();
                    foreach (var it in Items)
                    {
                        a a = new a();
                        a.s = it.Name;
                        alla.Add(a);
                    }
                    c.a = alla;
                    allc.Add(c);

                }
                position.c = allc;
                allposition.Add(position);
            }
            Conf_CI_SEL sel = new Conf_CI_SEL();
            sel.positionlist = allposition;
            return Content(sel.ToJson());
        }
        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _ciService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Conf_CI model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _ciService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _ciService.Update(model) ? Success() : Errors();
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
            return _ciService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}