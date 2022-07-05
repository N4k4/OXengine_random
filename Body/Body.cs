using System;
using OXengine_random;

namespace OXengine_random.Body
{


    //基本的な動作を管理するクラス
    public class Body
    {
        //サーバーから送られてきたコマンドのQueue
        Queue<Command> commandQueue;
        //イベント
        public event EventHandler.ListenCommandHandler listenCommandHandler;
        public Body()
        {
            //初期化

            commandQueue = new Queue<Command>();


            //イベントの登録
            listenCommandHandler += AcceptCommand;
            //コマンドの受付の開始
            Task.Run(()=>EventHandler.ListenCommand.Listen(listenCommandHandler));
        }

        //コマンドテキストを受け付ける関数
        void AcceptCommand(string commandString)
        {
            //TODO:機能の実装

            Console.WriteLine(commandString);
        }

        //コマンドを処理する関数
        void proceccCommand(){

        }

    }
}
