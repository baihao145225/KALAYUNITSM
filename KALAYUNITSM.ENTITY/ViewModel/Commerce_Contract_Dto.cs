using System;
using System.Collections.Generic;
using System.Linq;

namespace KALAYUNITSM.ENTITY
{
    public class Commerce_Contract_Dto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string TypeName { get; set; }
        public decimal Expenses { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool? DeleteMark { get; set; }
        public bool? IsEnable { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }

    }
}
