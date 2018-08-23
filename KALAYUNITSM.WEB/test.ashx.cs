using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KALAYUNITSM.WEB
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //post接收的数据参数
            //context.Request.Params = {sidx=&page=1&sord=&rows=10&searchTerm=sad&ALL_HTTP=HTTP_CONNECTION%3aKeep-Alive%0d%0aHTTP_ACCEPT%3aapplication%2fjson%2c+text%2fjavascript%2c+*%2f*%3b+q%3d0.01%0d%0aHTTP_ACCEPT_ENCODING%3agzip%2c+deflate%0d%0aHTTP_ACCEPT_LANGUAGE%3azh-cn%0d%0aHTTP_HOST%3al...

            string searchTerm = context.Request.Params["searchTerm"];
            //Json数据格式：多属性及多数据行
            string str = @"{""records"":[""1""],""total"":[""2""],""rows"":[{""id"":""" + searchTerm + @""",""name"":""项目发布"",""author"":""354435""},{""id"":""陈明"",""name"":""环中国"",""author"":""title""}]}";
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}