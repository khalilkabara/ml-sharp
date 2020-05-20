using System.Collections.Generic;
using ml_sharp.Base;
using ml_sharp.Enums.Genetics;
using ml_sharp.Genetics.Entities;
using ml_sharp.Genetics.Interfaces;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// Class for an MlSharp Genetic algorithm
    /// </summary>
    public class GeneticAlgorithm : MlSharpAlgorithm, IGeneticAlgorithmBuilder
    {
        public EGeneticAlgorithmType EGeneticAlgorithmType;

        // public Generation Generation { get; set; }
        public float Mutation { get; set; }
        public int OffspringPerEntity { get; set; }


        public List<GeneticEntity> SoloBreed(GeneticEntity entity)
        {
            return null;
        }

        public Generation SoloBreed(List<GeneticEntity> nodes)
        {
            return null;
        }

        public Generation PairBreed(BreedType breedType, Generation generation, int offSpringPerPair, int maxOffspring)
        {
            return null;
        }

        public static object YieldOffspring(ReproductionInfo reproductionInfo)
        {
            // if (reproductionInfo.OffspringNames == null)
            //     var offspringNames = new string[0];
            //
            // if(reproductionInfo.ReturnAsGeneration)
            //     Generation generation = new Generation();

            return null;
        }
    }
}