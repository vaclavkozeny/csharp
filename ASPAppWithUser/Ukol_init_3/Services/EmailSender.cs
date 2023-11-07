using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using Azure.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;


namespace Ukol_init_3.Services
{
    public class EmailSender : IEmailSender
    {
        readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string text)
        {
            /* create message header + body */
            var message = new Message
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = text
                },
                ToRecipients = new List<Recipient>()
                {
                    new Recipient {EmailAddress = new EmailAddress {Address = email } }
                }
            };
            /* make MS Graph API connection */
            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };
            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            }; var authProvider = new ClientSecretCredential(
                _configuration["EmailSender:TenantId"],
                _configuration["EmailSender:ClientId"],
                _configuration["EmailSender:ClientSecret"],
                options);
            //var authProvider = new ClientCredentialProvider(confidentialClientApplication);
            var graphClient = new GraphServiceClient(authProvider);
            /* send email over Graph API Mail.Send */
            await graphClient.Users[_configuration["EmailSender:UserId"]]
                .SendMail(message, false)
                .Request()
                .PostAsync();
        }
    }
}

