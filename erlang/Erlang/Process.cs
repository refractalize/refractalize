using System;

namespace Erlang {
    public abstract class IProcess {
        public abstract IScheduler Scheduler { get; set; }
        public abstract Yield Start();
    }

    public abstract class Process : IProcess {
        public override IScheduler Scheduler { get; set; }

        protected void Spawn(Process process) {
            Scheduler.Spawn(process);
        }
    }

    public abstract class Process<T> : Process {
        private MailBox<T> MailBox;

        protected Process() {
            MailBox = new MailBox<T>();
        }

        public void Send(T msg) {
            MailBox.AddMessage(msg);
        }

        protected Yield Receive(Func<T, Yield> continuation) {
            T message;
            if (MailBox.TryGetNextMessage(out message)) {
                return () => continuation(message);
            } else {
                return () => Receive(continuation);
            }
        }
    }
}