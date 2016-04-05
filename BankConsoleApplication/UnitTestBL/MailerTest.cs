using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SomeBL;
using SomeBL.Interface;

namespace UnitTestBL
{
    [TestClass]
    public class MailerTest
    {
        //[TestMethod]
        public void DefaultMailer_Send_True()
        {
            //Create a mock object of a MailClient class which implements IMailClient
            var mockMailClient = new Moq.Mock<IMailClient>();

            //Mock the properties of MailClient
            mockMailClient.SetupProperty(client => client.Server, "gmail.com").SetupProperty(client => client.Port, "1111");

            //Configure dummy method so that it return true when it gets any string as parameters to the method
            mockMailClient.Setup(client => client.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            IMailer mailer = new DefaultMailer() { From = "from@mail.com", To = "to@mail.com", Subject = "Using Moq", Body = "Moq is awesome" };

            //Use the mock object of MailClient instead of actual object
            var result = mailer.SendMail(mockMailClient.Object);

            //Verify that it return true
            Assert.IsTrue(result);

            //Verify that the MailClient's SendMail methods gets called exactly once when string is passed as parameters
            mockMailClient.Verify(client => client.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
