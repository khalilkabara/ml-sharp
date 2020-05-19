using System.Collections.Generic;
using System.Text.Json;

namespace ml_sharp.Utils
{
    /// <summary>
    /// Contains helper methods for serialization and deserialization
    /// </summary>
    public class SerializationUtility
    {
        /// <summary>
        /// Converts a dictionary object to JSON and returns the resulting JSON string.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string DictionaryToJson(Dictionary<string, object> dictionary)
        {
            return JsonSerializer.Serialize(dictionary);
        }
    }
}