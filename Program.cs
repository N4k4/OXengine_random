// See https://aka.ms/new-console-template for more information
using System;

namespace Programs
{
    
    class Program
    {
        const string version = "0.0.0";
        static void Main(string[] args)
        {

            setup();

            Console.WriteLine("Hello World!");
        }

        
        //起動時処理
        static void setup(){
            Console.WriteLine("OXengine_random version:{0}",version);
            //Environment.Exit(1);
            return;
        }
    }
}

