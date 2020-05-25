using System;
using System.Collections.Generic;
using ml_sharp.Base;
using ml_sharp.Enums.Genetics;
using ml_sharp.Utils;

namespace ml_sharp.Genetics.Entities
{
    /// <summary>
    ///     Defines an MlSharp genetic algorithm entity. A genetic Node
    /// </summary>
    public class GeneticEntity : MlsNode
    {
        private static float _maxGlobalMutationPercent = 0.25f;

        /// <summary>
        ///     Creates a genetic entity (node).
        /// </summary>
        /// <param name="name">Name given to current node/entity</param>
        /// <param name="traits">Traits belonging to current node/entity</param>
        /// <param name="geneticStrength">
        ///     Genes that current node can pass onto next generation during breeding. Max is 1.0, min
        ///     0.0f
        /// </param>
        public GeneticEntity(string name, List<Trait> traits, float geneticStrength)
        {
            Name = name;
            GeneticStrength = geneticStrength;
            Traits = traits;
        }

        /// <summary>
        ///     Creates a genetic entity (node)
        ///     When this constructor is used, GeneticStrength is set to a value of 1.0f
        /// </summary>
        /// <param name="name">Name of the entity (name of the entity)</param>
        /// <param name="traits">List of traits that make up the entity</param>
        public GeneticEntity(string name, List<Trait> traits) : this(name, traits, 1.0f)
        {
        }

        /// <summary>
        ///     Creates a genetic entity (node).
        ///     When this constructor is used, entity name is set to an empty string.
        /// </summary>
        /// <param name="traits">Traits belonging to current node/entity</param>
        /// <param name="genesToPassOn">Genes that current node can pass onto next generation during breeding. Max is 1.0, min 0.0f</param>
        public GeneticEntity(List<Trait> traits, float genesToPassOn) : this("", traits, genesToPassOn)
        {
        }

        /// <summary>
        ///     Creates a genetic entity (node).
        ///     When this constructor is used, entity name is set to an empty string, GeneticStrength 1.0f and Traits an empty list
        ///     of traits.
        /// </summary>
        public GeneticEntity() : this("", new List<Trait>(), 1.0f)
        {
        }

        /// <summary>
        ///     The maximum allowed global percentage for mutations.
        ///     Minimum allowed value for MaxGlobalMutationPercent is 0 and will be set to 0 if a lesser value is set.
        ///     Maximum allowed value for MaxGlobalMutationPercent is 1 and will be set to 1 if a greater value is set.
        /// </summary>
        public static float MaxGlobalMutationPercent
        {
            get => _maxGlobalMutationPercent;

            set
            {
                _maxGlobalMutationPercent = value < 0.0f ? 0.0f : value;
                _maxGlobalMutationPercent = value > 1.0f ? 1.0f : value;
            }
        }

        /// <summary>
        ///     Determines how mutation affects value of traits inherited by offspring.
        ///     Positively, negatively, or randomly meaning some traits positively and some negatively at random.
        /// </summary>
        public EMutationEffect GlobalMutationEffect { get; set; } = EMutationEffect.Random;

        /// <summary>
        ///     List of all traits belonging to current GeneticEntity
        /// </summary>
        public List<Trait> Traits { get; set; }

        /// <summary>
        ///     Measure of genes that current node is able to pass on to offspring.
        ///     This determines how likely it is for current entity to pass all of it's genes to it's offspring.
        ///     When genes get passed on to offspring, Genetic strength of mating partner (if any) is also considered.
        /// </summary>
        public float GeneticStrength { get; set; }

