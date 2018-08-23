using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using NLog;
using NLog.Config;

namespace KALAYUNITSM.COMMON
{

    public static class LogHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void RegisterConfig()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + @"\Configs\NLog.config";
            LogManager.Configuration = new XmlLoggingConfiguration(configPath);
        }

        public static void Write(LevelType level, string operation, string message, string account, string exception = "")
        {
            LogEventInfo logEvent = new LogEventInfo();
            logEvent.Message = message;
            switch (level)
            {
                case LevelType.Trace:
                    logEvent.Level = LogLevel.Trace;
                    break;
                case LevelType.Debug:
                    logEvent.Level = LogLevel.Debug;
                    break;
                case LevelType.Info:
                    logEvent.Level = LogLevel.Info;
                    break;
                case LevelType.Warn:
                    logEvent.Level = LogLevel.Warn;
                    break;
                case LevelType.Error:
                    logEvent.Level = LogLevel.Error;
                    break;
                case LevelType.Fatal:
                    logEvent.Level = LogLevel.Fatal;
                    break;
            }
            logEvent.Properties["Id"] = Tools.GuId();
            logEvent.Properties["Account"] = account;
            logEvent.Properties["Operation"] = operation;
            logEvent.Properties["IP"] = Net.Ip;
            logEvent.Properties["IPAddress"] = Net.GetAddress(Net.Ip);
            logEvent.Properties["Browser"] = Net.Browser;
            logEvent.Properties["Exception"] = exception;
            logger.Log(logEvent);
        }

        /// <summary>
        /// 最常见的记录信息，一般用于普通输出。
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            logger.Trace(message);
        }

        /// <summary>
        /// 同样是记录信息，不过出现的频率要比Trace少一些，一般用来调试程序。
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// 信息类型的消息。
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// 警告信息，一般用于比较重要的场合。
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// 错误信息。
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// 致命异常信息。一般来讲，发生致命异常之后程序将无法继续执行。
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }
    }

    public enum LevelType
    {
        [Description("普通输出")]
        Trace,
        [Description("一般调试")]
        Debug,
        [Description("普通消息")]
        Info,
        [Description("警告信息")]
        Warn,
        [Description("一般错误")]
        Error,
        [Description("致命错误")]
        Fatal
    }

}
