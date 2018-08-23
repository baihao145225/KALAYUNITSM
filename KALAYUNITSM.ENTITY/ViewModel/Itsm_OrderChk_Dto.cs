using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Itsm_OrderChk_Dto
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string OrderChkStatusTitle { get; set; }
        public OrdersStatusEnums OrderChkStatus { get; set; }
        public string CurrUser { get; set; }
        public string NextUser { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public string Reason { get; set; }
        public DateTime? FinishedTime { get; set; }
        public bool? IsEnable { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUser { get; set; }
    }
}
