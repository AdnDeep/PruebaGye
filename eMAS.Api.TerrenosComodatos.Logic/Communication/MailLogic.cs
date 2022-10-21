using eMAS.Api.TerrenosComodatos.ViewModel;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Logic.Communication
{
    public class MailLogic
    {
        private readonly MailSettings _settings;

        public MailLogic(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task<ResultadoDTO<bool>> SendAsync(MailData mailData, CancellationToken ct = default)
        {
            ResultadoDTO<bool> respuesta = new ResultadoDTO<bool>();
            try
            {
                // Initialize a new instance of the MimeKit.MimeMessage class
                var mail = new MimeMessage();

                #region Sender / Receiver
                // Sender
                mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

                // Receiver
                foreach (string mailAddress in mailData.To)
                    mail.To.Add(MailboxAddress.Parse(mailAddress));

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }
                #endregion

                #region Content

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail

                using var smtp = new SmtpClient();

                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.CheckCertificateRevocation = false;
                if (_settings.UseSSL)
                {
                    await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
                }
                else if (_settings.UseStartTls)
                {
                    await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
                }

                await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
                await smtp.SendAsync(mail, ct);
                await smtp.DisconnectAsync(true, ct);

                respuesta.dataresult = true;
                respuesta.mensaje = "OK";
                return respuesta;
                #endregion

            }
            catch (Exception ex)
            {
                respuesta.dataresult = false;
                respuesta.mensaje = "ERROR";
                respuesta.mensajes = respuesta.mensajes ?? new List<Mensaje>();
                respuesta.mensajes.Add(new Mensaje { codigo = "INTERNO", tipo = "ADVERTENCIA", descripcion = ex.Message });
                return respuesta;
            }
        }
        
        public string GetEmailTemplate<T>(string emailTemplate, string pathBase, T emailTemplateModel)
        {
            string mailTemplate = LoadTemplate(emailTemplate, pathBase);
            string mailOutput = "";
            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate modifiedMailTemplate = null;
            try
            {
                modifiedMailTemplate = razorEngine.Compile(mailTemplate,
                    builder =>
                    {
                        builder.AddAssemblyReferenceByName("System.Collections");
                        builder.AddAssemblyReferenceByName("System.Linq");
                    }
                );
                mailOutput = modifiedMailTemplate.Run(emailTemplateModel);
            }
            catch (Exception)
            {
                throw;
            }


            return mailOutput;
        }

        public string LoadTemplate(string emailTemplate, string pathBase)
        {
            string baseDir = pathBase;
                //AppDomain.CurrentDomain.BaseDirectory;
            string templateDir = Path.Combine(baseDir, "MailTemplates");
            string templatePath = Path.Combine(templateDir, $"{emailTemplate}.cshtml");

            using FileStream fileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

            string mailTemplate = streamReader.ReadToEnd();
            streamReader.Close();

            return mailTemplate;
        }
        
    }
}
