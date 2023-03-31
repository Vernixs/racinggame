using System;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "GameServer";

            Server.Start(50, 29650);
            Console.ReadKey();
        }
    }
}

