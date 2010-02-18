using System.Linq;

namespace Erlang {
    public class MergeSorter : Process<MergeSortMessage> {
        public override Yield Start() {
            return Receive(qs => {
                               if (qs.Items.Length <= 1) {
                                   qs.Caller.Send(new MergeSortMessage { Items = qs.Items });
                                   return null;
                               } else {
                                   int split = qs.Items.Length / 2;
                                   int[] first = qs.Items.Take(split).ToArray();
                                   int[] second = qs.Items.Skip(split).ToArray();

                                   var firstProcess = new MergeSorter();
                                   firstProcess.Send(new MergeSortMessage { Caller = this, Items = first });
                                   Spawn(firstProcess);
                                   var secondProcess = new MergeSorter();
                                   secondProcess.Send(new MergeSortMessage { Caller = this, Items = second });
                                   Spawn(secondProcess);

                                   return Receive(result1 => Receive(result2 => {
                                                                         qs.Caller.Send(new MergeSortMessage { Items = Merge(result1.Items, result2.Items) });
                                                                         return null;
                                                                     }));
                               }
                           });
        }

        internal static int[] Merge(int[] items1, int[] items2) {
            var merged = new int[items1.Length + items2.Length];

            int i1 = 0, i2 = 0;
            for (int m = 0; m < merged.Length; m++) {
                if (items1.Length <= i1) {
                    merged[m] = items2[i2++];
                } else if (items2.Length <= i2) {
                    merged[m] = items1[i1++];
                } else if (items1[i1] < items2[i2]) {
                    merged[m] = items1[i1++];
                } else {
                    merged[m] = items2[i2++];
                }
            }

            return merged;
        }
    }
}