using System.Reactive;
using System.Reactive.Linq;
using Microsoft.Reactive.Testing;
using Verifable.General;

namespace Verifable.IntegrationTests
{
    // A simple implementation of IDataSource that uses ReplaySubject for testing
    public class TestDataSource: IDataSource
    {
        private readonly IObservable<int> numbers;

        public TestDataSource(IObservable<int> numbers)
        {
            this.numbers = numbers;
        }

        public IObservable<int> GetNumbers()
        {
            return numbers;
        }

        public IObservable<int> GetNumbers2()
        {
            return Observable.Empty<int>(); // You can customize this as needed
        }
    }


    [TestClass]
    public class EngineTests
    {
        private static readonly int[] expected = new[] { 1, 2, 3 };

        [TestMethod]
        public void EngineShouldReturnNumbersFromDataSource()
        {
            // Arrange
            var testScheduler = new TestScheduler();

            // Create a cold observable that emits numbers at specific simulated times
            var messages = new[]
            {
                new Recorded<Notification<int>>(TimeSpan.FromSeconds(1).Ticks, Notification.CreateOnNext(1)),
                new Recorded<Notification<int>>(TimeSpan.FromSeconds(2).Ticks, Notification.CreateOnNext(2)),
                new Recorded<Notification<int>>(TimeSpan.FromSeconds(3).Ticks, Notification.CreateOnNext(3)),
                new Recorded<Notification<int>>(TimeSpan.FromSeconds(4).Ticks, Notification.CreateOnCompleted<int>())
            };

            var numbersObservable = testScheduler.CreateColdObservable(messages);

            // Create a test data source with the arranged data
            var testDataSource = new TestDataSource(numbersObservable);

            // Create the engine with the test data source and scheduler
            var engine = new Engine(testDataSource, testScheduler);

            // Act
            var emittedValues = new List<int>();
            _ = engine.GetNumbers().Subscribe(emittedValues.Add); // Subscribe to capture emitted values

            // Move the scheduler forward by 5 seconds to simulate time passage
            testScheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks);

            // Assert
            CollectionAssert.AreEqual(expected, emittedValues);
        }
    }
}
