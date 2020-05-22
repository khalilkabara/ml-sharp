using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ml_sharp.Base;

namespace ml_sharp.Utils
{
    /// <summary>
    ///     Contains helper methods for serialization and deserialization
    /// </summary>
    public static class MlsSerializationUtil
    {
        /// <summary>
        ///     Converts a dictionary object to JSON and returns the resulting JSON string.
        /// </summary>
        /// <param name="dictionary">Dictionary to convert</param>
        /// <returns>Returns JSON string that represent dictionary that was passed in.</returns>
        public static string DictionaryToJson(Dictionary<string, object> dictionary)
        {
            return JsonSerializer.Serialize(dictionary);
        }

        /// <summary>
        ///     Persists current MlSharp object to a set path.
        /// </summary>
        /// <param name="obj">MlSharp object to persist.</param>
        /// <param name="savePath">Path to save object.</param>
        public static void Persist(MlsBase obj, string savePath)
        {
            File.WriteAllText(savePath, obj.AsJson());
        }
    }
}