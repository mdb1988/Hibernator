namespace Hibernator.General
{
    public interface IWorker
    {
        //void CheckIdleTime();
        //void Listen();
        void Update(int timeout);
        void Work();
    }
}
