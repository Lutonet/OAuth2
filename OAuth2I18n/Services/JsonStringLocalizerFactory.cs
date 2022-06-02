﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using OAuth2I18n.Models;

namespace OAuth2I18n.Services
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IDistributedCache _cache;
        private readonly I18nConfigurationModel _config;

        public JsonStringLocalizerFactory(IDistributedCache cache, I18nConfigurationModel config)
        {
            _cache=cache;
            _config = config;
        }

        public IStringLocalizer Create(Type resourceSource) =>
            new JsonStringLocalizer(_cache, _config);

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer(_cache, _config);
        }
    }
}