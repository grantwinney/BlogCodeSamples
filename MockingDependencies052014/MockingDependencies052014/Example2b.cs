using System.Net.Mail;
using Moq;
using NUnit.Framework;

namespace MockingDependencies052014
{
    public class Example2b
    {
        private readonly ISmtpClient client;

        public Example2b()
        {
            client = new SmtpClientEx("smtp.somehost.com", 465);
        }

        public Example2b(ISmtpClient client)
        {
            this.client = client;
        }

        public void ProcessShipment()
        {
            // Do some work related to processing shipments

            var message = new MailMessage("shipping@acme.com", "wecoyote@rr.com", "Your order has shipped!", "Your order has shipped!");

            client.Send(message);
        }

        public interface ISmtpClient
        {
            void Send(MailMessage message);
        }

        public class SmtpClientEx : SmtpClient, ISmtpClient
        {
            public SmtpClientEx(string host, int port)
                : base(host, port) { }
        }

        [TestFixture]
        public class Example2bTester
        {
            private Mock<ISmtpClient> clientMock;

            [SetUp]
            public void Setup()
            {
                clientMock = new Mock<ISmtpClient>();
            }

            [Test]
            public void ProcessShipment_SendsMessage()
            {
                var vm = new Example2b(clientMock.Object);

                vm.ProcessShipment();

                clientMock.Verify(x => x.Send(It.IsAny<MailMessage>()), Times.Once());
            }
        }
    }
}
