using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_User : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string Account { get; set; }
        public string RealName { get; set; } 
        public string Password { get; set; }
        public string Avatar { get; set; }
        public bool? Gender { get; set; }
        public string TelPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string EmployeeId { get; set; }
        public string CompanyId { get; set; }
        public string OrganizationId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsEnable { get; set; }
        public bool? IsOnLine { get; set; }
        public bool? IsLock { get; set; }
        public bool? AllowMultiUserOnline { get; set; }
        public string AllowIPAddress { get; set; }
        public int LoginCount { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? PrevLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public string Theme { get; set; } 
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
