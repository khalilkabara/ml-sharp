using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using ml_sharp.Base;
using ml_sharp.Enums;

namespace ml_sharp.Utils
{
    /// <summary>
    /// Contains helper methods for serialization and deserialization
    /// </summary>
    public static class SerializationUtility
    {
        /// <summary>
        /// Converts a dictionary object to JSON and returns the resulting JSON string.
        /// </summary>
        /// <param name="dictionary">Dictionary to convert</param>
        /// <returns>Returns JSON string that represent dictionary that was passed in.</returns>
        public static string DictionaryToJson(Dictionary<string, object> dictionary)
        {
            return JsonSerializer.Serialize(dictionary);
        }

        /// <summary>
        /// Persists current MlSharp object to a set path.
        /// </summary>
        /// <param name="obj">MlSharp object to persist.</param>
        /// <param name="savePath">Path to save object.</param>
        public static void Persist(MlSharpBase obj, string savePath)
        {
            System.IO.File.WriteAllText(savePath, obj.AsJson());
        }
    }
}