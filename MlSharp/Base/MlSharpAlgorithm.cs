using System.Collections.Generic;
using ml_sharp.Enums;
using ml_sharp.Enums.Genetics;

namespace ml_sharp.Base
{
    /// <summary>
    /// Defines an MlSharp genetic algorithm
    /// </summary>
    public class MlSharpAlgorithm : MlSharpBase
    {
        public EGeneticAlgorithmType GeneticAlgorithmType;
        
        /// <summary>
        /// Get MlSharp object as dictionary
        /// </summary>
        /// <returns>Returns a dictionary that represents an MlSharp Object</returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("algorithm_type", GeneticAlgorithmType);
            return dict;
        }
    }
}