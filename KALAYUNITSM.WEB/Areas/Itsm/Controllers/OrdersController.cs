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
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _ordersService;
        private readonly ISLAService _slaService;
        private readonly ISLASLTsService _slasltsService;
        private readonly ISLTsService _sltsService;
        private readonly IOrderChkService _orderchkService;
        private readonly IPermissionService _permissionService;

        public OrdersController(IOrdersService ordersService, ISLAService slaService, ISLASLTsService slasltsService, ISLTsService sltsService, IOrderChkService orderchkService, IPermissionService permissionService)
        {
            this._ordersService = ordersService;
            this._slaService = slaService;
            this._slasltsService = slasltsService;
            this._sltsService = sltsService;
            this._orderchkService = orderchkService;
            this._permissionService = permissionService;
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
        public ActionResult MyOrder()
        {
            return View();
        }
        public ActionResult Detail(string id)
        {
            Itsm_Orders_Dto model = _ordersService.GetOrder(id);
            return View(model);
        }
        public ActionResult GetSelect(int id)
        {
            var listButtons = _permissionService.GetList(t => t.ButtonStatus > id).ToList();
            // string paymentModeEnumJson = typeof(OrdersStatusEnums).EnumToJson();  
            /*string str = "";
             OrdersStatusEnums nenum = (OrdersStatusEnums)Enum.Parse(typeof(OrdersStatusEnums), id);
             foreach (OrdersStatusEnums ne in Enum.GetValues(typeof(OrdersStatusEnums)))
             {
                 str += ((int)ne + ":" + ne + "\\");
             } 
          
            List<Itsm_OrderButton> buttons = new List<Itsm_OrderButton>();
            buttons.Add(new Itsm_OrderButton() { EnCode = 2, Name = "取消", Icon = "fa fa-circle-thin", JsEvent = "canel" });
            buttons.Add(new Itsm_OrderButton() { EnCode = 4, Name = "挂起", Icon = "fa fa-edit", JsEvent = "canel" });
            buttons.Add(new Itsm_OrderButton() { EnCode = 8, Name = "流转", Icon = "fa fa-retweet", JsEvent = "canel" });
            buttons.Add(new Itsm_OrderButton() { EnCode = 16, Name = "分派", Icon = "fa fa-cog", JsEvent = "canel" });
            buttons.Add(new Itsm_OrderButton() { EnCode = 32, Name = "解决", Icon = "fa fa-wrench", JsEvent = "canel" });
            buttons.Add(new Itsm_OrderButton() { EnCode = 642, Name = "升级", Icon = "fa fa-edit", JsEvent = "canel" });
            List<Itsm_OrderButton> button = buttons.Where(t => t.EnCode > id).ToList();
             */
            return Content(listButtons.ToJson());
        }
        #endregion

        #region 数据层
        public ActionResult GetJsonData(int curr, int nums, string keyWord)
        {
            int count;
            var pageData = _ordersService.GetPageList(curr, nums, out count, keyWord);
            foreach (var item in pageData)
            {
                var d3 = Tools.DateDiff(item.FinishTime, DateTime.Now);
                if (item.FinishTime.CompareTo(DateTime.Now) <= 0)
                {
                    item.SlaTitle = "超：" + d3.Days.ToString() + "天" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟";
                }
                else
                {
                    item.SlaTitle = "余:" + d3.Days.ToString() + "天" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟";
                }
                item.StatusName = item.StatusCode.ToString();
            }
            var result = new LayUI<Itsm_Orders_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }
        public ActionResult GetMyJsonData(int curr, int nums, string keyWord)
        {
            int count;
            var pageData = _ordersService.GetPageList(curr, nums, out count, keyWord).Where(t => t.CurrUser == OperatorProvider.Instance.Current.Account).ToList();
            foreach (var item in pageData)
            {
                var d3 = Tools.DateDiff(item.FinishTime, DateTime.Now);
                if (item.FinishTime.CompareTo(DateTime.Now) <= 0)
                {
                    item.SlaTitle = "超：" + d3.Days.ToString() + "天" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟";
                }
                else
                {
                    item.SlaTitle = "余:" + d3.Days.ToString() + "天" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟";
                }
                item.StatusName = item.StatusCode.ToString();
            }
            var result = new LayUI<Itsm_Orders_Dto>()
            {
                result = true,
                msg = "success",
                data = pageData,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _ordersService.Get(primaryKey);
            return Content(entity.ToJson());
        }
        #endregion

        #region 操作层
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm(Itsm_Orders model)
        {
            try
            {
                if (model.Id.IsNullOrEmpty())
                {
                    model.CreateUser = OperatorProvider.Instance.Current.Account;
                    string sla = _slaService.Get(c => c.ContractId == model.ContractId).Id;
                    List<Conf_SLASLTs> slaslts = _slasltsService.GetList(c => c.SLAId == sla);
                    List<Conf_SLTs> slts = new List<Conf_SLTs>();
                    foreach (var item in slaslts)
                    {
                        slts.Add(_sltsService.Get(c => c.Id == item.SLTsId));
                    }
                    var records = slts.Where(c => c.EffectLevel == model.EffectId && c.UrgencyLevel == model.UrgencyId).ToList();
                    Conf_SLTs slt = records.Count == 0 ? _sltsService.Get(c => c.IsDefault == true) : records.First();
                    model.PriorityId = slt.Name;
                    model.StatusCode = OrdersStatusEnums.已登记;
                    model.ResponseTime = Convert.ToDateTime(model.RegisterTime).AddMinutes(slt.ResponseDuration);
                    model.FinishTime = Convert.ToDateTime(model.RegisterTime).AddMinutes
                    (slt.FinishDuration);

                    Itsm_OrderChk modelchk = new Itsm_OrderChk();
                    modelchk.OrderId = model.OrderId;
                    modelchk.CreateUser = OperatorProvider.Instance.Current.Account;
                    modelchk.CurrUser = OperatorProvider.Instance.Current.Account;
                    modelchk.OrderChkStatus = OrdersStatusEnums.已登记;
                    modelchk.FinishedTime = DateTime.Now;
                    _orderchkService.Insert(modelchk);

                    var primaryKey = _ordersService.Insert(model);
                    return primaryKey != null ? Success() : Errors();
                }
                else
                {
                    return _ordersService.Update(model) ? Success() : Errors();
                }
            }
            catch (Exception ex)
            {
                return Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _ordersService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}