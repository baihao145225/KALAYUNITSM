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
    public class PositionController : BaseController
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            this._positionService = positionService;
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
        [HttpPost]
        public ActionResult GetParent()
        {
            var data = _positionService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_Position item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Id;
                model.text = item.Name;
                model.parentId = item.ParentId;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }


        public ActionResult GetJsonData(int curr, string parentId, int nums, string keyWord)
        {
            int count;
            var pageData = _positionService.GetPageList(curr, nums, out count, keyWord, parentId);
            var result = new LayUI<Sys_Position_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetListTree()
        {
            var listAllItems = _positionService.GetList();
            List<ZTreeNode> result = new List<ZTreeNode>();
            foreach (var item in listAllItems)
            {
                ZTreeNode model = new ZTreeNode();
                model.id = item.Id;
                model.pId = item.ParentId;
                model.name = item.Name;
                model.open = true;
                result.Add(model);
            }
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetListTreeByPosition()
        {
            string positionId = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.PositionId;
            var listAllItems = _positionService.GetChildPositionByPositionID(positionId);
            List<ZTreeNode> result = new List<ZTreeNode>();

            ZTreeNode rootNode = new ZTreeNode();
            var me = _positionService.GetPosition(positionId);
            rootNode.id = me.Id;
            rootNode.pId = me.ParentId;
            rootNode.name = me.Name;
            rootNode.open = true;
            result.Add(rootNode);

            foreach (var item in listAllItems)
            {
                ZTreeNode model = new ZTreeNode();
                model.id = item.Id;
                model.pId = item.ParentId;
                model.name = item.Name;
                model.open = true;
                result.Add(model);
            }
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetListTreeSelect()
        {
            List<Sys_Position> lists = _positionService.GetList();
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
            var entity = _positionService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveForm(Sys_Position model)
        {
            if (model.Id.IsNullOrEmpty())
            {
                var primaryKey = _positionService.Insert(model);
                return primaryKey != null ? Success() : Errors();
            }
            else
            {
                return _positionService.Update(model) ? Success() : Errors();
            }
        }



        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _positionService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();
        }

        public ActionResult ByUser()
        {

            int count = 0;
            List<Sys_User_Dto> users = _positionService.GetUserByPosition(0, 50, out count, "A515725D-2A54-4B08-B675-FA266B06E6AE");
            return Content(users.ToJson());
        }

        #endregion
    }
}