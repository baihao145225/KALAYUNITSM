using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB
{
    public class ChkActionOrderStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            StringBuilder script = new StringBuilder();
            string sss = filterContext.ActionParameters["primaryKey"].ToString();
            if (sss != "token")
            {
                script.Append("<script>top.window.alert('系统出现异常，请联系开发人员确认。');</script>");
                filterContext.Result = new ContentResult() { Content = script.ToString() };

            }
        }


    }
}