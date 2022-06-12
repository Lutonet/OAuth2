using Newtonsoft.Json;
using OAuth2Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Services
{
    public class JwtSettingsService : IJwtSettingsService
    {
        private string path = Path.Combine(AppContext.BaseDirectory, "jwtSettings.json");

        public async Task<JwtSettingsModel> Load()
        {
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<JwtSettingsModel>(File.ReadAllText(path));
            }
            else
            {
                try
                {
                    await Save(new JwtSettingsModel());
                    return new JwtSettingsModel();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error loading JwtSettingsModel", ex);
                }
            }
        }

        public async Task<JwtSettingsModel> Save(JwtSettingsModel model)
        {
            try
            {
                await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(model));
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving JwtSettingsModel", ex);
            }
        }
    }
}