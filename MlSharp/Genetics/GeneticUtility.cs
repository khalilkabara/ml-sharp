using System.Collections.Generic;
using ml_sharp.Genetics.Entities;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// Contains useful methods for MlSharp genetic manipulations
    /// </summary>
    public class GeneticUtility
    {
        public static void MergeGenerations(List<Generation> generations)
        {
            
        }

        public static Generation AsGeneration(List<GeneticEntity> entities, string generationName = "")
        {
            return new Generation(generationName, entities);
        }
    }
}