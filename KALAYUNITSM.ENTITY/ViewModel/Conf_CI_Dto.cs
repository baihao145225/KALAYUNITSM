using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_CI_Dto
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string UsingCustomerName { get; set; }       
        public string CIGroupName { get; set; }
        public string LocaltionName { get; set; }
        public string UsingContactsName { get; set; } 
        public string Status { get; set; }
        public string Description { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
