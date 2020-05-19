using System;
using System.Collections.Generic;
using ml_sharp.Utils;

namespace ml_sharp.Base
{
    public class MlSharpNode : MlSharpBase
    {
        public string NodeName;

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
        /// Gets the name of an MlSharpNode
        /// </summary>
        /// <returns>The name of an MlSharpNode</returns>
        public string GetNodeName()
        {
            return NodeName;
        }
        
        /// <summary>
        /// Sets string name for a MlSharpNode
        /// </summary>
        /// <param name="nodeName">Name of the node</param>
        public void SetNodeName(string nodeName)
        {
            NodeName = nodeName;
        }
        
        /// <summary>
        /// Return current node values in a dictionary.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> NodeAsDictionary()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("NodeName", NodeName);
            return dict;
        }
    }
}