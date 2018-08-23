using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.COMMON
{
    public class SystemItemMsgs
    {
        public const string USER_LOGIN_USERNAME_ERROR = "用户名错误";
        public const string USER_LOGIN_PASSWORD_ERROR = "密码错误";
        public const string USER_LOGIN_VERIFYCODE_ERROR = "验证码错误";
        public const string USER_LOGIN_EXPIRED_ERROR = "用户已过期";
        public const string USER_LOGIN_CHK_SUCCESS = "登录成功";
        public const string USER_LOGIN_USERLOCK_ERROR = "用户已锁定";
        public const string USER_LOGIN_USERNOENABLED_ERROR = "用户被禁用";
        public const string USER_CHK_USED_ERROR = "此用户名已被注册";
        public const string USER_CHK_ALLOW_SUCCESS = "此用户名可以使用";
        public const string ITSM_ORDERSTATUS_CANCEL_ERROR = "工单状态变更，无法取消";
        public const string ITSM_ORDERSTATUS_CLOSE_ERROR = "工单在处理中，无法关闭";
        public const string ITSM_ORDERSTATUS_SLOVE_ERROR = "工单状态变更，无法操作";
        public const string ITSM_CHK_ORDERCURRUSER_ERROR = "工单处理权限有误";
        
        
    }
}
