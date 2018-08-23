using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Itsm.Controllers
{
    public class OrderChkController : BaseController
    {
        private readonly IOrderChkService _orderchkService;
        private readonly IOrdersService _ordersService;
        private readonly IUserService _userService;
        public OrderChkController(IUserService userService, IOrdersService ordersService, IOrderChkService orderchkService)
        {
            this._userService = userService;
            this._ordersService = ordersService;
            this._orderchkService = orderchkService;
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
        public ActionResult New()
        {
            return View();
        }
        public ActionResult CheckInOrder()
        {
            return View();
        }
        public ActionResult AllocateOrder()
        {
            return View();
        }

        public ActionResult SolveOrder(string primaryKey)
        {
            return View();
        }
        #endregion

        #region 数据层
        public ActionResult GetJsonData(string id)
        {
            var data = _orderchkService.GetDataList(id).OrderByDescending(c => c.CreateTime);
            foreach (var item in data)
            {
                item.OrderChkStatusTitle = item.OrderChkStatus.ToString();
            }
            List<Itsm_OrderChk_Dto> output = AutoMapper.Mapper.Map<List<Itsm_OrderChk_Dto>>(data);
            return Content(output.ToJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _orderchkService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm(Itsm_OrderChk model)
        {
            try
            {
                Itsm_Orders modelorder = _ordersService.Get(c => c.OrderId == model.OrderId);
                if (modelorder.StatusCode != OrdersStatusEnums.已登记)
                {
                    return Errors(SystemItemMsgs.ITSM_ORDERSTATUS_CANCEL_ERROR);
                }
             
                model.CreateUser = OperatorProvider.Instance.Current.Account;
                model.CurrUser = OperatorProvider.Instance.Current.Account;
                var primaryKey = _orderchkService.Insert(model);

                modelorder.StatusCode = model.OrderChkStatus;
                if (model.NextUser.IsNullOrEmpty())
                {
                    modelorder.CurrUser = OperatorProvider.Instance.Current.Account;
                }
                else
                {
                    modelorder.CurrUser = model.NextUser;
                }

                _ordersService.Update(modelorder);

                return primaryKey != null ? Success() : Errors();
            }
            catch (Exception ex)
            {
                return Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult CancelOrder(string primaryKey)
        {
            Itsm_Orders modelorder = _ordersService.Get(c => c.OrderId == primaryKey);
            if (modelorder.StatusCode != OrdersStatusEnums.已登记)
            {
                return Errors(SystemItemMsgs.ITSM_ORDERSTATUS_CANCEL_ERROR);
            }
            Itsm_OrderChk model = new Itsm_OrderChk();
            model.OrderId = primaryKey;
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CurrUser = OperatorProvider.Instance.Current.Account;
            //model.OrderChkStatus = OrdersStatusEnums.已取消;
            modelorder.StatusCode = model.OrderChkStatus;
            modelorder.CurrUser = OperatorProvider.Instance.Current.Account;
            _ordersService.Update(modelorder);

            return _orderchkService.Insert(model) != null ? Success() : Errors();
        }
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveSolveOrder(Itsm_OrderChk model)
        {
            Itsm_Orders modelorder = _ordersService.Get(c => c.OrderId == model.OrderId);
            if ((modelorder.StatusCode & OrdersStatusEnums.处理中) == 0)
            {
                //return Content(" <script >alert('" + SystemItemMsgs.ITSM_ORDERSTATUS_SLOVE_ERROR + "！');</script >");

                return Errors(SystemItemMsgs.ITSM_ORDERSTATUS_SLOVE_ERROR);
            } 
            if (modelorder.CurrUser != OperatorProvider.Instance.Current.Account)
            {
                return Errors(SystemItemMsgs.ITSM_CHK_ORDERCURRUSER_ERROR);
            }
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CurrUser = OperatorProvider.Instance.Current.Account;
            model.OrderChkStatus = OrdersStatusEnums.已解决;
            modelorder.StatusCode = model.OrderChkStatus;
            modelorder.CurrUser = OperatorProvider.Instance.Current.Account;
            _ordersService.Update(modelorder);

            return _orderchkService.Insert(model) != null ? Success() : Errors();
        }
        [HttpPost]
        public ActionResult CloseOrder(string primaryKey)
        {
            Itsm_Orders modelorder = _ordersService.Get(c => c.OrderId == primaryKey);
            if ((modelorder.StatusCode & OrdersStatusEnums.处理中) != 0)
            {
                return Errors(SystemItemMsgs.ITSM_ORDERSTATUS_CLOSE_ERROR);
            }
            Itsm_OrderChk model = new Itsm_OrderChk();
            model.OrderId = primaryKey;
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CurrUser = OperatorProvider.Instance.Current.Account;
            model.OrderChkStatus = OrdersStatusEnums.已关闭;
            modelorder.StatusCode = model.OrderChkStatus;
            modelorder.CurrUser = OperatorProvider.Instance.Current.Account;
            _ordersService.Update(modelorder);

            return _orderchkService.Insert(model) != null ? Success() : Errors();
        }
        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _orderchkService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}