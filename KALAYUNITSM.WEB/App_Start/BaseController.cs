using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.WEB
{
    [ChkLogin]
    public abstract class BaseController : Controller
    {
        protected ActionResult Success(string message = "提示：您本次操作成功。", string url = "", object data = null)
        {
            return Content(new AjaxResult(ResultType.Success.ToString(), message, url, data).ToJson());
        }
        protected ActionResult Errors(string message = "提示：您本次操作失败。", string url = "", object data = null)
        {
            return Content(new AjaxResult(ResultType.Errors.ToString(), message, url, data).ToJson());
        }
        protected ActionResult Exception(string message = "提示：操作引发系统报错。", string url = "", object data = null)
        {
            return Content(new AjaxResult(ResultType.Exception.ToString(), message, url, data).ToJson());
        }
        protected ActionResult Warning(string message, string url = "", object data = null)
        {
            return Content(new AjaxResult(ResultType.Warning.ToString(), message, url, data).ToJson());
        }
        protected ActionResult Info(string message, string url = "", object data = null)
        {
            return Content(new AjaxResult(ResultType.Info.ToString(), message, url, data).ToJson());
        }
    }
}