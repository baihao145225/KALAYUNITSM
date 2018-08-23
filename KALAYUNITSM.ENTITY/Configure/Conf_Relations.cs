using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_Relations : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; } 
        public string Name { get; set; }
        public string ForwardText { get; set; }
        public string ReverseText { get; set; } 
        public string Description { get; set; }
        public bool? IsEnable { get; set; } 
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