        /// <summary>
        ///     Adds a new trait to the list of traits belonging to current GeneticEntity/entity.
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
                MlsLogger.LogError("Error while adding new trait: " + e.Message);
                throw;
            }
        }

        /// <summary>
        ///     Reproduces an offspring using current entity as parent.
        /// </summary>
        /// <param name="mutationValue">
        ///     The percentage by which mutation affects traits of resulting entity (between 0 and MaxGlobalMutationPercent or 1,
        ///     whichever is less).
        ///     mutationValue is set to 0 if less than 0, MaxGlobalMutationPercent if greater than MaxGlobalMutationPercent, or 1
        ///     if MaxGlobalMutationPercent is greater than 1.
        ///     Maximum allowed value for MaxGlobalMutationPercent is 1 and will be set to 1 if a greater value is set.
        /// </param>
        /// <param name="offspringName">Name of resulting offspring (empty string if not set).</param>
        /// <param name="seed">
        ///     Seed for random generator. This is useful when trying to recreate outputs.
        ///     When 0 is set, no seed is used. 0 is set by default
        /// </param>
        /// <returns>Returns a new GeneticEntity (offspring) built with criteria of current entity as base.</returns>
        public GeneticEntity ReproduceOne(float mutationValue, string offspringName = "", int seed = 0)
        {
            var info = new ReproductionInfo(this, 1, mutationValue, GlobalMutationEffect,
                false, null, false, new[] {offspringName}, seed);

            return (GeneticEntity) GeneticAlgorithm.YieldOffspring(info);
        }

        /// <summary>
        ///     Reproduces an offspring using current entity and partner as parents.
        /// </summary>
        /// <param name="partner">Partner to reproduce with. Another entity</param>
        /// <param name="mutationValue">
        ///     The percentage by which mutation affects traits of resulting entity (between 0 and MaxGlobalMutationPercent or 1,
        ///     whichever is less).
        ///     mutationValue is set to 0 if less than 0, MaxGlobalMutationPercent if greater than MaxGlobalMutationPercent, or 1
        ///     if MaxGlobalMutationPercent is greater than 1.
        ///     Maximum allowed value for MaxGlobalMutationPercent is 1 and will be set to 1 if a greater value is set.
        /// </param>
        /// <param name="mergeCommonTraits">
        ///     If or not to allow traits with same name from both parents.
        ///     If set to true, all traits with common name on both parents will be flattened to one trait in resulting offspring.
        ///     When false is set, offspring will be allowed to have multiple traits with same name.
        /// </param>
        /// <param name="offspringName">Name of resulting offspring (empty string if not set).</param>
        /// <param name="seed">
        ///     Seed for random generator. This is useful when trying to recreate outputs.
        ///     When 0 is set, no seed is used. 0 is set by default
        /// </param>
        /// <returns>Returns a new GeneticEntity (offspring) built with criteria of current entity as base.</returns>
        public GeneticEntity ReproduceOneWithPartner(GeneticEntity partner, float mutationValue,
            string offspringName = "", bool mergeCommonTraits = true, int seed = 0)
        {
            var info = new ReproductionInfo(this, 1, mutationValue, GlobalMutationEffect,
                true, partner, mergeCommonTraits, new[] {offspringName}, seed);

            return (GeneticEntity) GeneticAlgorithm.YieldOffspring(info);
        }

        /// <summary>
        ///     Reproduces several offspring using current entity as parent.
        /// </summary>
        /// <param name="numOffspring">Number of offspring to reproduce.</param>
        /// <param name="mutationValue">
        ///     The percentage by which mutation affects traits of resulting entity (between 0 and MaxGlobalMutationPercent or 1,
        ///     whichever is less).
        ///     mutationValue is set to 0 if less than 0, MaxGlobalMutationPercent if greater than MaxGlobalMutationPercent, or 1
        ///     if MaxGlobalMutationPercent is greater than 1.
        ///     Maximum allowed value for MaxGlobalMutationPercent is 1 and will be set to 1 if a greater value is set.
        /// </param>
        /// <param name="offspringNames">
        ///     Array of names to be given to resulting offspring (empty strings if not set).
        ///     If length of names array is shorter than numOffspring, the first n offspring will be assigned names from this list
        ///     and the rest set to an empty string.
        /// </param>
        /// <param name="seed">
        ///     Seed for random generator. This is useful when trying to recreate outputs.
        ///     When 0 is set, no seed is used. 0 is set by default
        /// </param>
        /// <returns>Returns a new GeneticEntity (offspring) built with criteria of current entity as base.</returns>
        public List<GeneticEntity> ReproduceBatch(int numOffspring, float mutationValue, string[] offspringNames = null,
            int seed = 0)
        {
            var info = new ReproductionInfo(this, numOffspring, mutationValue, GlobalMutationEffect,
                false, null, false, offspringNames, seed);

            return (List<GeneticEntity>) GeneticAlgorithm.YieldOffspring(info);
        }

        /// <summary>
        ///     Reproduces several offspring using current entity and partner as parents.
        /// </summary>
        /// <param name="partner">Partner to reproduce with. Another entity</param>
        /// <param name="numOffspring">Number of offspring to reproduce.</param>
        /// <param name="mutationValue">
        ///     The percentage by which mutation affects traits of resulting entity (between 0 and MaxGlobalMutationPercent or 1,
        ///     whichever is less).
        ///     mutationValue is set to 0 if less than 0, MaxGlobalMutationPercent if greater than MaxGlobalMutationPercent, or 1
        ///     if MaxGlobalMutationPercent is greater than 1.
        ///     Maximum allowed value for MaxGlobalMutationPercent is 1 and will be set to 1 if a greater value is set.
        /// </param>
        /// <param name="mergeCommonTraits">
        ///     If or not to allow traits with same name from both parents.
        ///     If set to true, all traits with common name on both parents will be flattened to one trait in resulting offspring.
        ///     When false is set, offspring will be allowed to have multiple traits with same name.
        /// </param>
        /// <param name="offspringNames">
        ///     Array of names to be given to resulting offspring (empty strings if not set).
        ///     If length of names array is shorter than numOffspring, the first n offspring will be assigned names from this list
        ///     and the rest set to an empty string.
        /// </param>
        /// <param name="seed">
        ///     Seed for random generator. This is useful when trying to recreate outputs.
        ///     When 0 is set, no seed is used. 0 is set by default
        /// </param>
        /// <returns>Returns a new GeneticEntity (offspring) built with criteria of current entity as base.</returns>
        public List<GeneticEntity> ReproduceBatchWithPartner(GeneticEntity partner, int numOffspring,
            float mutationValue, string[] offspringNames = null, bool mergeCommonTraits = true, int seed = 0)
        {
            var info = new ReproductionInfo(this, numOffspring, mutationValue, GlobalMutationEffect,
                true, partner, mergeCommonTraits, offspringNames, seed);

            return (List<GeneticEntity>) GeneticAlgorithm.YieldOffspring(info);
        }

        /// <summary>
        ///     Return current entity as a dictionary.
        /// </summary>
        /// <returns>Current entity as a dictionary.</returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("traits", GetAllTraitsAsDictionary());
            return dict;
        }

        /// <summary>
        ///     Get all traits of current entity
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