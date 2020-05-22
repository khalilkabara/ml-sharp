using System;
using ml_sharp.Enums;

namespace ml_sharp.Utils
{
    public static class MlsLogger
    {
        public static ELogLevel LogLevel = ELogLevel.Error;

        public static void LogInfo(string message)
        {
            if (!LogLevel.Equals(ELogLevel.None))
                Console.WriteLine("MLS.INFO: " + message);
        }

        public static void LogWarning(string message)
        {
            if (LogLevel.Equals(ELogLevel.Warning) ||
                LogLevel.Equals(ELogLevel.Error))
                Console.WriteLine("MLS.WARNING: " + message);
        }

        public static void LogError(string message)
        {
            if (LogLevel.Equals(ELogLevel.Error))
                Console.WriteLine("MLS.ERROR: " + message);
        }
    }
}