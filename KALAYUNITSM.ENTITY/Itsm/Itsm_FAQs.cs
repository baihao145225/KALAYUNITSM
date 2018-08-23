using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Itsm_FAQs : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string EnCode { get; set; }
        public string CategoryId { get; set; }
        public string KeyWords { get; set; }
        public string ServiceCatalogId { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Hits { get; set; }
        public bool? IsEnable { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
