using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_SLA_Dto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContractId { get; set; }
        public string ContractName { get; set; }
        public string SLTsName { get; set; }
        public List<string> SLTsId { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
    }
}
