using AIConductor.Interfaces;

namespace AIConductor.Core
{
    internal class Agent(string name, string role, string goal, string backstory) : IAgent
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; } = name;

        public string Role { get; private set; } = role;

        public string Goal { get; private set; } = goal;

        public string Backstory { get; private set; } = backstory;

        public int MaximumRequestsPerMinute { get; private set; } = 0;

        public bool HasMemory { get; private set; } = false;

        public bool Verbose { get; private set; } = false;

        public bool CanDelegate { get; private set; } = true;

        public List<Guid> Tools { get; private set; } = [];

        public int MaximumIterations { get; private set; } = 15;
    }
}
