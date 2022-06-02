using ReactiveUI;
using System.Reactive.Concurrency;
using Terminal.Gui;

namespace OAuth2ClientTerminal;

public static class Program
{
    private static async Task Main(string[] args)
    {
        Application.Init();
        RxApp.MainThreadScheduler = TerminalScheduler.Default;
        RxApp.TaskpoolScheduler = TaskPoolScheduler.Default;
        // Application.Run(new BootstrapView(new BootstrapViewModel()));
        Application.Shutdown();
    }
}