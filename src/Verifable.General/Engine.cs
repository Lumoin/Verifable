using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Verifable.General
{
    public interface IDataSource
    {
        IObservable<int> GetNumbers();

        IObservable<int> GetNumbers2();
    }


    public class RealNumberGenerator: IDataSource
    {
        public IScheduler Scheduler { get; }

        public RealNumberGenerator(IScheduler scheduler)
        {
            Scheduler = scheduler;
        }

        public IObservable<int> GetNumbers()
        {
            return Observable.Range(1, 10);
        }
        public IObservable<int> GetNumbers2()
        {
            return Observable.Range(1, 10);
        }
    }


    public class Engine
    {
        public IScheduler Scheduler { get; }

        public IDataSource DataSource { get; }

        public Engine(IDataSource dataSource, IScheduler scheduler)
        {
            Scheduler = scheduler;
            DataSource = dataSource;
        }


        public IObservable<int> GetNumbers()
        {
            return DataSource.GetNumbers();
        }


        public IObservable<int> GetNumbers2()
        {
            return DataSource.GetNumbers2();
        }
    }
}
