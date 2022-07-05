// See https://aka.ms/new-console-template for more information
using System;
using OXengine_random.Body;

namespace Programs
{

    class Program
    {
        public const string NAME = "OXengine_random";
        public const string AUTHOR = "Naka";
        public const string version = "0.0.0";
        static int Main(string[] args)
        {

            OXengine_random.Body.Body body = new Body();

            setup();
            while (true)
            {

                // Console.WriteLine("send message. if you send 'quit' then this program end.");
                // while(true){


                // string message = Console.ReadLine();
                // if (message == "quit") { Console.WriteLine("bye");return 0; }
                // if(!(message == null | message == ""))Console.Write("Leceived[{0}]\n", message);
                // }
            }
        }


        //起動時処理
        static void setup()
        {
            Console.WriteLine("OXengine_random version:{0}", version);
            //Environment.Exit(1);
            return;
        }
    }
}

