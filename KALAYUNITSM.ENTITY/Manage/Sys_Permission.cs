using System;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_Permission : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string ParentId { get; set; }
        public int? Layer { get; set; }
        public string EnCode { get; set; }
        public string Name { get; set; }
        public string JsEvent { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsEnable { get; set; }
        public bool? IsEdit { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
        public int ButtonStatus { get; set; }

    }
}
