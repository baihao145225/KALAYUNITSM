using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_CIGroup_Dto
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string EnCode { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
        public bool? IsEnable { get; set; }
        public int ChkState { get; set; }
    }
}
