namespace AIConductor.Interfaces
{
    public interface IAgent
    {
        /// <summary>
        /// Unique identifier for the agent.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Name of the agent.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Role of the agent.
        /// </summary>
        string Role { get;}

        /// <summary>
        /// Goal of the agent.
        /// </summary>
        string Goal { get; }

        /// <summary>
        /// Backstory of the agent.
        /// </summary>
        string Backstory { get; }

        /// <summary>
        /// Maximum number of requests the agent can make per minute.
        /// Set to 0 for unlimited.
        /// </summary>
        int MaximumRequestsPerMinute { get; }

        /// <summary>
        /// Determines if the agent has memory.
        /// </summary>
        bool HasMemory { get; }

        /// <summary>
        /// Determines if the agent is verbose.
        /// </summary>
        bool Verbose { get; }

        /// <summary>
        /// Determines if the agent can delegate tasks.
        /// </summary>
        bool CanDelegate { get; }

        /// <summary>
        /// List of tools the agent has access to.
        /// </summary>
        List<Guid> Tools { get; }

        /// <summary>
        /// Maximum number of iterations the agent can run for a task.
        /// </summary>
        int MaximumIterations { get; }
    }
}
