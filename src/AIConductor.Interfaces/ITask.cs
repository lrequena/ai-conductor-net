namespace AIConductor.Interfaces
{
    public interface ITask
    {
        /// <summary>
        /// Unique identifier for the task.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Name of the task.
        /// </summary>
        string Name { get; }
    }
}
