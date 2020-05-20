using System;
using System.Collections.Generic;
using ml_sharp.Base;
using ml_sharp.Utils;

namespace ml_sharp.Genetics.Entities
{
    /// <summary>
    /// Defines an MlSharp genetic algorithm entity. A genetic Node
    /// </summary>
    public class GeneticEntity : MlSharpNode
    {
        /// <summary>
        /// List of all traits belonging to current GeneticEntity
        /// </summary>
        public List<Trait> Traits { get; set; }

        /// <summary>
        /// Amount of genes that current node is able to pass on
        /// </summary>
        public float GenesToPassOn { get; set; }

        /// <summary>
        /// Creates a genetic entity (node).
        /// </summary>
        /// <param name="name">Name given to current node/entity</param>
        /// <param name="traits">Traits belonging to current node/entity</param>
        /// <param name="genesToPassOn">Genes that current node can pass onto next generation during breeding. Max is 1.0, min 0.0f</param>
        public GeneticEntity(string name, List<Trait> traits, float genesToPassOn)
        {
            Name = name;
            GenesToPassOn = genesToPassOn;
            Traits = traits;
        }

        /// <summary>
        /// Creates a genetic entity (node)
        /// When this constructor is used, GenesToPassOn is set to a value of 1.0f
        /// </summary>
        /// <param name="name">Name of the entity (name of the entity)</param>
        /// <param name="traits">List of traits that make up the entity</param>
        public GeneticEntity(string name, List<Trait> traits) : this(name, traits, 1.0f)
        {
        }

        /// <summary>
        /// Creates a genetic entity (node).
        /// When this constructor is used, entity name is set to an empty string.
        /// </summary>
        /// <param name="traits">Traits belonging to current node/entity</param>
        /// <param name="genesToPassOn">Genes that current node can pass onto next generation during breeding. Max is 1.0, min 0.0f</param>
        public GeneticEntity(List<Trait> traits, float genesToPassOn) : this("", traits, genesToPassOn)
        {
        }

        /// <summary>
        /// Creates a genetic entity (node).
        /// When this constructor is used, entity name is set to an empty string, GenesToPassOn 1.0f and Traits an empty list of traits.
        /// </summary>
        public GeneticEntity() : this("", new List<Trait>(), 1.0f)
        {
        }

        /// <summary>
        /// Adds a new trait to the list of traits belonging to current GeneticEntity/entity.
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

        public object Reproduce(int numOffspring, string[] offspringNames, float minMutation,
            float maxMutation, bool returnAsGeneration = false, string generationName = "")
        {
            var info = new ReproductionInfo(numOffspring, offspringNames, minMutation,
                maxMutation, returnAsGeneration, generationName);

            if (returnAsGeneration) return (Generation) GeneticAlgorithm.YieldOffspring(info);
            return (List<GeneticEntity>) GeneticAlgorithm.YieldOffspring(info);
        }

        public object Reproduce(int numOffspring, float minMutation, float maxMutation,
            bool returnAsGeneration = false, string generationName = "")
        {
            return Reproduce(numOffspring, null, minMutation, maxMutation, returnAsGeneration, generationName);
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