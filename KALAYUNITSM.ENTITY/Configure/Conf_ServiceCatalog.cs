﻿using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_ServiceCatalog : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string EnCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Delivery { get; set; }
        public string Level { get; set; }
        public string Frequency { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
