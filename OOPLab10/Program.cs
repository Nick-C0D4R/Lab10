using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPLab10
{
    internal class Program
    {
        public static Queue<int> _queue = new Queue<int>();


        static void Main(string[] args)
        {
            object locker = new object();

            Thread thread1 = new Thread(() =>
            {
                Random rand = new Random();
                lock (_queue)
                {
                    Console.WriteLine(Thread.CurrentThread.Name);
                    for (int i = 0; i < 10; i++)
                    {
                        _queue.Enqueue(rand.Next(-100, 101));
                    }
                }

            });
            thread1.Name = "Thread 1";
            Thread thread2 = new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name);
                foreach(int number in _queue)
                {
                    Console.Write($"{number} | ");
                }
            });
            thread2.Name = "Thread 2";

            thread1.Start();
            thread2.Start();
            
        }
    }
}
