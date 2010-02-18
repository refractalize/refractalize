using NUnit.Framework;

namespace Erlang.Tests {
    [TestFixture]
    public class MailBoxTest {
        [Test]
        public void ShouldReturnMessageWhenOneAvailable() {
            var mailbox = new MailBox<string>();
            mailbox.AddMessage("hi");

            string message;
            Assert.That(mailbox.TryGetNextMessage(out message));
            Assert.That(message, Is.EqualTo("hi"));
        }

        [Test]
        public void ShouldReturnFalseIfNoMessages() {
            var mailbox = new MailBox<string>();

            string message;
            Assert.That(mailbox.TryGetNextMessage(out message), Is.False);
        }

        [Test]
        public void ShouldReturnMessagesInOrderTheyWereAdded() {
            var mailbox = new MailBox<string>();
            mailbox.AddMessage("one");
            mailbox.AddMessage("two");

            string message;
            Assert.That(mailbox.TryGetNextMessage(out message));
            Assert.That(message, Is.EqualTo("one"));

            Assert.That(mailbox.TryGetNextMessage(out message));
            Assert.That(message, Is.EqualTo("two"));
        }
    }
}
