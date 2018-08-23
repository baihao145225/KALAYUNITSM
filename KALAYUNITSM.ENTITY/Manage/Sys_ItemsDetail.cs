﻿using System;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_ItemsDetail : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; } 
        public string ItemId { get; set; } 
        public string EnCode { get; set; } 
        public string Name { get; set; } 
        public bool? IsDefault { get; set; }   
        public bool? IsEnable { get; set; } 
        public string CreateUser { get; set; } 
        public DateTime? CreateTime { get; set; }  
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
