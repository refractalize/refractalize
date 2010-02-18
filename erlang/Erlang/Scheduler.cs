using System.Collections.Generic;

namespace Erlang {
    public class Scheduler : IScheduler {
        private List<Yield> Processes;

        public Scheduler() {
            Processes = new List<Yield>();
        }

        public int ProcessCount {
            get {
                return Processes.Count;
            }
        }

        public void Schedule() {
            while (Processes.Count > 0) {
                for (int p = 0; p < Processes.Count; p++) {
                    Processes[p] = Processes[p]();
                }

                Processes.RemoveAll(p => p == null);
            }
        }

        public void Spawn(params IProcess[] processes) {
            foreach (var process in processes) {
                process.Scheduler = this;
                Processes.Add(process.Start);
            }
        }
    }
}