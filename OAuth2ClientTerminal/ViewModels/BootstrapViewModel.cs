using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2ClientTerminal.ViewModels
{
    public class BootstrapViewModel : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment => throw new NotImplementedException();

        public IScreen HostScreen => throw new NotImplementedException();
    }
}