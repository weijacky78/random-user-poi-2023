namespace places_webapi.Services;

public interface IMessageService
{
    public void SendEmail(string from, string fromAddr, string to, string toAddr, string subject, string body);
}