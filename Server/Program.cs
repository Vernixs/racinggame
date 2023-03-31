using System;

namespace Server
{
    class PProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Game Server";
            PCserver.Start(50, 29650);
            Console.ReadKey();
        }
    }
}
