﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2I18n.Models
{
    public class I18nConfigurationModel
    {
        public string TranslationsLocation { get; set; } = "/I18n";
        public string DefaultLaungauge { get; set; } = "en";
        public List<LanguageModel> LanguagesSupported { get; set; }
    }
}