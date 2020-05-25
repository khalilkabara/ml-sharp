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
            MlsLogger.LogInfo(reproductionInfo.EntityBeingBred.Name + " is reproducing one offspring...");

            if (reproductionInfo.OffspringNames != null && reproductionInfo.OffspringNames.Length > 0)
                offspring.Name = reproductionInfo.OffspringNames[0];

            offspring.GeneticStrength = CalculateInheritedValue(
                reproductionInfo.EntityBeingBred.GeneticStrength,
                reproductionInfo.EntityBeingBred.GeneticStrength,
                reproductionInfo.MutationValue,
                reproductionInfo.MutationEffect,
                reproductionInfo.Seed);

            foreach (var newTrait in reproductionInfo.EntityBeingBred.Traits.Select(trait => new Trait(
                trait.TraitName, CalculateInheritedValue(
                    trait.TraitValue,
                    reproductionInfo.EntityBeingBred.GeneticStrength,
                    reproductionInfo.MutationValue,
                    reproductionInfo.MutationEffect,
                    reproductionInfo.Seed))))
                offspring.AddTrait(newTrait);

            return offspring;
        }

        private static object ReproduceOneWithPartner(ReproductionInfo reproductionInfo)
        {
            if (reproductionInfo.Partner == null)
            {
                MlsLogger.LogError("Partner not set for `ReproduceOneWithPartner`. Can not reproduce");
                return null;
            }

            MlsLogger.LogInfo(reproductionInfo.EntityBeingBred.Name + " is reproducing one offspring with " +
                reproductionInfo.Partner.Name + "...");

            reproductionInfo.EntityBeingBred.GeneticStrength = MlsMathUtil.GetAverage(
                reproductionInfo.EntityBeingBred.GeneticStrength,
                reproductionInfo.Partner.GeneticStrength);

            var partnerTraits = reproductionInfo.Partner.Traits;
            reproductionInfo.EntityBeingBred.Traits.AddRange(partnerTraits);
            // Remove duplicate traits if set to true, set value as average of duplicates

            reproductionInfo.WithPartner = false;
            reproductionInfo.Partner = null;

            return ReproduceOne(reproductionInfo);
        }

        private static object ReproduceBatch(ReproductionInfo reproductionInfo)
        {
            if (reproductionInfo.WithPartner) return ReproduceBatchWithPartner(reproductionInfo);

            var offspring = new List<GeneticEntity>();
            MlsLogger.LogInfo(reproductionInfo.EntityBeingBred.Name + " is batch reproducing offspring...");
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
            MlsLogger.LogInfo(reproductionInfo.EntityBeingBred.Name + " is batch reproducing offspring with " +
                reproductionInfo.Partner.Name + "...");
            //todo: code

            return offspring;
        }

        private static float CalculateInheritedValue(float originalValueInParent, float parentGeneticStrength,
            float mutationValue, EMutationEffect mutationEffect, in int seed)
        {
            mutationValue = mutationValue < 0 ? 0 : mutationValue;
            mutationValue = mutationValue > GeneticEntity.MaxGlobalMutationPercent
                ? GeneticEntity.MaxGlobalMutationPercent
                : mutationValue;

            var value = originalValueInParent * parentGeneticStrength;
            switch (mutationEffect)
            {
                case EMutationEffect.Negative:
                    //Decrease value.
                    value -= mutationValue;
                    break;
                case EMutationEffect.Positive:
                    // Increase value.
                    value += mutationValue;
                    break;
                case EMutationEffect.Random:
                    if (MlsMathUtil.GetRandomBinary(seed) == 0)
                    {
                        //Decrease value.
                        value -= mutationValue;
                    }

                    // Increase value.
                    value += mutationValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mutationEffect), mutationEffect, null);
            }

            value = value < 0 ? 0 : value;
            value = value > 1 ? 1 : value;

            // Round value to 2dp
            value = (float) Math.Round(value * 100f) / 100f;

            return value;
        }
    }
}