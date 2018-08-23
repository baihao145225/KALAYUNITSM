using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace KALAYUNITSM.WEB
{

    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //接收上传后的文件
            HttpPostedFile file = context.Request.Files["Filedata"];
            //其他参数
            //string somekey = context.Request["someKey"];
            //string other = context.Request["someOtherKey"];
            //获取文件的保存路径
            string uploadPath =
                HttpContext.Current.Server.MapPath("\\OrderFiles" + "\\");
            //判断上传的文件是否为空
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string name = file.FileName;//获取文件名称
                int index = name.LastIndexOf(".");
                string lastName = name.Substring(index, name.Length - index);//文件后缀
                string newname = Guid.NewGuid() + lastName;//新文件名


                //保存文件
                file.SaveAs(uploadPath + newname);
                context.Response.Write(newname);
            }
            else
            {
            }

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