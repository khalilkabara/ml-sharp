using System.Collections.Generic;
using ml_sharp.Utils;

namespace ml_sharp.Base
{
    /// <summary>
    ///     Parent class for all MlSharp nodes and entities
    /// </summary>
    public class MlsNode : MlsBase
    {
        /// <summary>
        ///     Creates an MlSharp node setting a UUID value for Name.
        /// </summary>
        /// <param name="name">Name of the node</param>
        public MlsNode(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Creates an MlSharp node setting a UUID value for Name.
        /// </summary>
        public MlsNode()
        {
            Name = MlsUuidUtil.GenerateUuid();
        }

        public string Name { get; set; }

        /// <summary>
        ///     Return current node values in a dictionary.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("name", Name);
            return dict;
        }
    }
}