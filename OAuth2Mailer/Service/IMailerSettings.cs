using OAuth2Mailer.Model;

namespace OAuth2Mailer.Service
{
    public interface IMailerSettings
    {
        Task<SMTPSettings> Load();
        Task<Result> Save(SMTPSettings settings);
    }
}