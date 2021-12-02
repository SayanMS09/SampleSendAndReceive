using System;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Console.WriteLine(ip.ToString());
            Console.WriteLine("Hello World!");
        }
    }
}
