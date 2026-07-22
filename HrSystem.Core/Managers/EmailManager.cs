/*using HrSystem.Core.DTOs;
using HrSystem.Core.Enums;
using HrSystem.Core.Interfaces.Managers;
using HrSystem.Core.Interfaces.Services;
using HrSystem.Core.Models;
using HrSystem.Core.Interfaces.Managers;
using HrSystem.Core.Interfaces.Services;
using HrSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Core.Managers
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailService emailService;
        private readonly AppUrl _appUrl;
        private readonly ILoggerService<EmailManager> _loggerService;
        public EmailManager(IEmailService emailService, AppUrl appUrl
            //  ILoggerService<EmailManager> loggerService
            )
        {
            this.emailService = emailService;
            _appUrl = appUrl;
            //  _loggerService = loggerService;
        }

        public async Task<bool> SendLoginCode(AppUserDto user, string code, string subject)
        {
            var filecontent = System.IO.File.ReadAllText("EmailTemplates/LoginMail.html");
            filecontent = filecontent.Replace("##Code", code);
            filecontent = filecontent.Replace("##FirstName", user.FirstName);


            await emailService.Send(new EmailRequestModel
            {
                //Attachement = att,
                Body = filecontent,
                Subject = subject,
                DestinationEmail = new Dictionary<string, string>() { { user.Email, user.FirstName }
                    },

            });

            return true;

        }
    }
}*/