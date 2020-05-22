using System;
using System.Collections.Generic;
using System.Linq;
using ml_sharp.Base;
using ml_sharp.Enums.Genetics;
using ml_sharp.Genetics.Entities;
using ml_sharp.Genetics.Interfaces;
using ml_sharp.Utils;

namespace ml_sharp.Genetics
{
    /// <summary>
    ///     Class for an MlSharp Genetic algorithm
    /// </summary>
    public class GeneticAlgorithm : MlsAlgorithm, IGeneticAlgorithmBuilder
    {
        public EGeneticAlgorithmType EGeneticAlgorithmType;

        // public Generation Generation { get; set; }
        public float Mutation { get; set; }
        public int OffspringPerEntity { get; set; }

        /// <summary>
        ///     Generates offspring based on criteria contained in reproductionInfo.
        /// </summary>
        /// <param name="reproductionInfo">Reproduction criteria.</param>
        /// <returns>Returns one or more offspring as specified in reproductionInfo.</returns>
        public static object YieldOffspring(ReproductionInfo reproductionInfo)
        {
            if (reproductionInfo.NumOffspring >= 1)
                return reproductionInfo.NumOffspring == 1
                    ? ReproduceOne(reproductionInfo)
                    : ReproduceBatch(reproductionInfo);

            MlsLogger.LogError("NumOffspring is less than 1. Can not reproduce.");
            return null;
        }

        /// <summary>
        ///     Reproduce one offspring (single parent).
        /// </summary>
        /// <param name="reproductionInfo">Reproduction criteria.</param>
        /// <returns>Returns reproduced offspring.</returns>
        private static object ReproduceOne(ReproductionInfo reproductionInfo)
        {
            if (reproductionInfo.WithPartner) return ReproduceOneWithPartner(reproductionInfo);

            var offspring = new GeneticEntity();
            MlsLogger.LogInfo("Reproducing one offspring...");

            if (reproductionInfo.OffspringNames != null && reproductionInfo.OffspringNames.Length > 0)
                offspring.Name = reproductionInfo.OffspringNames[0];

            foreach (var newTrait in reproductionInfo.EntityBeingBred.Traits.Select(trait => new Trait(
                trait.TraitName, CalculateInheritedValue(
                    trait.TraitValue,
                    reproductionInfo.EntityBeingBred.GeneticStrength,
                    reproductionInfo.MutationValue,
                    reproductionInfo.MutationEffect,
                    reproductionInfo.Seed))))
                offspring.AddTrait(newTrait);

            // foreach (var trait in reproductionInfo.EntityBeingBred.Traits)
            // {
            //     var newTrait = new Trait(
            //         trait.TraitName, CalculateInheritedValue(
            //             trait.TraitValue));
            // }

            offspring.GeneticStrength = CalculateInheritedValue(
                reproductionInfo.EntityBeingBred.GeneticStrength,
                reproductionInfo.EntityBeingBred.GeneticStrength,
                reproductionInfo.MutationValue,
                reproductionInfo.MutationEffect,
                reproductionInfo.Seed);

            return offspring;
        }

        private static object ReproduceOneWithPartner(ReproductionInfo reproductionInfo)
        {
            if (reproductionInfo.Partner == null)
            {
                MlsLogger.LogError("Partner not set for `ReproduceOneWithPartner`. Can not reproduce");
                return null;
            }

            var offspring = new GeneticEntity();
            MlsLogger.LogInfo("Reproducing one offspring with partner...");
            //todo: code

            return offspring;
        }

        private static object ReproduceBatch(ReproductionInfo reproductionInfo)
        {
            if (reproductionInfo.WithPartner) return ReproduceBatchWithPartner(reproductionInfo);

            var offspring = new List<GeneticEntity>();
            MlsLogger.LogInfo("Batch reproducing offspring...");
            //todo: code

            return offspring;
        }

        private static object ReproduceBatchWithPartner(ReproductionInfo reproductionInfo)
        {
            if (reproductionInfo.Partner == null)
            {
                MlsLogger.LogError("Partner not set for `ReproduceBatchWithPartner`. Can not reproduce.");
                return null;
            }

            var offspring = new List<GeneticEntity>();
            MlsLogger.LogInfo("Batch reproducing offspring with partner...");
            //todo: code

            return offspring;
        }

        private static float CalculateInheritedValue(float originalValueInParent, float parentGeneticStrength,
            float mutationValue, EMutationEffect mutationEffect, in int seed)
        {
            originalValueInParent *= parentGeneticStrength;
            var value = 0.0f;
            switch (mutationEffect)
            {
                case EMutationEffect.Negative:
                    //Decrease value.
                    break;
                case EMutationEffect.Positive:
                    // Increase value.
                    break;
                case EMutationEffect.Random:
                    if (MlsRandomUtil.GetRandomBinary(seed) == 0)
                    {
                        //Decrease value.
                    }

                    // Increase value.
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mutationEffect), mutationEffect, null);
            }

            return value;
        }
    }
}