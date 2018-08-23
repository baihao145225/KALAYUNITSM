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
    public class PermissionController : BaseController
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        } 

        #region 视图层
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Icon()
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
            var pageData = _permissionService.GetPageList(curr, nums, out count, keyWord);

            var result = new LayUI<Sys_Permission>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetParent()
        {
            var data = _permissionService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_Permission item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                model.parentId = item.ParentId;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _permissionService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Sys_Permission model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    var primaryKey = _permissionService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _permissionService.Update(model) ? Success() : Errors();
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
            string[] paras = primaryKey.ToStrArray();
            foreach (var item in paras)
            {
                long count = _permissionService.GetChildCount(item);
                if (count == 0)
                {
                    return _permissionService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();
                }
                return Errors(string.Format("操作失败，该项还包含有 {0} 个子级权限。", count));
            }
            return Success("删除成功。");

        }
        public ActionResult ExportExcel(string primaryKey)
        {
            try
            {
                string[] paras = primaryKey.ToStrArray();
                var queryData = _permissionService.GetList(paras);

                List<Sys_Permission_Dto> dtoData = AutoMapper.Mapper.Map<List<Sys_Permission_Dto>>(queryData);
                NPOIExcelHelper excel = new NPOIExcelHelper("全部数据", "权限列表");
                byte[] output = excel.ToExcel(dtoData, ExportTemplate.Permission_Export);

                Response.AddHeader("content-disposition", "attachment;filename=" + Tools.CreateNo() + ".xls");
                Response.BinaryWrite(output);
                Response.Flush();
                Response.End();
                return Success("导出成功。");
            }
            catch (Exception ex)
            {

                return Exception(ex.Message);
            }
        }

        #endregion
    }
}