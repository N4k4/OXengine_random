// See https://aka.ms/new-console-template for more information
using System;

namespace Programs
{

    class Program
    {
        const string version = "0.0.0";
        static int Main(string[] args)
        {

            setup();
            while (true)
            {


                Console.WriteLine("send message. if you send 'quit' then this program end.");
                while(true){

                
                string message = Console.ReadLine();
                if (message == "quit") { Console.WriteLine("bye");return 0; }
                if(!(message == null | message == ""))Console.Write("Leceived[{0}]\n", message);
                }
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

