namespace AIConductor.Interfaces
{
    public interface ITool
    {
        /// <summary>
        /// Unique identifier for the tool.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Name of the tool.
        /// </summary>
        string Name { get; }
    }
}
