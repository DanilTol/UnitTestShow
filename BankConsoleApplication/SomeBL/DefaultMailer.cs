using SomeBL.Interface;

namespace SomeBL
{
    public class DefaultMailer : IMailer
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public bool SendMail(IMailClient mailClient)
        {
            return mailClient.SendMail(this.From, this.To, this.Subject, this.Body);
        }
    }
}