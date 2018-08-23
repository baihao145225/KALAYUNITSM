using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.App_Start.Handler
{
    public class ChkErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.ExceptionHandled = true;
            StringBuilder script = new StringBuilder();

           // LogHelper.Error(filterContext.Exception.StackTrace);

            if (OperatorProvider.Instance.Current == null)
            {
                script.Append("<script>top.alert('登陆超时，请重新认证。'); top.window.location.href='/Account/Login'</script>");
                filterContext.Result = new ContentResult() { Content = script.ToString() };
            }
            else
            {
                Operator onlineUser = OperatorProvider.Instance.Current;
               // LogHelper.Write(Level.Error, "程序抛异常", filterContext.Exception.StackTrace, onlineUser.Account, onlineUser.RealName);
                script.Append("<script>top.window.alert('系统出现异常，请联系开发人员确认。');</script>");
                filterContext.Result = new ContentResult() { Content = script.ToString() };
            }
        }
    }
}