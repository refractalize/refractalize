using System;

namespace Erlang {
    public class MergeSort : Process<MergeSortMessage> {
        private readonly int[] Items;
        public int[] Results { get; set; }

        public MergeSort(int[] items) {
            Items = items;
        }

        public override Yield Start() {
            var mergeSorter = new MergeSorter();
            mergeSorter.Send(new MergeSortMessage {Caller = this, Items = Items});

            Spawn(mergeSorter);

            return Receive(m => {
                               Results = m.Items;
                               return null;
                           });
        }
    }
}