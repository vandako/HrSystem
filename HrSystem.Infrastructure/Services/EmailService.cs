/*using HrSystem.Core.DTOs;
using HrSystem.Core.Enums;
using HrSystem.Core.Interfaces.Repositories;
using HrSystem.Core.Interfaces.Services;
using HrSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CustomerForms.Core.DTOs;


namespace HrSystem.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppUrl _appUrl;
        private readonly MailConfiguration _mailSettings;
        private readonly ILoggerService<EmailService> _loggerService;
        private readonly IEmailLogRepository emailLogRepository;
        public EmailService(IEmailLogRepository emailLogRepositor, AppUrl appUrl, MailConfiguration mailConfiguration, ILoggerService<EmailService> loggerService)
        {
            this._appUrl = appUrl;
            _mailSettings = mailConfiguration;
            _loggerService = loggerService;
            emailLogRepository = emailLogRepositor;
        }


        public async Task<bool> Send(EmailRequestModel model)
        {
            // string master = await File.ReadAllTextAsync(Constants.MasterTemplate);
            //master = master.Replace("[Content]", model.Body);
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {
                message.IsBodyHtml = true;
                MailAddress fromAddress = new MailAddress(_mailSettings.MailFrom, model.SenderDisplayName ?? _mailSettings.MailFromName);
                message.From = fromAddress;


                if (_appUrl.EnvMode != EnvMode.Live.ToString())
                {
                    foreach (var to in model.DestinationEmail)
                    {
                        message.To.Add(new MailAddress(to.Key.ToLower().Replace("lafarge", "yopmail").Replace("holcim", "yopmail").Replace("lafargeholcim", "yopmail"), to.Value.ToLower().Replace("lafarge", "yopmail").Replace("lafargeholcim", "yopmail").Replace("gmail", "yopmail").Replace("yahoo", "yopmail").Replace("holcim", "yopmail")));
                    }
                }
                else
                {
                    foreach (var to in model.DestinationEmail)
                    {
                        message.To.Add(new MailAddress(to.Key, to.Value));
                    }

                }


                //foreach (var to in model.Bcc)
                //{
                //    message.Bcc.Add(new MailAddress(to.Key, to.Value));


                //}
                if (_appUrl.EnvMode != EnvMode.Live.ToString())
                {
                    foreach (var to in model.Bcc)
                    {
                        message.Bcc.Add(new MailAddress(to.Key.ToLower().Replace("lafarge", "yopmail").Replace("holcim", "yopmail").Replace("lafargeholcim", "yopmail"), to.Value.ToLower().Replace("lafarge", "yopmail").Replace("lafargeholcim", "yopmail").Replace("holcim", "yopmail")));
                    }
                }
                else
                {
                    foreach (var to in model.Bcc)
                    {
                        message.Bcc.Add(new MailAddress(to.Key, to.Value));
                    }

                }
                //message.Bcc.Add(new MailAddress("kehinde.oshungboye@lafarge.com", "kehinde.oshungboye@lafarge.com"));
                message.Bcc.Add(new MailAddress("uduak.umanah.ext@lafarge.com", "uduak.umanah.ext@lafarge.com"));


                //foreach (var to in model.Cc)
                //{
                //    message.CC.Add(new MailAddress(to.Key, to.Value));
                //}

                if (_appUrl.EnvMode != EnvMode.Live.ToString())
                {
                    foreach (var to in model.Cc)
                    {
                        message.CC.Add(new MailAddress(to.Key.ToLower().Replace("lafarge", "yopmail").Replace("holcim", "yopmail").Replace("lafargeholcim", "yopmail"), to.Value.ToLower().Replace("lafarge", "yopmail").Replace("lafargeholcim", "yopmail").Replace("holcim", "yopmail")));
                    }
                }
                else
                {
                    foreach (var to in model.Cc)
                    {
                        message.CC.Add(new MailAddress(to.Key, to.Value));
                    }

                }





                _loggerService.LogInformation("About to compose attachment");
                if (model.Attachments != null)
                {
                    if (model.AttachmentType == MailAttachmentType.Excel.ToString())
                    {
                        message.Attachments.Add(new Attachment(model.Attachments, model.AttachmentFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                    }
                    else if (model.AttachmentType == MailAttachmentType.TextFile.ToString())
                    {
                        message.Attachments.Add(new Attachment(model.Attachments, "Attached.txt", "text/plain"));

                    }
                }



                message.Subject = model.Subject;
                message.Body = model.Body;// master;
                message.IsBodyHtml = true;

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Host = _mailSettings.SMTPServer;
                smtpClient.Port = _mailSettings.SMTPPort;
                //  smtpClient.Credentials = new System.Net.NetworkCredential(_mailSettings.SMTPUserName, _mailSettings.SMTPPassword); //not neccessary
                //  smtpClient.EnableSsl = true;
                // smtpClient.UseDefaultCredentials = true;
                smtpClient.Send(message);

                try
                {
                    await emailLogRepository.Create(new EmailLogDto
                    {
                        Recipient = message.To[0].Address,
                        Subject = message.Subject,
                        MailBody = message.Body,
                        MailFromName = message.From.DisplayName,
                        MailFrom = message.From.Address,
                        Date = DateTime.Now,
                        Status = "Succesful",
                        SMTPServer = _mailSettings.SMTPServer,
                        SMTPPort = _mailSettings.SMTPServer,
                        StatusMessage = "Succesful"


                    });
                }
                catch (Exception ex) { _loggerService.LogError(ex); }
                return true;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex);

                try
                {
                    await emailLogRepository.Create(new EmailLogDto
                    {
                        Recipient = message.To[0].Address,
                        Subject = message.Subject,
                        MailBody = message.Body,
                        MailFromName = message.From.DisplayName,
                        MailFrom = message.From.Address,
                        Date = DateTime.Now,
                        Status = "Failed",
                        SMTPServer = _mailSettings.SMTPServer,
                        SMTPPort = _mailSettings.SMTPServer,
                        StatusMessage = ex.Message



                    });
                }
                catch (Exception exx) { _loggerService.LogError(exx); }

                return false;
            }
            finally
            {
                smtpClient.Dispose();
                message.Dispose();
            }
        }
        private byte[] ConvertStringToByteArray(string byteString)
        {
            // string byteString = "48-65-6C-6C-6F";
            string[] strArray = byteString.Split('-');
            byte[] byteArray = new byte[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(strArray[i], 16);
            }
            return byteArray;

        }
    }
}*/
