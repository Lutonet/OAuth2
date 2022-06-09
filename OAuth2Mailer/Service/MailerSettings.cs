using Newtonsoft.Json;
using OAuth2Mailer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Mailer.Service
{
    public class MailerSettings
    {
        private string path = Path.Combine(Directory.GetCurrentDirectory(), "mailer.json");

        public async Task<SMTPSettings> Load()
        {
            if (File.Exists(path))
            {
                string json = await File.ReadAllTextAsync(path);
                return JsonConvert.DeserializeObject<SMTPSettings>(json);
            }
            else
            {
                return new SMTPSettings();
            }
        }

        public async Task<Result> Save(SMTPSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            try
            {
                await File.WriteAllTextAsync(path, json);
                return new Result();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Result() { Successfull = false, Message = ex.Message };
            }
        }
    }
}