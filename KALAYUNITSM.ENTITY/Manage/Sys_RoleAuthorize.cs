using System;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_RoleAuthorize : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string ModuleId { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
