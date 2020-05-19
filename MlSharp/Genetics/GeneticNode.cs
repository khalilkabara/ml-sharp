using System;
using System.Collections.Generic;
using System.Linq;
using ml_sharp.Base;
using ml_sharp.Utils;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// Defines an MlSharp genetic algorithm entity
    /// </summary>
    public class GeneticNode : MlSharpNode
    {
        public List<Trait> Traits { get; set; }

        /// <summary>
        /// Creates a genetic node (entity)
        /// </summary>
        /// <param name="nodeName">Name of the node (name of the entity)</param>
        /// <param name="traits">List of traits that make up the entity</param>
        public GeneticNode(string nodeName, List<Trait> traits) : base(nodeName)
        {
            Traits = traits;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="traits"></param>
        public GeneticNode(List<Trait> traits)
        {
            NodeName = UuidUtility.GenerateUuid();
            Traits = traits;
        }

        /// <summary>
        /// Return current node values in a dictionary.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("traits", GetAllTraitsAsDictionary());
            return dict;
        }

        private Dictionary<string, object> GetAllTraitsAsDictionary()
        {
            var dict = new Dictionary<string, object>();
            var count = 0;
            foreach (var trait in Traits)
            {
                dict.Add(count.ToString(), trait.AsDictionary());
                count++;
            }

            return dict;
        }
    }
}