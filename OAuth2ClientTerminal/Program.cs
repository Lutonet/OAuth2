using System.Reactive.Concurrency;
using ReactiveUI;
using Terminal.Gui;
using OAuth2ClientTerminal.ViewModels;
using OAuth2ClientTerminal.Views;

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