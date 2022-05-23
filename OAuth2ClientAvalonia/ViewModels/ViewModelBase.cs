using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2ClientAvalonia.ViewModels
{
    public class ViewModelBase : ReactiveObject, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();
    }
}