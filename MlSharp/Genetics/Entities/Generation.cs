﻿using System.Collections.Generic;
using ml_sharp.Base;
using ml_sharp.Utils;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// A 'Generation' as a collection of genetic nodes that coexist in tandem.
    /// By default, genetic nodes only breed with other nodes in the same generation.
    /// </summary>
    public class Generation : MlSharpBase
    {
        public string GenerationName { get; set; }
        public List<GeneticNode> Nodes { get; set; }

        /// <summary>
        /// Creates a Genetic Generation.
        /// When this constructor is used, GenerationName is set to a random UUID value and Nodes an empty list of nodes/entities.
        /// </summary>
        public Generation()
        {
            GenerationName = UuidUtility.GenerateUuid();
            Nodes = new List<GeneticNode>();
        }
        
        /// <summary>
        /// Creates a Genetic Generation.
        /// When this constructor is used, Nodes is set to an empty list of nodes/entities.
        /// </summary>
        public Generation(string generationName)
        {
            GenerationName = generationName;
            Nodes = new List<GeneticNode>();
        }

        /// <summary>
        /// Creates a Genetic Generation.
        /// When this constructor is used, GenerationName is set to a random UUID value.
        /// </summary>
        public Generation(List<GeneticNode> nodes)
        {
            GenerationName = UuidUtility.GenerateUuid();
            Nodes = nodes;
        }

        /// <summary>
        /// Creates a Genetic Generation.
        /// </summary>
        public Generation(string generationName, List<GeneticNode> nodes)
        {
            GenerationName = generationName;
            Nodes = nodes;
        }

        /// <summary>
        /// Return current entity as a dictionary.
        /// </summary>
        /// <returns>Current entity as a dictionary.</returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("generation_name", GenerationName);
            dict.Add("nodes", GetAllNodesAsDictionary());
            return dict;
        }

        /// <summary>
        /// Get all traits of current entity
        /// </summary>
        /// <returns>Returns all traits belonging to current entity</returns>
        private Dictionary<string, object> GetAllNodesAsDictionary()
        {
            var dict = new Dictionary<string, object>();
            var count = 0;
            foreach (var node in Nodes)
            {
                dict.Add(count.ToString(), node.AsDictionary());
                count++;
            }

            return dict;
        }
    }
}