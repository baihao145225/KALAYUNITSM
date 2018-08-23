using System;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Commerce_Contract : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public string Type { get; set; }
        public decimal Expenses { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; } 
        public bool? IsEnable { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }

    }
}
