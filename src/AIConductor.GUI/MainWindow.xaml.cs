using AIConductor.Core;
using AIConductor.Extensions;
using AIConductor.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace AIConductor.GUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<IAgent> Agents { get; } = [];
    public ObservableCollection<ITask> Tasks { get; } = [];
    public ObservableCollection<ITool> Tools { get; } = [];
    public ObservableCollection<ITeam> Teams { get; } = [];

    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;

        Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        await InitializeConductor();
    }

    private async Task InitializeConductor()
    {
        await Conductor.Initialize();

        Agents.AddRange(Conductor.Agents);
        Tasks.AddRange(Conductor.Tasks);
        Tools.AddRange(Conductor.Tools);
        Teams.AddRange(Conductor.Teams);
    }
}