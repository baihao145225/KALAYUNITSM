using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_CIRelations_Dto : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string CIPName { get; set; }
        public string CINName { get; set; }
        public string RelationName { get; set; }
        public string Description { get; set; }
        public bool? IsReverse { get; set; }
        public bool? IsEnable { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
