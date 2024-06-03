using Application.Interfaces.Utilities;

using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Unicode;
using System.Xml.Linq;

namespace Application.Utilities
{
    public class MailService : IMailService
    {
        IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendEmailGmail(String receptor,String asunto, String mensaje)
        {
            try
            {
                MailMessage mail = new MailMessage();
            
                string usermail = this.configuration["usuariogmail"];
                string passwordmail = this.configuration["passwordgmail"];

                mail.From = new MailAddress(usermail);
                mail.To.Add(new MailAddress(receptor)); 
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                string smtpserver = this.configuration["hostGmail"];
                int port = int.Parse(this.configuration["portGmail"]);
                bool ssl = bool.Parse(this.configuration["sslGmail"]);
                bool defaultcredentials = bool.Parse(this.configuration["defaultcredentialsGmail"]);

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = smtpserver;
                smtpClient.Port = port;
                smtpClient.EnableSsl = ssl;
                //smtpClient.UseDefaultCredentials = defaultcredentials;

 
                NetworkCredential usercredential = new NetworkCredential(usermail, passwordmail);
                smtpClient.Credentials = usercredential;
                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                var error = e; 
            }
        }
        // flag : se define el método outlook

        public async Task<string> getHtmlFileAsync(String filename)
        {
            string? ftpUrl = configuration["FTPSettings:Host"];
            string fullPath = $"{ftpUrl}{"Template/"}{filename}";
            string? ftpUsername = configuration["FTPSettings:Username"];
            string? ftpPassword = configuration["FTPSettings:Password"];

            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                byte[] fileData = await client.DownloadDataTaskAsync(fullPath);

                MemoryStream streamItem = new MemoryStream(fileData);

                // convert to string
                StreamReader reader = new StreamReader(streamItem);
                return reader.ReadToEnd();
            }
        }
        
        public static string ReplaceWithObjectProperties(string template, dynamic obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                string toReplace = $"{{{{{property.Name}}}}}";
                string replacement = Convert.ToString(property.GetValue(obj));
                template = template.Replace(toReplace, replacement);
            }

            return template;
        }

        internal static string ReplaceWithObjectProperties(Task<string> template, dynamic obj)
        {
            throw new NotImplementedException();
        }
    }  
}
