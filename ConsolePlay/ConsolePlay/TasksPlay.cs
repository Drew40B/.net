using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePlay
{
    public class TasksPlay : IPlayable
    {
        private int _active;
        object _activeLock = new object();
        public bool Play()
        {

            int count = 50;

            //for (int x = 0; x < count; x++)
            //{
            //    var x1 = x;
            //    Task.Run(() => MyTask(x1));
            //}

            var tasks = new List<int>();

            for (int x = 0; x < count; x++)
            {
                int realx = x;
                tasks.Add(x);
            }


            BlockingCollection<int> col = new BlockingCollection<int>(3);

            Task.Run(() =>
            {
                foreach (var task in tasks)
                {
                    col.Add(task);
                }

                col.CompleteAdding();
            });

            var worker = new Action(() =>
            {
                while (!col.IsCompleted)
                {
                    var t = col.Take();
                    MyTask(t).Wait();
                }
            });

            var realTasks = new List<Task>();

            for (int x = 0; x < 5; x++)
            {
               realTasks.Add(Task.Run(worker));
            }


            Task.WaitAll(realTasks.ToArray());
            //Parallel.For(0, 1000,new ParallelOptions() {MaxDegreeOfParallelism  = 10},async (i,state) => await MyTask(i));


            return true;
        }


        public async Task MyTask(int id)
        {

            int active;
            lock (_activeLock)
            {
                active = ++_active;
            }

            Console.WriteLine($"Start: {id} ({active})");
            await Task.Delay(1000);
            // Thread.Sleep(50);

            lock (_activeLock)
            {
                active = --_active;
            }
            Console.WriteLine($"Stop: {id} ({active})");

        }
    }




}
