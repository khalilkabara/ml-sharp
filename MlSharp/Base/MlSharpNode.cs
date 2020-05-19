using System;
using System.Collections.Generic;
using ml_sharp.Utils;

namespace ml_sharp.Base
{
    /// <summary>
    /// Parent class for all MlSharp nodes and entities
    /// </summary>
    public class MlSharpNode : MlSharpBase
    {
        public string NodeName { get; set; }

        /// <summary>
        /// Creates an MlSharp node setting a UUID value for NodeName.
        /// </summary>
        /// <param name="nodeName">Name of the node</param>
        public MlSharpNode(string nodeName)
        {
            NodeName = nodeName;
        }

        /// <summary>
        /// Creates an MlSharp node setting a UUID value for NodeName.
        /// </summary>
        public MlSharpNode()
        {
            NodeName = UuidUtility.GenerateUuid();
        }

        /// <summary>
        /// Return current node values in a dictionary.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("node_name", NodeName);
            return dict;
        }
    }
}