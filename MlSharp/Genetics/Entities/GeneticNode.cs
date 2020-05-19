using System;
using System.Collections.Generic;
using System.Linq;
using ml_sharp.Base;
using ml_sharp.Utils;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// Defines an MlSharp genetic algorithm entity. A genetic Node
    /// </summary>
    public class GeneticNode : MlSharpNode
    {
        public List<Trait> Traits { get; set; }
        
        /// <summary>
        /// Amount of genes that current node is able to pass on
        /// </summary>
        public float GenesToPassOn { get; set; }

        /// <summary>
        /// Creates a genetic entity (node)
        /// </summary>
        /// <param name="nodeName">Name of the entity (name of the entity)</param>
        /// <param name="traits">List of traits that make up the entity</param>
        public GeneticNode(string nodeName, List<Trait> traits) : base(nodeName)
        {
            Traits = traits;
        }

        /// <summary>
        /// Creates a genetic entity (node).
        /// </summary>
        /// <param name="nodeName">Name given to current node/entity</param>
        /// <param name="traits">Traits belonging to current node/entity</param>
        /// <param name="genesToPassOn">Genes that current node can pass onto next generation during breeding. Max is 1.0, min 0.0f</param>
        public GeneticNode(string nodeName, List<Trait> traits, float genesToPassOn)
        {
            NodeName = nodeName;
            GenesToPassOn = genesToPassOn;
            Traits = traits;
        }

        /// <summary>
        /// Creates a genetic entity (node).
        /// When this constructor is used, entity name is set to a random uuid.
        /// </summary>
        /// <param name="traits">Traits belonging to current node/entity</param>
        /// <param name="genesToPassOn">Genes that current node can pass onto next generation during breeding. Max is 1.0, min 0.0f</param>
        public GeneticNode(List<Trait> traits, float genesToPassOn)
        {
            NodeName = UuidUtility.GenerateUuid();
            GenesToPassOn = genesToPassOn;
            Traits = traits;
        }

        /// <summary>
        /// Creates a genetic entity (node).
        /// When this constructor is used, entity name is set to a random uuid, GenesToPassOn 1.0f and Traits an empty list of traits.
        /// </summary>
        public GeneticNode()
        {
            NodeName = UuidUtility.GenerateUuid();
            GenesToPassOn = 1.0f;
            Traits = new List<Trait>();
        }

        /// <summary>
        /// Adds a new trait to the list of traits belonging to current GeneticNode/entity.
        /// </summary>
        /// <param name="trait">Trait to add to the list.</param>
        public void AddTrait(Trait trait)
        {
            try
            {
                Traits.Add(trait);
            }
            catch (Exception e)
            {
                MlSharpLogger.LogError("Error while adding new trait: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Return current entity as a dictionary.
        /// </summary>
        /// <returns>Current entity as a dictionary.</returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("traits", GetAllTraitsAsDictionary());
            return dict;
        }

        /// <summary>
        /// Get all traits of current entity
        /// </summary>
        /// <returns>Returns all traits belonging to current entity</returns>
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