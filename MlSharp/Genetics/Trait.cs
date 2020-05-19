using System;
using System.Collections.Generic;
using ml_sharp.Base;
using ml_sharp.Utils;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// A distinguishing quality or characteristic belonging to a GeneticAlgorithm
    /// </summary>
    public class Trait : MlSharpBase
    {
        public string TraitName { get; }
        public float TraitValue { get; set; }
        
        /// <summary>
        /// Creates a genetic trait. A distinguishing quality or characteristic belonging to a GeneticAlgorithm
        /// </summary>
        /// <param name="traitName">Name given to the trait</param>
        /// <param name="traitValue">The initial value </param>
        public Trait(string traitName, float traitValue)
        {
            TraitName = traitName;
            TraitValue = traitValue;
        }
        
        /// <summary>
        /// Creates a genetic trait. A distinguishing quality or characteristic belonging to a GeneticAlgorithm.
        /// When this constructor is used, TraitName will be assigned a UUID value and TraitValue set to 1.0f.
        /// </summary>
        public Trait()
        {
            TraitName = UuidUtility.GenerateUuid();
            TraitValue = 1.0f;
        }

        /// <summary>
        /// Creates a genetic trait. A distinguishing quality or characteristic belonging to a GeneticAlgorithm.
        /// When this constructor is used, TraitName will be assigned a UUID value.
        /// </summary>
        /// <param name="traitValue">Initial value for this trait (between 0 and 1)</param>
        public Trait(float traitValue)
        {
            TraitName = UuidUtility.GenerateUuid();
            TraitValue = traitValue;
        }

        public Dictionary<string, object> TraitAsDictionary()
        {
            var dict = new Dictionary<string, object> {{"TraitName", TraitName}, {"TraitValue", TraitValue}};
            return dict;
        }
    }
}