using System;
using System.Linq;
using System.Text;

namespace Erlang {
    class Program {
        static void Main(string[] args) {
//            RunPingPong();
            RunMergeSort();
//            RunLotsOfProcesses();
        }

        private static void RunPingPong() {
            var scheduler = new Scheduler();

            var ping = new PingPong("ping");
            var pong = new PingPong("pong");

            ping.Friend = pong;
            pong.Friend = ping;

            scheduler.Spawn(ping, pong);
            scheduler.Schedule();
        }

        private static void RunLotsOfProcesses() {
            var scheduler = new Scheduler();

            scheduler.Spawn(new SpawnLots());
            scheduler.Schedule();
        }

        private static void RunMergeSort() {
            var scheduler = new Scheduler();

            var mergeSort = new MergeSort(new[] { 3, 4, 3, 2, 7, 5, 9, 0 });
            scheduler.Spawn(mergeSort);
            scheduler.Schedule();

            Console.WriteLine(String.Join(", ", mergeSort.Results.Select(i => i.ToString()).ToArray()));
        }
    }
}
