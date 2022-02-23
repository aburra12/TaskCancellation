using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellation
{
    internal class RandomGenerator
    {
        public string Name {get; set;}
        public int BaseNumber {get; set;} = 23;
        public int MaxNumber { get; set; } = 1000;
        public int DelayMSecond { get; set; } = 2000;
        public int TryCount { get; set; } = 10;

        public RandomGenerator() {
            Name =  Guid.NewGuid().ToString();
        }

        public RandomGenerator(string name) {
            Name = name;
        }

        public Task CreateTask(CancellationToken token) 
        {
            return Task.Run(()=> {
                var random = new Random();
                int cnt = 0;
                while (true) {
                    token.ThrowIfCancellationRequested();
                    if (++cnt > TryCount) 
                        throw new TimeoutException("Task time out.");
                    var anInteger = random.Next(1, MaxNumber);
                    Console.WriteLine($"Generator {Name}: {anInteger}");
                    if (anInteger % BaseNumber == 0) {
                        Console.WriteLine($"{Name} generator done.");
                        break;
                    }
                    Thread.Sleep(DelayMSecond);
                }
            }, token);
        }
    }
}