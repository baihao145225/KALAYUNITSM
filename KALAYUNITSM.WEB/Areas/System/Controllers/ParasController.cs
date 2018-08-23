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
    public class ParasController : BaseController
    {
        public ActionResult GetOrderFromTreeJson()
        {
            var data = Tools.ToListItem<OrderFromEnums>();

            var treeList = new List<TreeSelectModel>();
            foreach (var item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Value;
                treeModel.text = item.Text;
                treeModel.parentId = "99";
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
        public ActionResult GetUrgencyLevelTreeJson()
        {
            var data = Tools.ToListItem<UrgencyLevelEnums>();

            var treeList = new List<TreeSelectModel>();
            foreach (var item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Value;
                treeModel.text = item.Text;
                treeModel.parentId = "99";
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
        public ActionResult GetEffectLevelTreeJson()
        {
            var data = Tools.ToListItem<EffectLevelEnums>();

            var treeList = new List<TreeSelectModel>();
            foreach (var item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Value;
                treeModel.text = item.Text;
                treeModel.parentId = "99";
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
        public ActionResult GetOrderSolutionResultTreeJson()
        {
            var data = Tools.ToListItem<OrderSolutionResultEnums>();

            var treeList = new List<TreeSelectModel>();
            foreach (var item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Value;
                treeModel.text = item.Text;
                treeModel.parentId = "99";
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
        public ActionResult GetServiceCatalogTypeTreeJson()
        {
            var data = Tools.ToListItem<ServiceCatalogTypeEnums>();

            var treeList = new List<TreeSelectModel>();
            foreach (var item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Value;
                treeModel.text = item.Text;
                treeModel.parentId = "99";
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
    }
}