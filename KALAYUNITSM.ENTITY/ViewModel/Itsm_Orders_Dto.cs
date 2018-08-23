using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Itsm_Orders_Dto
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string ContractName { get; set; }
        public string ContactsName { get; set; }
        public string CIName { get; set; }
        public EffectLevelEnums EffectId { get; set; }
        public UrgencyLevelEnums UrgencyId { get; set; } 
        public string PriorityName { get; set; }
        public string Description { get; set; }
        public string AttachmentFile { get; set; }
        public string Solution { get; set; }
        public string SlaTitle { get; set; }
        public DateTime? RegisterTime { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime? ActualResponseTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public OrdersStatusEnums StatusCode { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string CurrUser { get; set; }
        public string CurrUserName { get; set; }
        public string CreateUser { get; set; }
        public bool? IsEnable { get; set; }
        public DateTime? CreateTime { get; set; } 
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
