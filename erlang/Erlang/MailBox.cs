using System.Collections.Generic;

namespace Erlang {
    public class MailBox<T> {
        private Queue<T> Messages;

        public MailBox() {
            Messages = new Queue<T>();
        }

        public void AddMessage(T message) {
            Messages.Enqueue(message);
        }

        public bool TryGetNextMessage(out T message) {
            if (Messages.Count > 0) {
                message = Messages.Dequeue();
                return true;
            } else {
                message = default(T);
                return false;
            }
        }
    }
}