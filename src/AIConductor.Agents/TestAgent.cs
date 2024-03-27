using AIConductor.Interfaces;

namespace AIConductor.Agents
{
    internal class TestAgent : IAgent
    {
        public Guid Id => new("7D81B2B0-86A7-4A4D-9205-B40F25924270");

        public string Name => "Test Agent";

        public string Role => "Test Role";

        public string Goal => "Test Goal";

        public string Backstory => "Test Backstory";

        public int MaximumRequestsPerMinute => 0;

        public bool HasMemory => false;

        public bool Verbose => false;

        public bool CanDelegate => true;

        public List<Guid> Tools => [];

        public int MaximumIterations => 15;
    }
}
