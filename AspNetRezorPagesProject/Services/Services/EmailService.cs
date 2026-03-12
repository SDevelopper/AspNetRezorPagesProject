using AspNetRezorPagesProject.Services.Interfaces;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using MimeKit;
using MailKit.Security;


namespace AspNetRezorPagesProject.Services.Services
{
    public class EmailService(
        IConfiguration config
        ) : IEmailService
    {
        public async Task SendPasswordResetEmailAsync(string email, string resetLink)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(
                config["Smtp:DisplayName"],
                config["Smtp:User"]!));

            message.To.Add(new MailboxAddress("", email));

            message.Subject = "Сброс пароля";

            BodyBuilder builder = new()
            {
                HtmlBody = $@"
                <h3>Восстановление пароля</h3>
                <p>Для сброса пароля перейдите по ссылке ниже:</p>
                <a href='{resetLink}'>Сбросить пароль</a>
                <p>Если вы не запрашивали сброс, просто проигнорируйте это письмо.</p>"
            };

            message.Body = builder.ToMessageBody();

            await SendAsync(message);
        }

        private async Task SendAsync(MimeMessage message)
        {
            var client = new SmtpClient
            {
                ServerCertificateValidationCallback =
                (sender, certificate, chain, errors) => true
            };

            await client.ConnectAsync(
                config["Smtp:Host"],
                int.Parse(config["Smtp:Port"]!),
                SecureSocketOptions.SslOnConnect);

            await client.AuthenticateAsync(
                config["Smtp:User"],
                config["Smtp:Password"]);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
