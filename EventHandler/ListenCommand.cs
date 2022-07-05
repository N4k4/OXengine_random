using System;

namespace OXengine_random.EventHandler
{

    public delegate void ListenCommandHandler(string commandString);
    public class ListenCommand
    {

        public static void Listen(ListenCommandHandler LC)
        {
            //TODO:終了のためのあれこれの追加
            string? input;
            while (true)
            {
                input = Console.ReadLine();

                if (input == null || input.Length == 0)
                {
                    //何もしない
                }
                else
                {
                    //コマンド処理を発行する
                    LC(input);
                }
            }
        }

    }
}
