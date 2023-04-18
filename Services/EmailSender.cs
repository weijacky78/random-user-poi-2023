using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace places_webapi.Services;

public class EmailSender : IMessageService
{

    public void SendEmail(string from, string fromAddr, string to, string toAddr, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(from, fromAddr));
        message.To.Add(new MailboxAddress(to, toAddr));
        message.Subject = subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = body };

        using var client = new SmtpClient();
        client.Connect("localhost", 1025, false);
        // client.Authenticate("febf2d556f8b49", "e400597334c6d2");
        client.Send(message);
        client.Disconnect(true);
    }
}