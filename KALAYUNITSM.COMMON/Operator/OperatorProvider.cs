using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KALAYUNITSM.COMMON
{
    /// <summary>
    /// 用户登陆信息提供者。
    /// </summary>
    public class OperatorProvider
    {

        //静态构造函数实现延迟初始化。
        class InnerInstance
        {
            static InnerInstance() { }
            internal static readonly OperatorProvider instance = new OperatorProvider();
        }
        public static OperatorProvider Instance
        {
            get
            {
                return InnerInstance.instance;
            }
        }
        static OperatorProvider()
        {
        }
        private OperatorProvider()
        {
        }
        public static OperatorProvider getInstance()
        {
            return InnerInstance.instance;
        }

        private string LoginProvider = Configs.GetValue("LoginProvider");
        private int LoginTimeout = Convert.ToInt32(Configs.GetValue("LoginTimeout"));

        private const string LOGIN_USER_KEY = "LoginUser";
        public Operator Current
        {
            get
            {
                Operator operatorModel = new Operator();
                if (LoginProvider == "Cookie")
                {
                    operatorModel = WebHelper.GetCookie(LOGIN_USER_KEY).DESDecrypt().ToObject<Operator>();
                }
                else
                {
                    operatorModel = WebHelper.GetSession(LOGIN_USER_KEY).DESDecrypt().ToObject<Operator>();
                }
                return operatorModel;
            }
            set
            {
                if (LoginProvider == "Cookie")
                {
                    WebHelper.SetCookie(LOGIN_USER_KEY, value.ToJson().DESEncrypt(), LoginTimeout);
                }
                else
                {
                    WebHelper.SetSession(LOGIN_USER_KEY, value.ToJson().DESEncrypt(), LoginTimeout);
                }
            }
        }
        public void Remove()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LOGIN_USER_KEY);
            }
            else
            {
                WebHelper.RemoveSession(LOGIN_USER_KEY);
            }
        }

    }

    /// <summary>
    /// 操作模型，保存登陆用户必要信息。
    /// </summary>
    public class Operator
    {
        public string UserId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string LockPassword { get; set; }
        public string RealName { get; set; }
        public string Avatar { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime LoginTime { get; set; }
        //增加扩展
        public string PositionId { get; set; }
        public string PositionName { get; set; }
    }
}