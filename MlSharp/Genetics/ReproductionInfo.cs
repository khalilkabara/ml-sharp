using ml_sharp.Genetics.Entities;

namespace ml_sharp.Genetics
{
    /// <summary>
    /// This is a data class that defines the list of criteria required for reproduction
    /// </summary>
    public struct ReproductionInfo
    {
        private readonly int _numOffspring;
        private readonly float _minMutation;
        private readonly float _maxMutation;
        private readonly bool _withPartner;
        private readonly GeneticEntity _partner;
        private readonly string[] _offspringNames;
        private readonly int _seed;

        public int NumOffspring => _numOffspring;
        public float MinMutation => _minMutation;
        public float MaxMutation => _maxMutation;
        public bool WithPartner => _withPartner;
        public GeneticEntity Partner => _partner;
        public string[] OffspringNames => _offspringNames;
        public int Seed => _seed;
        
        /// <summary>
        /// Creates a ReproductionInfo object.
        /// </summary>
        /// <param name="numOffspring">Number of offspring to reproduce</param>
        /// <param name="minMutation"></param>
        /// <param name="maxMutation"></param>
        /// <param name="withPartner"></param>
        /// <param name="partner"></param>
        /// <param name="offspringNames"></param>
        /// <param name="seed"></param>
        public ReproductionInfo(int numOffspring, float minMutation, float maxMutation, bool withPartner, 
            GeneticEntity partner, string[] offspringNames, int seed = -1)
        {
            _numOffspring = numOffspring;
            _minMutation = minMutation;
            _maxMutation = maxMutation;
            _withPartner = withPartner;
            _partner = partner;
            _offspringNames = offspringNames;
            _seed = seed;
        }
    }
}