namespace ml_sharp.Genetics
{
    public struct ReproductionInfo
    {
        private readonly int _numOffspring;
        private readonly string[] _offspringNames;
        private readonly float _minMutation;
        private readonly float _maxMutation;
        private readonly bool _returnAsGeneration;
        private readonly string _generationName;

        public int NumOffspring => _numOffspring;
        public string[] OffspringNames => _offspringNames;
        public float MinMutation => _minMutation;
        public float MaxMutation => _maxMutation;
        public bool ReturnAsGeneration => _returnAsGeneration;
        public string GenerationName => _generationName;
        
        public ReproductionInfo(int numOffspring, string[] offspringNames, float minMutation, float maxMutation,
            bool returnAsGeneration = false, string generationName = "")
        {
            _numOffspring = numOffspring;
            _offspringNames = offspringNames;
            _minMutation = minMutation;
            _maxMutation = maxMutation;
            _returnAsGeneration = returnAsGeneration;
            _generationName = generationName;
        }
    }
}