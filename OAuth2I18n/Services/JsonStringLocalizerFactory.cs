using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2I18n.Services
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IDistributedCache _cache;

        public JsonStringLocalizerFactory(IDistributedCache cache)
        {
            _cache=cache;
        }

        public IStringLocalizer Create(Type resourceSource) =>
            new JsonStringLocalizer(_cache);

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer(_cache);
        }
    }
}