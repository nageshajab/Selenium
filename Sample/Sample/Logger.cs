using NLog;
using System;

namespace SmokeTests
{
    public class Logger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void Error(string step, string status, string msg, string exception = "")
        {
            string logmsg = $"StepName: {step}, Status: {status}, Date: { DateTime.Now:MM/dd/yyyy HH:mm}, Exception: {exception}, Msg: {msg}";
            Console.WriteLine(logmsg);
            logger.Error(logmsg);
        }
        public static void Info(string step, string status, string msg)
        {
            string logmsg = $"StepName: {step}, Status: {status}, Date: { DateTime.Now:MM/dd/yyyy HH:mm}, Exception: NONE, Msg: {msg}";
            Console.WriteLine(logmsg);
            logger.Info(logmsg);
        }
    }
}
