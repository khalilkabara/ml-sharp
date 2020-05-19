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
            SetNodeName(UuidUtility.GenerateUuid());
            Traits = traits;
        }

        /// <summary>
        /// Return current node values in a dictionary.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> NodeAsDictionary()
        {
            var dict = base.NodeAsDictionary();
            dict.Add("Traits", GetAllTraitsAsDictionary());
            return dict;
        }

        private Dictionary<string, object> GetAllTraitsAsDictionary()
        {
            return Traits.ToDictionary<Trait, string, object>(trait => trait.TraitName, trait => trait.TraitValue);
        }
    }
}