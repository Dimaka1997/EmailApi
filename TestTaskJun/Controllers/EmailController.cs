using Microsoft.AspNetCore.Mvc;
using TestTaskJun.Models;
using TestTaskJun.Interfaces;
using TestTaskJun.Models.DB;

namespace TestTaskJun.Controllers
{
    [ApiController]
    [Route("api/mails/")]
    public class EmailController : ControllerBase
    {

        private readonly IEmailService _emailService;
        private readonly IDbManager _dbManager;

        public EmailController(IEmailService emailService, IDbManager dbManager)
        {
            _emailService = emailService;
            _dbManager = dbManager;
        }

        /// <summary>
        /// ����� �������� Email ������ ��� ���������� �������������
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Http-����� � ����� 200</returns>
        [HttpPost]
        public async Task<ActionResult> PostEmail([FromBody] PostEmailRequest request)
        {
            await _emailService.SendEmailAsync(request);
            return new OkResult();
        }

        /// <summary>
        /// ����� ��������� ���������� ��� ���� ������������ ����������
        /// </summary>
        /// <returns>������ �������������� �����</returns>
        [HttpGet]
        public async Task<ActionResult<GetEmailsResponse>> GetEmails ()
        {
            var result = await _dbManager.GetMessageLogs();
            return new GetEmailsResponse(result);
        }
    }
}