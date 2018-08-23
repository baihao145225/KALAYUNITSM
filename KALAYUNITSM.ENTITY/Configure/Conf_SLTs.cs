using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_SLTs : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string Name { get; set; }
        public EffectLevelEnums EffectLevel { get; set; }
        public UrgencyLevelEnums UrgencyLevel { get; set; }
        public int ResponseDuration { get; set; }
        public int FinishDuration { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
