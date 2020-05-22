using System.Collections.Generic;
using ml_sharp.Base;

namespace ml_sharp.Genetics.Entities
{
    /// <summary>
    ///     A distinguishing quality or characteristic belonging to a GeneticAlgorithm
    /// </summary>
    public class Trait : MlsBase
    {
        /// <summary>
        ///     Creates a genetic trait. A distinguishing quality or characteristic belonging to a GeneticAlgorithm
        /// </summary>
        /// <param name="traitName">Name given to the trait</param>
        /// <param name="traitValue">The initial value </param>
        public Trait(string traitName, float traitValue)
        {
            TraitName = traitName;
            TraitValue = traitValue;
        }

        /// <summary>
        ///     Creates a genetic trait. A distinguishing quality or characteristic belonging to a GeneticAlgorithm.
        ///     When this constructor is used, TraitName will be assigned an empty string value and TraitValue set to 1.0f.
        /// </summary>
        public Trait() : this("", 1.0f)
        {
        }

        /// <summary>
        ///     Creates a genetic trait. A distinguishing quality or characteristic belonging to a GeneticAlgorithm.
        ///     When this constructor is used, TraitName will be assigned an empty string value.
        /// </summary>
        /// <param name="traitValue">Initial value for this trait (between 0 and 1)</param>
        public Trait(float traitValue) : this("", traitValue)
        {
        }

        /// <summary>
        ///     Creates a genetic trait. A distinguishing quality or characteristic belonging to a GeneticAlgorithm.
        ///     When this constructor is used, TraitValue will be assigned a value of 1.0f
        /// </summary>
        /// <param name="traitName">Initial value for this trait (between 0 and 1)</param>
        public Trait(string traitName) : this(traitName, 1.0f)
        {
        }

        public string TraitName { get; }
        public float TraitValue { get; set; }

        /// <summary>
        ///     Get MlSharp object as dictionary
        /// </summary>
        /// <returns>Returns a dictionary that represents an MlSharp Object</returns>
        public override Dictionary<string, object> AsDictionary()
        {
            var dict = base.AsDictionary();
            dict.Add("trait_name", TraitName);
            dict.Add("trait_value", TraitValue);
            return dict;
        }
    }
}