using OAuth2I18n.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2I18n.Services
{
    public class I18nSettingsController
    {
        /**
         * Working with own JSON file, which it creates
         * during the first run
         *  Load Settings,
         *  Save Settings,
         *  Monitor File Size
         */
        private static readonly string programDirectory = Directory.GetCurrentDirectory();
        private readonly string settingsFile = Path.Combine(programDirectory, "i18n.json");

        public async Task<I18nConfigurationModel> Load()
        {
            I18nConfigurationModel config = new();
            if (!ConfigurationFileExists())
            {
                await CreateDeaultConfigurationFile();
            }
        }

        public async Task Save(I18nConfigurationModel settings)
        {
        }

        private bool ConfigurationFileExists()
        {
            return File.Exists(Path.Combine(programDirectory, "i18n.json"));
        }

        private async Task CreateDeaultConfigurationFile()
        {
            I18nConfigurationModel settings = new I18nConfigurationModel();
            settings.DefaultLaungauge="en";
            settings.LanguagesSupported=LibreLanguages;
        }

        private List<LanguageModel> LibreLanguages = new List<LanguageModel>();
    }
}