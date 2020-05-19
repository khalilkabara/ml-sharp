using System.Collections.Generic;
using ml_sharp.Enums;

namespace ml_sharp.Base
{
    /// <summary>
    /// Defines an MlSharp genetic algorithm
    /// </summary>
    public class MlSharpAlgorithm : MlSharpBase
    {
        public EAlgorithmType AlgorithmType;
        
        /// <summary>
        /// Get MlSharp object as dictionary
        /// </summary>
        /// <returns>Returns a dictionary that represents an MlSharp Object</returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("algorithm_type", AlgorithmType);
            return dict;
        }
    }
}