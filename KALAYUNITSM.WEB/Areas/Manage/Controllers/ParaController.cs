using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Manage.Controllers
{
    public class ParaController : BaseController
    {
        [HttpPost]
        public ActionResult GetItemByCode(string itemCode)
        {
            var data = ConfigurationManager.AppSettings[itemCode].Split(',');
            var treeList = new List<TreeSelectModel>();
            for (int i = 0; i < data.Length; i++)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = i.ToString();
                model.text = Server.HtmlDecode(data[i].ToString());
                model.parentId = "1000";
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }
    }
}