using System;

namespace Erlang {
    class PingPong : Process<string> {
        public Process<string> Friend { get; set; }
        private string Name;

        public PingPong(string name) {
            Name = name;
        }

        public override Yield Start() {
            Friend.Send(Name);
            return Receive(n => {
                Console.WriteLine(Name + " received message from " + n);
                return Start;
            });
        }
    }
}