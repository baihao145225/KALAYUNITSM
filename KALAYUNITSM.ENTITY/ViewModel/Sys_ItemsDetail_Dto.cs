using System;
using System.Collections.Generic;
using System.Linq;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_ItemsDetail_Dto
    {
        public string Id { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string EnCode { get; set; }
        public string Name { get; set; } 
        public bool? IsEnable { get; set; } 
        public int? SortCode { get; set; } 
    }
}
