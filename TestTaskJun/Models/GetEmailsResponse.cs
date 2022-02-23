using TestTaskJun.Models.DB;
namespace TestTaskJun.Models
{
    public class GetEmailsResponse
    {
        public List<EmailInfo> Emails { get; set; }

        public GetEmailsResponse (List <MessageLogEntity> entities)
        {
            Emails = entities.ConvertAll(x => new EmailInfo(x)).ToList();
        }
    }
}
