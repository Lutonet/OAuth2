using ReactiveUI;

namespace OAuth2ClientTerminal.ViewModels
{
    public class BootstrapViewModel : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment => throw new NotImplementedException();

        public IScreen HostScreen => throw new NotImplementedException();
    }
}