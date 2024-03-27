using AIConductor.Interfaces;
using System.Reflection;

namespace AIConductor.Core
{
    public static class Conductor
    {
        public static List<IAgent> Agents { get; private set; } = [];
        public static List<ITask> Tasks { get; private set; } = [];
        public static List<ITool> Tools { get; private set; } = [];
        public static List<ITeam> Teams { get; private set; } = [];

        public static async Task Initialize()
        {
            await LoadPlugins();
        }

        internal static Task LoadPlugins()
        {
            var pluginsLoader = new PluginsLoader();

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var fixedAssemblies = new[] { "AIConductor.Agents.dll", "AIConductor.Tasks.dll", "AIConductor.Tools.dll", "AIConductor.Teams.dll" };

            foreach (var assemblyName in fixedAssemblies)
            {
                var assemblyPath = Path.Combine(baseDirectory, assemblyName);

                if (File.Exists(assemblyPath))
                {
                    try
                    {
                        var assembly = Assembly.LoadFrom(assemblyPath);

                        if (IsThirdPartyAssembly(assembly))
                        {
                            Agents.AddRange(pluginsLoader.LoadAgents(assembly));
                            Tasks.AddRange(pluginsLoader.LoadTasks(assembly));
                            Tools.AddRange(pluginsLoader.LoadTools(assembly));
                            Teams.AddRange(pluginsLoader.LoadTeams(assembly));
                        }
                    }
                    catch (Exception)
                    {
                        // TODO: Log the error
                    }
                }
                else
                {
                    // TODO: Log a warning or error indicating the fixed assembly file is missing
                }
            }

            var pluginsDirectory = Path.Combine(baseDirectory, "Plugins");

            if (Directory.Exists(pluginsDirectory))
            {
                var pluginAssemblies = Directory.GetFiles(pluginsDirectory, "*.dll");

                foreach (var assemblyPath in pluginAssemblies)
                {
                    try
                    {
                        var assembly = Assembly.LoadFrom(assemblyPath);

                        Agents.AddRange(pluginsLoader.LoadAgents(assembly));
                        Tasks.AddRange(pluginsLoader.LoadTasks(assembly));
                        Tools.AddRange(pluginsLoader.LoadTools(assembly));
                        Teams.AddRange(pluginsLoader.LoadTeams(assembly));
                    }
                    catch (Exception)
                    {
                        // TODO: Log the error
                    }
                }
            }

            return Task.CompletedTask;
        }

        private static bool IsThirdPartyAssembly(Assembly assembly)
        {
            return assembly.GetName().Name?.StartsWith("AIConductor.ThirdParty.") ?? false;
        }
    }
}
