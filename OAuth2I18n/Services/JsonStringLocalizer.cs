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
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly IDistributedCache _cache;
        private readonly JsonSerializer _serializer = new JsonSerializer();

        public JsonStringLocalizer(IDistributedCache cache)
        {
            _cache = cache;
        }

        public LocalizedString this[string name]
        {
            get
            {
                string value = GetString(name);
                return new LocalizedString(name, value ?? name, value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                LocalizedString actualValue = this[name];
                return !actualValue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(actualValue.Value, arguments), false)
                    : actualValue;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            string filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower()}.json";
            if (!File.Exists(filePath))
            {
                // TODO create empty language file, return English
            }
        }
    }
}