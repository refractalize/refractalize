namespace Erlang {
    public class MergeSortMessage {
        public int[] Items;
        public Process<MergeSortMessage> Caller;
    }
}