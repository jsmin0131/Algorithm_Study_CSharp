using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(threadFunc);
            t.IsBackground = true;
            
            t.Start();
            t.Join();
        }

        static void threadFunc()
        {
            Console.WriteLine("5초 후에 프로그램 종료");
            Thread.Sleep(1000 * 5);

            Console.WriteLine("스레드 종료!");
        }
    }
}
