using System;

namespace ml_sharp.Utils
{
    public class MlSharpLogger
    {
        public static void LogInfo(string message)
        {
            Console.WriteLine("INFO: " + message);
        }
        
        public static void LogWarning(string message)
        {
            Console.WriteLine("WARNING: " + message);
        }
        
        public static void LogError(string message)
        {
            Console.WriteLine("ERROR: " + message);
        }
        
    }
}