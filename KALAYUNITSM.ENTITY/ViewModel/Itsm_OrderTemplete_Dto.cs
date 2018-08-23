using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Itsm_OrderTemplete_Dto
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string EffectName { get; set; }
        public string UrgencyName { get; set; }  
        public string Description { get; set; } 
        public string CreateUser { get; set; }
        public bool? IsEnable { get; set; }
        public DateTime? CreateTime { get; set; } 
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
