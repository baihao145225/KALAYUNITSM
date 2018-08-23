using KALAYUNITSM.ENTITY.WeeklyReports;
using systemPrimordial = System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using KALAYUNITSM.IREPOSITORY;
using Aspose.Words;
using System.Text;
using System.IO;
using System;
using PagedList;
using KALAYUNITSM.ISERVICE;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using Newtonsoft.Json;
using System.Xml;

namespace KALAYUNITSM.WEB.Areas.WeeklyReports.Controllers
{
    public class WeeklyReportsController : BaseController
    {
        // GET: WeeklyReports/WeeklyReports
        public IWeeklyReportsRepository _IWeeklyReportsRepository;
        public IReportsDataRepository _IReportsDataRepository;
        private readonly IPositionService _positionService;
        private readonly IUserService _userService;
        private readonly IUserPositionRelationService _userPositionRelationService;
        private readonly IOrdersService _ordersService;
        public static string path;
        public WeeklyReportsController(IOrdersService ordersService, IWeeklyReportsRepository IWeeklyReportsRepository, IReportsDataRepository IReportsDataRepository, IPositionService positionService, IUserService userService, IUserPositionRelationService userPositionRelationService)
        {
            this._ordersService = ordersService;
            this._userService = userService;
            this._IWeeklyReportsRepository = IWeeklyReportsRepository;
            this._IReportsDataRepository = IReportsDataRepository;
            this._positionService = positionService;
            this._userPositionRelationService = userPositionRelationService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyReports(int page =1)
        {       
            string UID = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.UserId;
            List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => u.AuthorId == UID&& u.ReportType!=99).OrderByDescending(u => u.CreateTime).ToList();
            return View(list.ToPagedList(page,8));
        }
        public ActionResult MyReportsNew()
        {
            return View();
        }
        public ActionResult ProjectReports()
        {
            return View();
        }
        public ActionResult CreateProjectReport()
        {
            ViewBag.ProjectName = Configs.GetValue("ProjectName");
           
            ViewBag.Author = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.RealName;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateProjectReport(FormCollection collection)
        {
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports report = new ENTITY.WeeklyReports.WeeklyReports();
            report.Author = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.RealName;
            report.AuthorId = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.UserId;
            report.CreateTime = DateTime.Now;
            report.Id = Guid.NewGuid().ToString();
           // report.LeaderName = "刘珺";
            report.ProjectName = collection["ProjectName"];
            report.ReportType = 99;          //周报状态

            if (collection["ReportWeekDate"] == "1")
            {
                DateTime timeTemp = DateTime.Now;
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            else
            {
                DateTime timeTemp = DateTime.Now.AddDays(-7);
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            report.WeekCount = WeekOfYear(report.ReportWeekDateEnd, new CultureInfo("zh-CN")).ToString();

            //判断周报是否已经存在了，且不为项目周报
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports reportOld = this._IWeeklyReportsRepository.Get(u => u.WeekCount == report.WeekCount && u.ReportType == 99 && u.AuthorId == report.AuthorId);
            if (reportOld != null)
            {
                return this.Content("<script>alert('本周周报已添加，请勿重复填写！');history.go(-1)</script>");
            }

            int itemCount = Convert.ToInt16(collection["itemCount"]);
            List<string> ContentPartList = new List<string>();
            List<string> CountNameList = new List<string>();
            for (int i = 1; i <= itemCount-2; i++)          //跳过写死的两个       本周任务的标题和值的汇总
            {
                ContentPartList.Add(collection["-ContentPart_"+i.ToString()]);
                CountNameList.Add(collection["-ContentPart_" + i.ToString() + "Name"]);
            }

            List<ReportsData> dataList = new List<ReportsData>();
            ReportsData item;

            for (int j = 1; j <=itemCount - 2; j++)          //跳过写死的两个       本周任务赋值
            {
                item = new ReportsData();
                item.LId = report.Id;
                item.Id = Guid.NewGuid().ToString();
                item.ContentNumber = j.ToString();
                item.ContentType = 1;
                item.Content = ContentPartList[j-1];
                item.StartTime = report.ReportWeekDateBegin;
                item.EndTime = report.ReportWeekDateEnd;
                item.ProjectName = CountNameList[j - 1];
                item.LiablePerson = report.Author;
                dataList.Add(item);
            }
            item = new ReportsData();                           //下周工作计划的特例，加一个就行了
            item.LId = report.Id;
            item.Id = Guid.NewGuid().ToString();
            item.ContentNumber = "1";
            item.ContentType = 2;
            item.Content = collection["-ContentPart_" + itemCount.ToString()];
            item.StartTime = report.ReportWeekDateBegin;
            item.EndTime = report.ReportWeekDateEnd;
          //  item.ProjectName = "汇总";
            item.ProjectName = " 下周工作";
            item.LiablePerson = report.Author;
            dataList.Add(item);

            
            if (this._IWeeklyReportsRepository.InsertWeeklyRepoets(report) && this._IReportsDataRepository.Insert(dataList))
            {
                return this.Content("<script>alert('周报提交成功！');location.href ='/WeeklyReports/WeeklyReports/ProjectReports'</script>");
            }
            else
            {
                return this.Content("<script>alert('添加失败');</script>");
            }
          
           
        }
        public ActionResult PersonReports(string uID ,int page = 1)
        {
            ViewBag.uId = uID;
            //string UID = uID;
            //ViewBag.personID = UID;
            //List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => u.AuthorId == UID&&u.ReportType == 2).OrderByDescending(u => u.CreateTime).ToList();
        //    return View(list.ToPagedList(page, 8));
            return View();
        }
        public ActionResult ReportAudit(int page = 1)
        {
            return View();
        }
        public ActionResult Audit(string lId)
        {
            ViewBag.lId = lId;
            return View();
        }
        [HttpPost]
        public ActionResult Audit(FormCollection collection)
        {
            string lId = collection["lId"];
         //   string auditResult = collection["AuditResult"];
            string auditResult = "true";
            string opinion = collection["Opinion"];
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports model = this._IWeeklyReportsRepository.Get(u => u.Id == lId);
           
            if (auditResult == "true")
            {
                model.ReportType = 2;
            }
            else
            {
                model.ReportType = 3;
            }
            model.LeaderOpinion = opinion;
            model.LeaderName = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.RealName;
            this._IWeeklyReportsRepository.Update(model);
            return this.Content("<script>alert('周报审阅成功！');parent.initGrid();parent.layer.closeAll();</script>");
       //     return View();
        }
        public ActionResult SubordinatesReportList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReportSearch(FormCollection collection)
        {
            string projectName = collection["projectName"];
            string reportDateTemp = collection["reportDate"];
            List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = new List<ENTITY.WeeklyReports.WeeklyReports>();
            if (projectName != "")
            {
                list = this._IWeeklyReportsRepository.GetList(u => u.ProjectName.Contains(projectName));
                if (reportDateTemp != "")
                {
                    DateTime? reportDate = Convert.ToDateTime(collection["reportDate"]);
                    string weekCount = WeekOfYear(Convert.ToDateTime(collection["reportDate"]), new CultureInfo("zh-CN")).ToString();
                    list = list.Where(u => u.WeekCount == weekCount && u.CreateTime.Value.Year == reportDate.Value.Year).ToList();

                }
                return View("MyReports", list.ToPagedList(1,99999));
            }
            if (reportDateTemp != "")
            {
                DateTime? reportDate = Convert.ToDateTime(collection["reportDate"]);
                string weekCount = WeekOfYear(Convert.ToDateTime(collection["reportDate"]), new CultureInfo("zh-CN")).ToString();
                list = this._IWeeklyReportsRepository.GetList(u => u.WeekCount == weekCount);
                list = list.Where(u => u.CreateTime.Value.Year == reportDate.Value.Year).ToList();
                if (projectName != "")
                {
                    list = list.Where(u => u.ProjectName == projectName).ToList();
                }
                return View("MyReports", list.ToPagedList(1, 99999));
            }

            return RedirectToAction("MyReports");

        }
        public  ActionResult ReportInfo(string lId,int isSelf = 1)
        {
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports model = this._IWeeklyReportsRepository.Get(u => u.Id == lId);
            ViewBag.reportType = model.ReportType;
            ViewBag.ProjectName =model.ProjectName;
            ViewBag.WeekCount = model.WeekCount;
            ViewBag.EmergencyLevel = model.EmergencyLevel;
            ViewBag.Author = model.Author;
            ViewBag.lId = lId;
            ViewBag.isSelf = isSelf;
            ViewBag.LeaderName = model.LeaderName;
            ViewBag.LeaderOpinion = model.LeaderOpinion;
           
            List<ReportsData> ListTest = this._IReportsDataRepository.GetList(u => u.LId == lId).OrderBy(u => u.ContentNumber).ToList();
            return View("ReportInfo2", ListTest);

        }
        //public ActionResult ReportInfo(string lId, string ProjectName, string WeekCount, string EmergencyLevel, string Author, int isSelf = 1)
        //{
        //    ViewBag.ProjectName = ProjectName;
        //    ViewBag.WeekCount = WeekCount;
        //    ViewBag.EmergencyLevel = EmergencyLevel;
        //    ViewBag.Author = Author;
        //    ViewBag.lId = lId;
        //    ViewBag.isSelf = isSelf;
        //    KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports model = this._IWeeklyReportsRepository.Get(u => u.Id == lId);
        //    ViewBag.reportType = model.ReportType;
        //    List<ReportsData> ListTest = this._IReportsDataRepository.GetList(u => u.LId == lId).OrderBy(u => u.ContentNumber).ToList();
        //    return View("ReportInfo2",ListTest);
        //}
        public ActionResult ReportEdit(string lId)
        {
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports report = this._IWeeklyReportsRepository.Get(u => u.Id == lId);
            if (report.ReportType !=1 && report.ReportType !=99)              //判断是否已经审阅了。审阅的不能编辑
            {
                return Content("<script>alert('周报已经审阅，不可编辑！');parent.layer.closeAll();</script>");
            }
            List<KALAYUNITSM.ENTITY.WeeklyReports.ReportsData> list = this._IReportsDataRepository.GetList(u => u.LId == lId).OrderBy(u => u.ContentNumber).ToList();
            ViewBag.ProjectName = report.ProjectName;
            ViewBag.ReportType = 1;
            TimeSpan span = DateTime.Now - report.ReportWeekDateBegin;
            if (span.TotalDays > 7)
            {
                ViewBag.ReportWeekDate = "2";
            }
            else
            {
                ViewBag.ReportWeekDate = "1";
            }
            ViewBag.lId = report.Id;
            ViewBag.EmergencyLevel = report.EmergencyLevel;
            ViewBag.Author = report.Author;
        //    return View("ReportEdit2", list);       //天津办公厅的选这个
            return View("ReportEdit3");       //深圳新需求选这个
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ReportEdit(List<ReportsData> ListTest, FormCollection collection)
        {
           
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports report = new ENTITY.WeeklyReports.WeeklyReports();
            report.Author = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.RealName;
            report.AuthorId = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.UserId;
            report.CreateTime = DateTime.Now;
            report.Id = Guid.NewGuid().ToString();
            report.LeaderName = "刘珺";
            report.ProjectName = collection["ProjectName"];
            report.ReportType =1;          //周报状态
           
            if (collection["ReportWeekDate"] == "1")
            {
             //   DateTime timeTemp = DateTime.Now;
                string strTemp = collection["lId"];
                DateTime timeTemp = this._IWeeklyReportsRepository.Get(u => u.Id == strTemp).ReportWeekDateEnd;
             
               
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            else
            {
                string strTemp = collection["lId"];
                DateTime timeTemp =this._IWeeklyReportsRepository.Get(u => u.Id == strTemp).ReportWeekDateEnd.AddDays(-7);
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            report.WeekCount = WeekOfYear(report.ReportWeekDateEnd, new CultureInfo("zh-CN")).ToString();
            report.EmergencyLevel = collection["Level"];
            if (ListTest != null)
            {
                foreach (var item in ListTest)
                {
                    item.LId = report.Id;
                    item.Id = Guid.NewGuid().ToString();
                }
            }
            string lIdTemp = collection["lId"];
            var oldModel = this._IWeeklyReportsRepository.Get(u => u.Id == lIdTemp);
            report.ReportType = oldModel.ReportType;
            var list = this._IReportsDataRepository.GetList(u => u.LId == lIdTemp);
            foreach (var item in list)
            {
                this._IReportsDataRepository.Delete(item);
            }
            this._IWeeklyReportsRepository.Delete(oldModel);
            if (this._IWeeklyReportsRepository.InsertWeeklyRepoets(report) && this._IReportsDataRepository.Insert(ListTest))
            {
                return this.Content("<script>alert('周报提交成功！');location.href ='/WeeklyReports/WeeklyReports/ReportInfo?lId=" + report.Id + "&ProjectName=" + report.ProjectName + "&WeekCount=" + report.WeekCount + "&EmergencyLevel=" + report.EmergencyLevel + "&Author=" + report.Author + "'</script>");

            }
            else
            {
                return this.Content("<script>alert('添加失败');</script>");
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ReportEdit2(FormCollection collection)
        {
            string lId = collection["lId"];
            var report = this._IWeeklyReportsRepository.Get(u => u.Id == lId);
            var list = this._IReportsDataRepository.GetList(u => u.LId == lId);
            foreach (var model in list)
            {
                this._IReportsDataRepository.Delete(model);
            }
            int itemCount = Convert.ToInt16(collection["itemCount"]);
            List<string> ContentPartList = new List<string>();
            List<string> CountNameList = new List<string>();
            for (int i = 1; i <= itemCount - 2; i++)          //跳过写死的两个       本周任务的标题和值的汇总
            {
                ContentPartList.Add(collection["-ContentPart_" + i.ToString()]);
                CountNameList.Add(collection["-ContentPart_" + i.ToString() + "Name"]);
            }

            List<ReportsData> dataList = new List<ReportsData>();
            ReportsData item;

            for (int j = 1; j <= itemCount - 2; j++)          //跳过写死的两个       本周任务赋值
            {
                item = new ReportsData();
                item.LId = report.Id;
                item.Id = Guid.NewGuid().ToString();
                item.ContentNumber = j.ToString();
                item.ContentType = 1;
                item.Content = ContentPartList[j - 1];
                item.StartTime = report.ReportWeekDateBegin;
                item.EndTime = report.ReportWeekDateEnd;
                item.ProjectName = CountNameList[j - 1];
                dataList.Add(item);
            }
            item = new ReportsData();                           //下周工作计划的特例，加一个就行了
            item.LId = report.Id;
            item.Id = Guid.NewGuid().ToString();
            item.ContentNumber = "1";
            item.ContentType = 2;
            item.Content = collection["-ContentPart_" + itemCount.ToString()];
            item.StartTime = report.ReportWeekDateBegin;
            item.EndTime = report.ReportWeekDateEnd;
            item.ProjectName = "汇总";
            dataList.Add(item);


            if (this._IReportsDataRepository.Insert(dataList))
            {
                return this.Content("<script>alert('周报提交成功！');location.href ='/WeeklyReports/WeeklyReports/ReportInfo?lId=" + report.Id + "&ProjectName=" + report.ProjectName + "&WeekCount=" + report.WeekCount + "&EmergencyLevel=" + report.EmergencyLevel + "&Author=" + report.Author + "'</script>");
            }
            else
            {
                return this.Content("<script>alert('添加失败');</script>");
            }


        }
        public ActionResult ReportView(string lId)
        {
            
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports model = this._IWeeklyReportsRepository.Get(u => u.Id == lId);
            List<ReportsData> ListTest = this._IReportsDataRepository.GetList(u => u.LId == lId).OrderBy(u => u.ContentNumber).ToList();
            ReportViewList reList = new ReportViewList();
            reList.reportInfo = model;
            reList.reportDataList = ListTest;
            return View("ReportView2",reList);
        }
        #region 表格导出
        public ActionResult Download()
        {
            Encoding encoding;
            string outputFileName = null;
            string filePath = path;
            string fileName = "QuaterReport.doc";
            fileName = fileName.Replace("'", "");

            string browser = Request.UserAgent.ToUpper();
            if (browser.Contains("MS") == true && browser.Contains("IE") == true)
            {
                outputFileName = HttpUtility.UrlEncode(fileName);
                encoding = Encoding.Default;
            }
            else if (browser.Contains("FIREFOX") == true)
            {
                outputFileName = fileName;
                encoding = Encoding.GetEncoding("GB2312");
            }
            else
            {
                outputFileName = HttpUtility.UrlEncode(fileName);
                encoding = Encoding.Default;
            }
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.Charset = "UTF-8";
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = encoding;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + outputFileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            return new EmptyResult();
        }               //没用了
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DownLoadPost(FormCollection collection)
        {
            string HtmlCode = collection["htmlCodeInput"];
            string tmppath = Server.MapPath("~/Content/周报模板.doc");
            Document doc = new Document(tmppath); //载入模板
            DocumentBuilder builderHtml = new DocumentBuilder(doc);
         //   builderHtml.InsertHtml(HtmlCode);

            if (doc.Range.Bookmarks["ReportCreateTime"] != null && Session["ReportCreateTime"].ToString() != null)
            {
                builderHtml.MoveToBookmark("ReportCreateTime");
                builderHtml.InsertHtml(Session["ReportCreateTime"].ToString());
            
            }
            if (doc.Range.Bookmarks["PersonName"] != null && Session["PersonName"].ToString() != null)
            {

                builderHtml.MoveToBookmark("PersonName");
                builderHtml.InsertHtml(Session["PersonName"].ToString());    
            }
            //if (doc.Range.Bookmarks["ContentPart_1"] != null && Session["ContentPart_1"].ToString() != null)
            //{

            //    builderHtml.MoveToBookmark("ContentPart_1");
            //    builderHtml.InsertHtml(Session["ContentPart_1"].ToString());    
            //}
            //if (doc.Range.Bookmarks["ContentPart_2"] != null && Session["ContentPart_2"].ToString() != null)
            //{
            //    builderHtml.MoveToBookmark("ContentPart_2");
            //    builderHtml.InsertHtml(Session["ContentPart_2"].ToString());    
            //}
            //if (doc.Range.Bookmarks["ContentPart_3"] != null && Session["ContentPart_3"].ToString() != null)
            //{
            //    builderHtml.MoveToBookmark("ContentPart_3");
            //    builderHtml.InsertHtml(Session["ContentPart_3"].ToString());    
            //}
            //if (doc.Range.Bookmarks["ContentPart_4"] != null && Session["ContentPart_4"].ToString() != null)
            //{
            //    builderHtml.MoveToBookmark("ContentPart_4");
            //    builderHtml.InsertHtml(Session["ContentPart_4"].ToString());
            //}
            //if (doc.Range.Bookmarks["ContentPart_5"] != null && Session["ContentPart_5"].ToString() != null)
            //{
            //    builderHtml.MoveToBookmark("ContentPart_5");
            //    builderHtml.InsertHtml(Session["ContentPart_5"].ToString());
            //}
            //if (doc.Range.Bookmarks["ContentPart_6"] != null && Session["ContentPart_6"].ToString() != null)
            //{
            //    builderHtml.MoveToBookmark("ContentPart_6");
            //    builderHtml.InsertHtml(Session["ContentPart_6"].ToString());
            //}
            //if (doc.Range.Bookmarks["ContentPart_7"] != null && Session["ContentPart_7"].ToString() != null)
            //{
            //    builderHtml.MoveToBookmark("ContentPart_7");
            //    builderHtml.InsertHtml(Session["ContentPart_7"].ToString());
            //}
            builderHtml.MoveToBookmark("ContentPart");
            
            string lId = collection["lId"];
            List<KALAYUNITSM.ENTITY.WeeklyReports.ReportsData> list = this._IReportsDataRepository.GetList(u => u.LId == lId).OrderBy(u => u.ContentNumber).ToList();
            var thisWeekReport = list.Where(u => u.ContentType == 1).OrderBy(u => u.ContentNumber).ToList();
            int totalCount = 0;
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true); //拿到所有表格
        //    Aspose.Words.Tables.Table table = allTables[0] as Aspose.Words.Tables.Table; //拿到第二个表格
            Aspose.Words.Tables.Table table = builderHtml.StartTable();
            #region 本周工作内容部分
            for (int i = 0; i <= thisWeekReport.Count; i++)
            {

                totalCount = i;
                var row = CreateRow(1, (new string[] {  }), doc); //创建一行
                table.Rows.Add(row);
                var row1 = CreateRow(1, (new string[] { }), doc); //创建一行
                table.Rows.Add(row1);
                if (i==0)
                {
                    builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow), 0, 0);

                    //   builderHtml.MoveToParagraph(table.LastRow.LastCell.LastParagraph,0);
                    //  builderHtml.InsertHtml(thisWeekReport[i].Content);
                    builderHtml.Write(" ");
                }
                else
                {
                    thisWeekReport[i-1].Content = thisWeekReport[i-1].Content.Insert(0, "<div  style=\"font-size: 10.5pt;font-family:'宋体';\">");
                    thisWeekReport[i-1].Content = thisWeekReport[i-1].Content.Insert(thisWeekReport[i-1].Content.Length, "</div>");
                 
                    builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow), 0, 0);
                    builderHtml.InsertHtml(thisWeekReport[i - 1].Content);

                    builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow)-1, 0, 0);
                    builderHtml.Font.Bold = true;//标题加粗
                    builderHtml.Write(NumberToChinese(i)+"、"+ thisWeekReport[i - 1].ProjectName);
                    //   builderHtml.MoveToParagraph(table.LastRow.LastCell.LastParagraph,0);                 

                }       
            }

            table.Rows.Remove(table.FirstRow);//删除这个插件打印第一次会漏出表格外的字段，以空字符串“”来写的两行，属于插件BUG
            table.Rows.Remove(table.FirstRow);//删除这个插件打印第一次会漏出表格外的字段，以空字符串“”来写的两行，属于插件BUG

            #endregion
            #region 中间未定义部分
            totalCount++;
            var row3 = CreateRow(1, (new string[] { }), doc); //创建一行
            table.Rows.Add(row3);
            var row4 = CreateRow(1, (new string[] { }), doc); //创建一行
            table.Rows.Add(row4);

            //builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow), 0, 0);
            //builderHtml.Write("无");

            //builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow) - 1, 0, 0);
            //builderHtml.Font.Bold = true;//标题加粗
            //builderHtml.Write(NumberToChinese(totalCount) + "、用户投诉与处理" );

            //totalCount++;
            // row3 = CreateRow(1, (new string[] { }), doc); //创建一行
            //table.Rows.Add(row3);
            // row4 = CreateRow(1, (new string[] { }), doc); //创建一行
            //table.Rows.Add(row4);

            builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow), 0, 0);
            builderHtml.Write("未添加");

            builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow) - 1, 0, 0);
            builderHtml.Font.Bold = true;//标题加粗
            builderHtml.Write(NumberToChinese(totalCount) + "、服务级别协议达成情况");
            #endregion
            #region 下周工作部分
            totalCount++;
            row3 = CreateRow(1, (new string[] { }), doc); //创建一行
            table.Rows.Add(row3);
            row4 = CreateRow(1, (new string[] { }), doc); //创建一行
            table.Rows.Add(row4);

            builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow), 0, 0);




            string contentHtml_All = "";

            var nextWeekReport = list.Where(u => u.ContentType == 2).OrderBy(u => u.ContentNumber).ToList();
            if (nextWeekReport != null && nextWeekReport.Count > 0)
            {

                List<NextWeekTitle> projectNameTypeList = nextWeekReport.Select(u => new NextWeekTitle { RowName = u.ProjectName }).Distinct().ToList();
       
                Dictionary<string, string> contentList = new Dictionary<string, string>();
                foreach (var item in nextWeekReport)
                {
                    foreach (var model in projectNameTypeList)
                    {
                        if (item.ContentType==2 && item.ProjectName == model.RowName)
                        {                         
                        item.Content = item.Content.Insert(0, "<div  style=\"font-size: 10.5pt;font-family:'宋体';\">");
                        item.Content = item.Content.Insert(item.Content.Length, "</div>");
                        contentList.Add(model.RowName, item.Content);

                        }
                    }
                }              
                int i = 1;
                for (int j = 0; j < projectNameTypeList.Count; j++)
                {
                     if (contentList[projectNameTypeList[j].RowName] != null)
                    {
                        contentHtml_All += "<span>" + i.ToString() + "、" + projectNameTypeList[j].RowName + "</span>";
                        contentHtml_All += contentList[projectNameTypeList[j].RowName];
                        contentHtml_All += "<br />";
                        i++;
                    }
                }
                //这个是防止html导出字体奇形怪状的根开头结尾都加一个宋体的DIV
                contentHtml_All = contentHtml_All.Insert(0, "<div  style=\"font-size: 10.5pt;font-family:'宋体';\">");
                contentHtml_All = contentHtml_All.Insert(contentHtml_All.Length, "</div>");    
            }
            builderHtml.InsertHtml(contentHtml_All);
            builderHtml.MoveToCell(0, table.Rows.IndexOf(table.LastRow) - 1, 0, 0);
            builderHtml.Font.Bold = true;//标题加粗
            builderHtml.Write(NumberToChinese(totalCount) + "、下周工作计划");
            #endregion





            path = Server.MapPath("~/App_Data/我的周报.doc");
            //  doc.Save("用户周报.doc", SaveFormat.Doc);
            doc.Save(path, Aspose.Words.SaveFormat.Doc);


            Encoding encoding;
            string outputFileName = null;
            string filePath = path;
            string fileName = "我的周报.doc";
            fileName = fileName.Replace("'", "");
            string browser = Request.UserAgent.ToUpper();
            if (browser.Contains("MS") == true && browser.Contains("IE") == true)
            {
                outputFileName = HttpUtility.UrlEncode(fileName);
                encoding = Encoding.Default;
            }
            else if (browser.Contains("FIREFOX") == true)
            {
                outputFileName = fileName;
                encoding = Encoding.GetEncoding("GB2312");
            }
            else
            {
                outputFileName = HttpUtility.UrlEncode(fileName);
                encoding = Encoding.Default;
            }
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.Charset = "UTF-8";
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = encoding;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + outputFileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            return new EmptyResult();
        }
        Aspose.Words.Tables.Cell CreateCell(string value, Document doc)
        {
            Aspose.Words.Tables.Cell c1 = new Aspose.Words.Tables.Cell(doc);
            Aspose.Words.Paragraph p = new Paragraph(doc);
         
            p.AppendChild(new Run(doc, value));
            c1.AppendChild(p);
            return c1;
        }


        Aspose.Words.Tables.Row CreateRow(int columnCount, string[] columnValues, Document doc)
        {
            Aspose.Words.Tables.Row r2 = new Aspose.Words.Tables.Row(doc);
            for (int i = 0; i < columnCount; i++)
            {
                if (columnValues.Length > i)
                {
                    var cell = CreateCell(columnValues[i], doc);
                    r2.Cells.Add(cell);
                }
                else
                {
                    var cell = CreateCell("", doc);
                    r2.Cells.Add(cell);
                }

            }
            return r2;
        }
        public string docStringExportCheck(string htmlCode)
        {
            string strResult = htmlCode;
           
            string temp = "";

            return strResult;
        }
        private void DownFile(string filePath, string fileName)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = systemPrimordial.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }
        #endregion
        public ActionResult ReportDelete(string lId)
        {

            var list = this._IReportsDataRepository.GetList(u => u.LId == lId);
            foreach (var item in list)
            {
                this._IReportsDataRepository.Delete(item);
            }
            this._IWeeklyReportsRepository.Delete(this._IWeeklyReportsRepository.Get(u => u.Id == lId));
            return this.Content("<script>alert('周报删除成功！');location.href ='/WeeklyReports/WeeklyReports/MyReportsNew'</script>");
        }
        public ActionResult CreateReport()
        {
            ViewBag.ProjectName = Configs.GetValue("ProjectName");
            ViewBag.Author = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.RealName;
//            return View();
          //  return View("CreateReport2");   //天津办公厅项目
            return View("CreateReport3");       //深圳项目
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateReport(List<ReportsData> ListTest, FormCollection collection)
        {
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports report = new ENTITY.WeeklyReports.WeeklyReports();
            report.Author = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.RealName;
            report.AuthorId = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.UserId;
            report.CreateTime = DateTime.Now;
            report.Id = Guid.NewGuid().ToString();
            report.LeaderName = "";
            report.ProjectName = collection["ProjectName"];
            report.ReportType = 1;          //周报状态

            if (collection["ReportWeekDate"] == "1")
            {
                DateTime timeTemp = DateTime.Now;
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            else
            {
                DateTime timeTemp = DateTime.Now.AddDays(-7);
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            report.WeekCount = WeekOfYear(report.ReportWeekDateEnd, new CultureInfo("zh-CN")).ToString();

            //判断周报是否已经存在了，且不为项目周报
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports reportOld = this._IWeeklyReportsRepository.Get(u => u.WeekCount == report.WeekCount && u.ReportType!=99 && u.AuthorId == report.AuthorId);
            if (reportOld!=null)
            {
                return this.Content("<script>alert('本周周报已添加，请勿重复填写！');history.go(-1)</script>");
            }
            //  report.EmergencyLevel = collection["Level"];
            if (ListTest != null)
            {
                foreach (var item in ListTest)
                {
                    item.LId = report.Id;
                    item.Id = Guid.NewGuid().ToString();
                }
            }
            if (this._IWeeklyReportsRepository.InsertWeeklyRepoets(report) && this._IReportsDataRepository.Insert(ListTest))
            {
                return this.Content("<script>alert('周报提交成功！');location.href ='/WeeklyReports/WeeklyReports/MyReportsNew'</script>");
            }
            else
            {
                return this.Content("<script>alert('添加失败');</script>");
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateReportNew(List<ReportsData> ListTest, FormCollection collection)
        {
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports report = new ENTITY.WeeklyReports.WeeklyReports();
            report.Author = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.RealName;
            report.AuthorId = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.UserId;
            report.CreateTime = DateTime.Now;
            report.Id = Guid.NewGuid().ToString();
            // report.LeaderName = "刘珺";
            report.ProjectName = collection["ProjectName"];
            report.ReportType = 1;          //周报状态

            if (collection["ReportWeekDate"] == "1")
            {
                DateTime timeTemp = DateTime.Now;
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            else
            {
                DateTime timeTemp = DateTime.Now.AddDays(-7);
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                report.ReportWeekDateEnd = timeTemp;
                report.ReportWeekDateBegin = report.ReportWeekDateEnd.AddDays(-4);
            }
            report.WeekCount = WeekOfYear(report.ReportWeekDateEnd, new CultureInfo("zh-CN")).ToString();

            //判断周报是否已经存在了，且不为项目周报
            KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports reportOld = this._IWeeklyReportsRepository.Get(u => u.WeekCount == report.WeekCount && u.ReportType != 99 && u.AuthorId == report.AuthorId);
            if (reportOld != null)
            {
                return this.Content("<script>alert('本周周报已添加，请勿重复填写！');history.go(-1)</script>");
            }

            int itemCount = Convert.ToInt16(collection["itemCount"]);
            List<string> ContentPartList = new List<string>();
            List<string> CountNameList = new List<string>();
            for (int i = 1; i <= itemCount - 2; i++)          //跳过写死的两个       本周任务的标题和值的汇总
            {
                ContentPartList.Add(collection["-ContentPart_" + i.ToString()]);
                CountNameList.Add(collection["-ContentPart_" + i.ToString() + "Name"]);
            }

            List<ReportsData> dataList = new List<ReportsData>();
            ReportsData item;

            for (int j = 1; j <= itemCount - 2; j++)          //跳过写死的两个       本周任务赋值
            {
                item = new ReportsData();
                item.LId = report.Id;
                item.Id = Guid.NewGuid().ToString();
                item.ContentNumber = j.ToString();
                item.ContentType = 1;
                item.Content = ContentPartList[j - 1];
                item.StartTime = report.ReportWeekDateBegin;
                item.EndTime = report.ReportWeekDateEnd;
                item.ProjectName = CountNameList[j - 1];
                item.LiablePerson = report.Author;
                dataList.Add(item);
            }
            item = new ReportsData();                           //下周工作计划的特例，加一个就行了
            item.LId = report.Id;
            item.Id = Guid.NewGuid().ToString();
            item.ContentNumber = "1";
            item.ContentType = 2;
            item.Content = collection["-ContentPart_" + itemCount.ToString()];
            item.StartTime = report.ReportWeekDateBegin;
            item.EndTime = report.ReportWeekDateEnd;
            item.ProjectName = "下周工作";
            item.LiablePerson = report.Author;
            dataList.Add(item);


            if (this._IWeeklyReportsRepository.InsertWeeklyRepoets(report) && this._IReportsDataRepository.Insert(dataList))
            {
                return this.Content("<script>alert('周报提交成功！');location.href ='/WeeklyReports/WeeklyReports/MyReportsNew'</script>");
            }
            else
            {
                return this.Content("<script>alert('添加失败');</script>");
            }
          
           
        }


        public static int WeekOfYear(DateTime dt, CultureInfo ci)
        {
            return ci.Calendar.GetWeekOfYear(dt, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
        }
        #region 岗位管理
        #region 数据层
        public List<ZTreeNode> GetListTreeByPositionID()
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
            return result;
        }
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
            //var pageData = _positionService.GetPageList(curr, nums, out count, keyWord, parentId);
            //var result = new LayUI<Sys_Position_Dto>()
            //{
            //    result = true,
            //    msg = "success",
            //    data = pageData,
            //    count = count
            //};
            var pageData = _positionService.GetUserByPosition(curr, nums, out count,parentId);
            var result = new LayUI<Sys_User_Dto>()
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

        #endregion
        #endregion
        #region 周报审核
        public ActionResult GetJsonDataAudit(int curr, int nums, string keyWord)
        {
            int count;        
            string PositionID = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.PositionId;
            List<string>cidList= new List<string>();
            this._positionService.GetList(u => u.ParentId == PositionID).ForEach(a => cidList.Add(a.Id));
            List<string> pRUserList=new List<string>();
            this._userPositionRelationService.GetList(u => cidList.Contains(u.PositionId)).ForEach(a => pRUserList.Add(a.UserId));       
            var tempList = this._userService.GetList(u => pRUserList.Contains(u.Id));
            List<string> personList = new List<string>();
            foreach (var item in tempList)
            {
                personList.Add(item.Id);
            }
            List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => personList.Contains(u.AuthorId) && u.ReportType == 1).OrderByDescending(u => u.CreateTime).ToList();
            count = list.Count;
            list = list.Skip((curr - 1) * nums).Take(nums).ToList();

            var result = new LayUI<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports>()
            {
                result = true,
                msg = "success",
                data = list,
                count = count
            };
            return Content(result.ToJson());
        }

    
        public ActionResult GetPersonsReportsJsonData(int curr, int nums, string keyWord)
        {
            int count;        
            string UID = keyWord;
           // ViewBag.personID = UID;
            List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => u.AuthorId == UID && u.ReportType == 2).OrderByDescending(u => u.CreateTime).ToList();
            count = list.Count;
            list = list.Skip((curr - 1) * nums).Take(nums).ToList();

            var result = new LayUI<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports>()
            {
                result = true,
                msg = "success",
                data = list,
                count = count
            };
            return Content(result.ToJson());
        }
        #endregion
        #region 我的周报
        public ActionResult GetMyReportEditData(string projectName, string projectDataName, string weekCount,string lId)
        {
            string dataResult = "";
            if (projectDataName == "下周工作")
            {
                var model = this._IReportsDataRepository.Get(u => u.LId == lId&&u.ContentType == 2);
                if (model!=null)
	            {
                    dataResult = model.Content;
	            }
            }
            else
            {
                var model = this._IReportsDataRepository.Get(u => u.LId == lId && u.ProjectName == projectDataName);
                if (model != null)
                {
                    dataResult = model.Content;
                }
            }     
            return Content(dataResult);
        }
        /// <summary>
        /// 深圳需求：将工单模块的数据导入到周保中
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="projectDataName"></param>
        /// <param name="weekCount"></param>
        /// <returns></returns>
        public ActionResult GetMyOrderJsonData(string projectName, string projectDataName, string weekCount)
        {
            #region 计算周数 1是本周 2是上周
            DateTime ReportWeekDateEnd;
            DateTime ReportWeekDateBegin;
            if (weekCount == "1")
            {
                DateTime timeTemp = DateTime.Now;
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                ReportWeekDateEnd = timeTemp;
                ReportWeekDateBegin = ReportWeekDateEnd.AddDays(-4);
            }
            else
            {
                DateTime timeTemp = DateTime.Now.AddDays(-7);
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                ReportWeekDateEnd = timeTemp;
                ReportWeekDateBegin = ReportWeekDateEnd.AddDays(-4);
            }
            #endregion
          
           int count = 0;
        //   var pageData = _ordersService.GetPageList(1, 65534, out count, "").Where(t => t.CurrUser == OperatorProvider.Instance.Current.Account && t.CreateTime >= Convert.ToDateTime(ReportWeekDateBegin.ToShortDateString()) && t.CreateTime <= Convert.ToDateTime(ReportWeekDateEnd.ToShortDateString())).ToList();
           DateTime beginShort = Convert.ToDateTime(ReportWeekDateBegin.ToShortDateString());
           DateTime endShort = Convert.ToDateTime(ReportWeekDateEnd.ToShortDateString());
           endShort = endShort.AddDays(1).AddSeconds(-1);
           string dataResult = "";
           if (projectDataName == "工单工作")
           {
               var pageData = _ordersService.GetPageList(1, 65534, out count, "").Where(t => t.CreateTime >= beginShort && t.CreateTime <= endShort).ToList();
               foreach (var item in pageData)
               {

                   //    var model = _ordersService.GetOrder(item.OrderId);
                   dataResult += "\r<h6 >联系人：" + item.ContactsName + "\r\n\n\n创建时间：" + String.Format("{0:f}", item.CreateTime) + "</h6>";
                   dataResult += item.Description;
                   //List<ReportsData> ListTest = this._IReportsDataRepository.GetList(u => u.LId == item.Id && u.ProjectName == projectDataName && u.ContentType == 1).OrderBy(u => u.ContentNumber).ToList();
                   //foreach (var model in ListTest)
                   //{
                   //    dataResult += model.Content;
                   //}
               }
           }
           if (projectDataName == "巡检工作")
           {
               var pageData = _ordersService.GetPageList(1, 65534, out count, "").Where(t => t.CreateTime >= beginShort && t.CreateTime <= endShort).ToList();
               foreach (var item in pageData)
               {

                   //    var model = _ordersService.GetOrder(item.OrderId);
                   dataResult += "\r<h6 >联系人：" + item.ContactsName + "\r\n\n\n创建时间：" + String.Format("{0:f}", item.CreateTime) + "</h6>";
                   dataResult += item.Description;
                   //List<ReportsData> ListTest = this._IReportsDataRepository.GetList(u => u.LId == item.Id && u.ProjectName == projectDataName && u.ContentType == 1).OrderBy(u => u.ContentNumber).ToList();
                   //foreach (var model in ListTest)
                   //{
                   //    dataResult += model.Content;
                   //}
               }
           }
            return Content(dataResult);
            //string WeekCount = WeekOfYear(ReportWeekDateEnd, new CultureInfo("zh-CN")).ToString();

            //string PositionID = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.PositionId;
            //List<string> cidList = new List<string>();
            ////    this._positionService.GetList(u => u.ParentId == PositionID).ForEach(a => cidList.Add(a.Id));   //获取父岗位ID是该ID的人 就是下一层员工的ID
            //var cList = GetListTreeByPositionID();//获取父岗位ID下所有的岗位名
            //foreach (var item in cList)
            //{
            //    cidList.Add(item.id);
            //}
            //List<string> pRUserList = new List<string>();
            //this._userPositionRelationService.GetList(u => cidList.Contains(u.PositionId)).ForEach(a => pRUserList.Add(a.UserId));//获取子层岗位的所有人

            //var tempList = this._userService.GetList(u => pRUserList.Contains(u.Id));
            //List<string> personList = new List<string>();
            //foreach (var item in tempList)
            //{
            //    personList.Add(item.Id);
            //}
            //List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => personList.Contains(u.AuthorId) && u.ReportType == 2 && u.WeekCount == WeekCount).OrderByDescending(u => u.CreateTime).ToList();
            //string dataResult = "";
            //foreach (var item in list)
            //{
            //    dataResult += "\r<h6 >作者：" + item.Author + "\r内容：</h6>";

            //    List<ReportsData> ListTest = this._IReportsDataRepository.GetList(u => u.LId == item.Id && u.ProjectName == projectDataName && u.ContentType == 1).OrderBy(u => u.ContentNumber).ToList();
            //    foreach (var model in ListTest)
            //    {
            //        dataResult += model.Content;
            //    }
            //}
          //  return Content(dataResult);
          
        }
        public ActionResult GetMyReportsJsonData(int curr, int nums, string keyWord)
        {
            int count;
            string UID = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.UserId;
            List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => u.AuthorId == UID && u.ReportType != 99).OrderByDescending(u => u.CreateTime).ToList();
            count = list.Count;
            list = list.Skip((curr - 1) * nums).Take(nums).ToList();
            var result = new LayUI<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports>()
            {
                result = true,
                msg = "success",
                data = list,
                count = count
            };
            return Content(result.ToJson());
        }
        #endregion
        #region 项目周报
        public ActionResult GetProjectReportData(string projectName, string projectDataName, string weekCount)
        {
            #region 计算周数 1是本周 2是上周
            DateTime ReportWeekDateEnd;
            DateTime ReportWeekDateBegin;
            if (weekCount == "1")
            {
                DateTime timeTemp = DateTime.Now;
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                ReportWeekDateEnd = timeTemp;
                ReportWeekDateBegin = ReportWeekDateEnd.AddDays(-4);
            }
            else
            {
                DateTime timeTemp = DateTime.Now.AddDays(-7);
                for (int i = 0; i < 7; i++)
                {
                    if (timeTemp.DayOfWeek == DayOfWeek.Friday)
                    {
                        break;
                    }
                    if (timeTemp.DayOfWeek > DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(-1);
                    }
                    if (timeTemp.DayOfWeek < DayOfWeek.Friday)
                    {
                        timeTemp = timeTemp.AddDays(1);
                    }
                }
                ReportWeekDateEnd = timeTemp;
                ReportWeekDateBegin = ReportWeekDateEnd.AddDays(-4);
            }
            #endregion
            string WeekCount = WeekOfYear(ReportWeekDateEnd, new CultureInfo("zh-CN")).ToString();

            string PositionID = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.PositionId;
            List<string> cidList = new List<string>();
            //    this._positionService.GetList(u => u.ParentId == PositionID).ForEach(a => cidList.Add(a.Id));   //获取父岗位ID是该ID的人 就是下一层员工的ID
            var cList = GetListTreeByPositionID();//获取父岗位ID下所有的岗位名
            foreach (var item in cList)
            {
                cidList.Add(item.id);
            }
            List<string> pRUserList = new List<string>();
            this._userPositionRelationService.GetList(u => cidList.Contains(u.PositionId)).ForEach(a => pRUserList.Add(a.UserId));//获取子层岗位的所有人

            var tempList = this._userService.GetList(u => pRUserList.Contains(u.Id));
            List<string> personList = new List<string>();
            foreach (var item in tempList)
            {
                personList.Add(item.Id);
            }
            List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => personList.Contains(u.AuthorId) && u.ReportType == 2 && u.WeekCount == WeekCount).OrderByDescending(u => u.CreateTime).ToList();
            string dataResult = "";
            foreach (var item in list)
            {
                dataResult += "\r<h6 >作者：" + item.Author + "\r内容：</h6>";

                List<ReportsData> ListTest = this._IReportsDataRepository.GetList(u => u.LId == item.Id && u.ProjectName == projectDataName && u.ContentType == 1).OrderBy(u => u.ContentNumber).ToList();
                foreach (var model in ListTest)
                {
                    dataResult += model.Content;
                }
            }
            return Content(dataResult);
        }
        public ActionResult GetJsonProjectData(int curr, int nums, string keyWord)
        {
            int count;        
            string UID = KALAYUNITSM.COMMON.OperatorProvider.Instance.Current.UserId;
            List<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports> list = this._IWeeklyReportsRepository.GetList(u => u.AuthorId == UID && u.ReportType == 99).OrderByDescending(u => u.CreateTime).ToList();
            count = list.Count;
            list = list.Skip((curr - 1) * nums).Take(nums).ToList();
            var result = new LayUI<KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports>()
            {
                result = true,
                msg = "success",
                data = list,
                count = count
            };
            return Content(result.ToJson());
        }
        #endregion
        /// <summary>
        /// 获取配置的选择框
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSelectList()
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath =Server.MapPath("~/Configs/")+"ProjectItemConfig.xml";
            doc.Load(xmlPath);
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            return Content(jsonText);
        }
        /// <summary>
        /// 数字转中文
        /// </summary>
        /// <param name="number">eg: 22</param>
        /// <returns></returns>
        public string NumberToChinese(int number)
        {
            string res = string.Empty;
            string str = number.ToString();
            string schar = str.Substring(0, 1);
            switch (schar)
            {
                case "1":
                    res = "一";
                    break;
                case "2":
                    res = "二";
                    break;
                case "3":
                    res = "三";
                    break;
                case "4":
                    res = "四";
                    break;
                case "5":
                    res = "五";
                    break;
                case "6":
                    res = "六";
                    break;
                case "7":
                    res = "七";
                    break;
                case "8":
                    res = "八";
                    break;
                case "9":
                    res = "九";
                    break;
                default:
                    res = "零";
                    break;
            }
            if (str.Length > 1)
            {
                switch (str.Length)
                {
                    case 2:
                    case 6:
                        res += "十";
                        break;
                    case 3:
                    case 7:
                        res += "百";
                        break;
                    case 4:
                        res += "千";
                        break;
                    case 5:
                        res += "万";
                        break;
                    default:
                        res += "";
                        break;
                }
                res += NumberToChinese(int.Parse(str.Substring(1, str.Length - 1)));
            }
            return res;
        }

    }
    public class ReportViewList
    {
       public KALAYUNITSM.ENTITY.WeeklyReports.WeeklyReports reportInfo { get; set; }
       public  List<ReportsData> reportDataList { get; set; }
    }
    public class NextWeekTitle{
        public string RowName { get; set; }
        
    }
   
}
