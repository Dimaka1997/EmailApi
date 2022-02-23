using System.Net;
using System.Net.Mail;
using System.Configuration;
using TestTaskJun.Settings;
using Microsoft.Extensions.Options;
using TestTaskJun.Models;
using TestTaskJun.Models.Enums;
using TestTaskJun.Models.DB;
using TestTaskJun.Interfaces;
namespace TestTaskJun.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly IDbManager _dbManager;
        public EmailService (IOptions<SmtpSettings> smtpSettings, IDbManager dbManager)
        {
            _smtpSettings = smtpSettings.Value;
            _dbManager = dbManager;
        }

        public async Task SendEmailAsync(PostEmailRequest model)
        {
            var answer = String.Empty;
            var to = string.Join(", ", model.Recipients);
            EmailResultEnum result = EmailResultEnum.Ok;
            try
            {
                using var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port);
                smtpClient.EnableSsl = _smtpSettings.EnableSsl;
                smtpClient.Credentials = new System.Net.NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                await smtpClient.SendMailAsync(_smtpSettings.SourceEmail, to, model.Subject, model.Body);
            }
            catch (Exception ex)
            {
                answer = ex.Message;
                result = EmailResultEnum.Failed;
            }
            finally
            {
                var log = new MessageLogEntity()
                {
                    Body = model.Body,
                    Subject = model.Subject,
                    Recipients = to,
                    Result = result.ToString(),
                    FailedMessage = answer,
                    Created = DateTime.Now
                };
                await _dbManager.InsertMessageLog(log);
            }
        }
    }
}
