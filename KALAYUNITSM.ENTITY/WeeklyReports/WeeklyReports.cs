using KALAYUNITSM.DATA;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.ENTITY.WeeklyReports
{
    public class WeeklyReports : ITEntity
    {
        public WeeklyReports()
        {
            this.CreateTime = DateTime.Now;
        }
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        public string ProjectName { get; set; }     //项目名称
        public DateTime ReportWeekDateBegin { get; set; }        //周报提交日期的周一
        public DateTime ReportWeekDateEnd { get; set; }        //周报提交日期的周五

        public string WeekCount { get; set; }   //第XX周

        public int ReportType { get; set; }     //周报状态

        public string LeaderName { get; set; }      //领导名称

        public string LeaderOpinion { get; set; }   //领导意见

        public string Author { get; set; }      //作者

        public string AuthorId { get; set; }    //作者ID
        public string EmergencyLevel { get; set; }          //紧急度
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }


    }
}
