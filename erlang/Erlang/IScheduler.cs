namespace Erlang {
    public interface IScheduler {
        int ProcessCount { get; }
        void Spawn(params IProcess[] processes);
    }
}