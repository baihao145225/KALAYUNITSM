using System;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY 
{
    public class Sys_Log : ITEntity
    {

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string LogLevel { get; set; }
        public string Operation { get; set; }
        public string Message { get; set; }
        public string Account { get; set; }
        public string RealName { get; set; }
        public string IP { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string StackTrace { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
