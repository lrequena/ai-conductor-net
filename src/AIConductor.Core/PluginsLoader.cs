using AIConductor.Interfaces;
using System.Reflection;

namespace AIConductor.Core
{
    internal class PluginsLoader
    {
        public IEnumerable<IAgent> LoadAgents(Assembly assembly)
        {
            return LoadImplementations<IAgent>(assembly);
        }

        public IEnumerable<ITask> LoadTasks(Assembly assembly)
        {
            return LoadImplementations<ITask>(assembly);
        }

        public IEnumerable<ITool> LoadTools(Assembly assembly)
        {
            return LoadImplementations<ITool>(assembly);
        }

        public IEnumerable<ITeam> LoadTeams(Assembly assembly)
        {
            return LoadImplementations<ITeam>(assembly);
        }

        private IEnumerable<T> LoadImplementations<T>(Assembly assembly) where T : class
        {
            var targetType = typeof(T);
            var implementations = assembly.GetTypes()
                .Where(t => targetType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var implementation in implementations)
            {
                if (Activator.CreateInstance(implementation) is T instance)
                {
                    yield return instance;
                }
            }
        }
    }
}
