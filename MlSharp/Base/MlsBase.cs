using System.Collections.Generic;
using ml_sharp.Utils;

namespace ml_sharp.Base
{
    /// <summary>
    ///     Base class for all MlSharp objects. All MlSharp objects inherit from this class (directly or indirectly)
    /// </summary>
    public class MlsBase
    {
        /// <summary>
        ///     Creates a new instance of MlsBase class
        /// </summary>
        protected MlsBase()
        {
            Id = MlsUuidUtil.GenerateUuid();
        }

        /// <summary>
        ///     Id of current MlSharp onject
        /// </summary>
        public string Id { get; }

        /// <summary>
        ///     Get MlSharp object as dictionary
        /// </summary>
        /// <returns>Returns a dictionary that represents an MlSharp Object</returns>
        public virtual Dictionary<string, object> AsDictionary()
        {
            return new Dictionary<string, object> {{"id", Id}};
        }

        /// <summary>
        ///     Get MlSharp object as json object
        /// </summary>
        /// <returns>Returns a json string representing current MlSharp object</returns>
        public string AsJson()
        {
            return MlsSerializationUtil.DictionaryToJson(AsDictionary());
        }
    }
}