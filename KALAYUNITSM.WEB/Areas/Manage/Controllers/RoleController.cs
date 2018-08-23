using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Manage.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
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
            var pageData = _roleService.GetPageList(curr, nums, out count, keyWord);
            var result = new LayUI<Sys_Role_Dto>()
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
            List<Sys_Role> lists = _roleService.GetList();
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
            var entity = _roleService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Sys_Role model)
        {
            if (model.Id.IsNullOrEmpty())
            {
                var primaryKey = _roleService.Insert(model);
                return primaryKey != null ? Success() : Errors();
            }
            else
            {
                return _roleService.Update(model) ? Success() : Errors();
            }
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _roleService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();
        }

        #endregion
    }
}