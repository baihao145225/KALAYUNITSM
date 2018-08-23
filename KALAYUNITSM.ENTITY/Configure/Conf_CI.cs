using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_CI : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }   
        public string CIGroupId { get; set; }
        public string LocaltionId { get; set; } 
        public string ContactsId { get; set; }
        public string Field0 { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public string Field11 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
