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
        /// Метод отправки Email одному или нескольким пользователям
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Http-ответ с кодом 200</returns>
        [HttpPost]
        public async Task<ActionResult> PostEmail([FromBody] PostEmailRequest request)
        {
            await _emailService.SendEmailAsync(request);
            return new OkResult();
        }

        /// <summary>
        /// Метод получения информации обо всех отправленных сообщениях
        /// </summary>
        /// <returns>Список информационных логов</returns>
        [HttpGet]
        public async Task<ActionResult<GetEmailsResponse>> GetEmails ()
        {
            var result = await _dbManager.GetMessageLogs();
            return new GetEmailsResponse(result);
        }
    }
}