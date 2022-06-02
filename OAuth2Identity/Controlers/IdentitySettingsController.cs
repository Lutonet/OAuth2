using Newtonsoft.Json;

namespace OAuth2Identity.Controlers
{
    public class IdentitySettingsController : IIdentitySettingsController
    {
        private static readonly string programDirectory = Directory.GetCurrentDirectory();
        private readonly string settingsFile = Path.Combine(programDirectory, "identity.json");

        public async Task<IdentityConfiguration> Load()
        {
            IdentityConfiguration config = new();
            if (!ConfigurationFileExists())
            {
                await CreateDeaultConfigurationFile();
            }
            try
            {
                string json = await File.ReadAllTextAsync(settingsFile);
                return JsonConvert.DeserializeObject<IdentityConfiguration>(json);
            }
            catch
            {
                throw;
            }
        }

        public async Task Save(IdentityConfiguration settings)
        {
            try
            {
                string settingsJson = JsonConvert.SerializeObject(settings);
                await File.WriteAllTextAsync(settingsFile, settingsJson);
            }
            catch
            {
                throw;
            }
        }

        private bool ConfigurationFileExists()
        {
            return File.Exists(Path.Combine(programDirectory, "identity.json"));
        }

        private async Task CreateDeaultConfigurationFile()
        {
            IdentityConfiguration settings = new IdentityConfiguration();
            string settingsJson = JsonConvert.SerializeObject(settings);
            try
            {
                await File.WriteAllTextAsync(settingsFile, settingsJson);
                return;
            }
            catch
            {
                throw;
            }
        }
    }
}