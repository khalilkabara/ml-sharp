using System.Threading;
using ml_sharp.Enums.Genetics;
using ml_sharp.Genetics.Entities;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// This is a data class that defines the list of criteria required for reproduction
    /// </summary>
    public struct ReproductionInfo
    {
        private readonly int _numOffspring;
        private readonly float _mutationValue;
        private readonly EMutationEffect _mutationEffect;
        private readonly bool _withPartner;
        private readonly GeneticEntity _partner;
        private readonly string[] _offspringNames;
        private readonly int _seed;

        public int NumOffspring => _numOffspring;
        public float MutationValue => _mutationValue;
        public EMutationEffect MutationEffect => _mutationEffect;
        public bool WithPartner => _withPartner;
        public GeneticEntity Partner => _partner;
        public string[] OffspringNames => _offspringNames;
        public int Seed => _seed;
        
        /// <summary>
        /// Creates a ReproductionInfo object.
        /// </summary>
        /// <param name="numOffspring">Number of offspring to reproduce.</param>
        /// <param name="mutationValue">Determines the value by which mutation affects traits of resulting entity (between 0 and 1).</param>
        /// <param name="mutationEffect">Determines how mutation affects value traits inherited by offspring.
        /// (Positively, negatively, or randomly meaning some traits positively and some negatively at random).</param>
        /// <param name="withPartner">If or not breeding will occur with a partner entity.</param>
        /// <param name="partner">Partner entity to breed with.</param>
        /// <param name="offspringNames">Array of names to be given to resulting offspring (empty strings if not set).
        /// If length of names array is shorter than numOffspring, the first n offspring will be assigned names from this list
        /// and the rest set to an empty string.</param>
        /// <param name="seed">Seed for random generator. This is useful when trying to recreate outputs.
        /// When 0 is set, no seed is used. 0 is set by default</param>
        public ReproductionInfo(int numOffspring, float mutationValue, EMutationEffect mutationEffect, bool withPartner, 
            GeneticEntity partner, string[] offspringNames, int seed = 0)
        {
            _numOffspring = numOffspring;
            _mutationValue = mutationValue;
            _mutationEffect = mutationEffect;
            _withPartner = withPartner;
            _partner = partner;
            _offspringNames = offspringNames;
            _seed = seed;
        }
    }
}