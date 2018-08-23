using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Itsm_Orders : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string OrderForm { get; set; }
        public string CustomerId { get; set; }
        public string ContractId { get; set; }
        public string ContactsId { get; set; }
        public string CIId { get; set; }
        public EffectLevelEnums EffectId { get; set; }
        public UrgencyLevelEnums UrgencyId { get; set; }
        public string PriorityId { get; set; }
        public string Description { get; set; }
        public string AttachmentFile { get; set; }
        public DateTime RegisterTime { get; set; }
        public DateTime ResponseTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime? ActualResponseTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public OrdersStatusEnums StatusCode { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public string CurrUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
