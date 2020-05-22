using System;

namespace ml_sharp.Utils
{
    public static class MlsUuidUtil
    {
        /// <summary>
        ///     Generates a unique UUID string.
        /// </summary>
        /// <returns>Returns UUID</returns>
        public static string GenerateUuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}