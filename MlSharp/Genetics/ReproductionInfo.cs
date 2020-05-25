﻿using ml_sharp.Enums.Genetics;
using ml_sharp.Genetics.Entities;

namespace ml_sharp.Genetics
{
    /// <summary>
    ///     This is a data class that defines the list of criteria required for reproduction
    /// </summary>
    public struct ReproductionInfo
    {
        public GeneticEntity EntityBeingBred { get; set; }

        public int NumOffspring { get; set; }

        public float MutationValue { get; set; }

        public EMutationEffect MutationEffect { get; set; }

        public bool WithPartner { get; set; }

        public GeneticEntity Partner { get; set; }
        public bool MergeCommonTraits { get; set; }

        public string[] OffspringNames { get; set; }

        public int Seed { get; set; }

        /// <summary>
        ///     Creates a ReproductionInfo object.
        /// </summary>
        /// <param name="entityBeingBred">Entity that initiates reproduction.</param>
        /// <param name="numOffspring">Number of offspring to reproduce.</param>
        /// <param name="mutationValue">
        ///     Determines the value by which mutation affects traits of resulting entity (between 0 and
        ///     1).
        /// </param>
        /// <param name="mutationEffect">
        ///     Determines how mutation affects value traits inherited by offspring.
        ///     (Positively, negatively, or randomly meaning some traits positively and some negatively at random).
        /// </param>
        /// <param name="withPartner">If or not breeding will occur with a partner entity.</param>
        /// <param name="partner">Partner entity to breed with.</param>
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
        public ReproductionInfo(GeneticEntity entityBeingBred, int numOffspring, float mutationValue,
            EMutationEffect mutationEffect, bool withPartner, GeneticEntity partner, bool mergeCommonTraits,
            string[] offspringNames, int seed = 0)
        {
            EntityBeingBred = entityBeingBred;
            NumOffspring = numOffspring;
            MutationValue = mutationValue;
            MutationEffect = mutationEffect;
            WithPartner = withPartner;
            Partner = partner;
            MergeCommonTraits = mergeCommonTraits;
            OffspringNames = offspringNames;
            Seed = seed;
        }
    }
}