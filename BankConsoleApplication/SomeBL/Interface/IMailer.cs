namespace SomeBL.Interface
{
    public interface IMailer
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }

        bool SendMail(IMailClient mailClient);
    }
}