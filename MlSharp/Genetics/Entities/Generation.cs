using System.Collections.Generic;
using ml_sharp.Base;

namespace ml_sharp.Genetics.Entities
{
    /// <summary>
    ///     A 'Generation' as a collection of genetic entities that coexist in tandem.
    ///     By default, genetic entities only breed with other entities in the same generation.
    /// </summary>
    public class Generation : MlsBase
    {
        /// <summary>
        ///     Creates a Genetic Generation.
        /// </summary>
        public Generation(string generationName, List<GeneticEntity> entities)
        {
            GenerationName = generationName;
            Entities = entities;
        }

        /// <summary>
        ///     Creates a Genetic Generation.
        ///     When this constructor is used, GenerationName is set to an empty string value and Entities an empty list of
        ///     entities/entities.
        /// </summary>
        public Generation() : this("", new List<GeneticEntity>())
        {
        }

        /// <summary>
        ///     Creates a Genetic Generation.
        ///     When this constructor is used, Entities is set to an empty list of entities/entities.
        /// </summary>
        public Generation(string generationName) : this(generationName, new List<GeneticEntity>())
        {
        }

        /// <summary>
        ///     Creates a Genetic Generation.
        ///     When this constructor is used, GenerationName is set to an empty string.
        /// </summary>
        public Generation(List<GeneticEntity> nodes) : this("", nodes)
        {
        }

        /// <summary>
        ///     String name given to current generation.
        /// </summary>
        public string GenerationName { get; set; }

        /// <summary>
        ///     List of entities belonging to current generation.
        /// </summary>
        public List<GeneticEntity> Entities { get; set; }

        /// <summary>
        ///     Return current entity as a dictionary.
        /// </summary>
        /// <returns>Current entity as a dictionary.</returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("generation_name", GenerationName);
            dict.Add("entities", GetAllNodesAsDictionary());
            return dict;
        }

        /// <summary>
        ///     Get all traits of current entity
        /// </summary>
        /// <returns>Returns all traits belonging to current entity</returns>
        private Dictionary<string, object> GetAllNodesAsDictionary()
        {
            var dict = new Dictionary<string, object>();
            var count = 0;
            foreach (var node in Entities)
            {
                dict.Add(count.ToString(), node.AsDictionary());
                count++;
            }

            return dict;
        }
    }
}