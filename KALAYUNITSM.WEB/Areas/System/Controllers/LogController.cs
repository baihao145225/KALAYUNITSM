using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.System.Controllers
{
    public class LogController : BaseController
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            this._logService = logService;
        }

        #region 视图层
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 数据层
        public ActionResult GetJsonData(int curr, int nums, string keyWord)
        {
            int count;
            var pageData = _logService.GetPageList(curr, nums, out count, keyWord);

            var result = new LayUI<Sys_Log>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _logService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        public ActionResult ExportExcel(string primaryKey)
        {
            try
            {
                string[] paras = primaryKey.ToStrArray();
                var queryData = _logService.GetList(paras);
                 
                NPOIExcelHelper excel = new NPOIExcelHelper("全部数据", "列表");
                byte[] output = excel.ToExcel(queryData, ExportTemplate.Log_Export);

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