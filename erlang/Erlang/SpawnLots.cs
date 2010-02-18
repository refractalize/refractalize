using System;

namespace Erlang {
    class SpawnLots : Process {
        public override Yield Start() {
            return () => {
                       Console.WriteLine("number of processes: {0}", Scheduler.ProcessCount);
                       Spawn(new SpawnLots());
                       return Start;
                   };
        }
    }
}