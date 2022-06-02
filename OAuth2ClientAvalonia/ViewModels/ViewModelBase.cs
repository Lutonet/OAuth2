using ReactiveUI;

namespace OAuth2ClientAvalonia.ViewModels
{
    public class ViewModelBase : ReactiveObject, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();
    }
}