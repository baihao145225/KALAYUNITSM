using KALAYUNITSM.DATA;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.ENTITY.WeeklyReports
{
    public class ReportsData : ITEntity

    {
        public ReportsData()
        {
            this.CreateTime = DateTime.Now;
        }
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }
        public string LId { get; set; }     //周报父ID
        public string ProjectName { get; set; } //工作项目名称

        // ↓本周工作任务（或独有内容）
        public string ContentNumber { get; set; }   //内容序号
        public string Content { get; set; }  //工作内容
        public int ContentType { get; set; } //周报内容类型
        public string LiablePerson { get; set; } //责任人
        public DateTime? StartTime { get; set; } //开始时间
        public DateTime? EndTime { get; set; }  //结束时间 
        public string CompleteStatus { get; set; } //完成情况
        public string WorkType { get; set; }       //工作状态

        //↓下周工作计划（或独有内容）
        public string Remark { get; set; }      //备注

        //↓发现问题（独有）
        public string Problem { get; set; }  //问题
        public string Result { get; set; }  //原因
        public string Solution { get; set; }    //解决方案
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }



    }
}
