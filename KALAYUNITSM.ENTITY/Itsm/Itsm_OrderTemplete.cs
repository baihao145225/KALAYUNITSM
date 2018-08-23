using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Itsm_OrderTemplete : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; } 
        public string Name { get; set; }
        public EffectLevelEnums EffectId { get; set; }
        public UrgencyLevelEnums UrgencyId { get; set; } 
        public string Description { get; set; } 
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; } 
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
