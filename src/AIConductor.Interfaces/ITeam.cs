namespace AIConductor.Interfaces
{
    public interface ITeam
    {
        /// <summary>
        /// Unique identifier for the team.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Name of the team.
        /// </summary>
        string Name { get; }
    }
}
