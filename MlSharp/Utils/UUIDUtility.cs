using System;

namespace ml_sharp.Utils
{
    public class UuidUtility
    {
        public static string GenerateUuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}