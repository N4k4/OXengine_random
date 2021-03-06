using System;
using OXengine_random;

namespace OXengine_random.Body
{


    //基本的な動作を管理するクラス
    public class Body
    {
        //盤面の保存
        Game.Board board = new Game.Board();
        //思考エンジン
        Game.Engine engine;


        //サーバーから送られてきたコマンドのQueue
        Queue<StECommand> StECommandQueue;

        //サーバーへ送るコマンドのQueue;
        //!使っていない
        // Queue<EtSCommand> EtSCommandQueue;
        //イベント
        public event EventHandler.ListenCommandHandler listenCommandHandler;
        public Body()
        {
            //初期化

            StECommandQueue = new Queue<StECommand>();

            // EtSCommandQueue = new Queue<EtSCommand>();

            engine = new Game.Engine();


            //イベントの登録
            listenCommandHandler += AcceptCommand;
            //ループ処理の開始
            //StEコマンド処理ループ
            Task.Run(() => processStECommandQueue());
            //コマンドの受付ループ
            Task.Run(() => EventHandler.ListenCommand.Listen(listenCommandHandler));
        }

        //コマンドテキストを受け付ける関数
        void AcceptCommand(string commandString)
        {
            //TODO:機能の実装

            // Console.WriteLine(commandString);

            //送信されたコマンドをコマンドオブジェクト化
            StECommand? StEC = StECommand.generateCommand(commandString);

            //TODO:未登録コマンドの処理
            if (StEC == null)
            {
                Console.Error.WriteLine("AcceptCommand:登録されていないStECommandを検出しました。[{0}]", commandString);
            }
            else
            {
                //送付されたコマンドをキューに追加
                StECommandQueue.Enqueue(StEC);
            }

        }

        //StEコマンドキューを処理する関数
        void processStECommandQueue()
        {

            //キューにたまっているコマンドを取り出し
            //TODO:ループの終了処理

            while (true)
            {
                if (StECommandQueue.Count != 0)//キューがたまっているとき
                {
                    //?取り出しからコマンド実行までの一連の流れを非同期化したい
                    //最初に入れられたコマンドを取り出す
                    StECommand StEC = StECommandQueue.Dequeue();

                    //入れられたコマンドを実行
                    // Console.WriteLine("コマンド実行:{0}",StEC.GetType());
                    //非同期でコマンドを処理する
                    Task.Run(() => processStECommand(StEC));
                }
            }
        }

        //StEコマンドを処理する関数
        void processStECommand(StECommand StEC)
        {

            //コマンドで場合分け
            //TODO:ほかのコマンドの場合分けの実装
            if (typeof(ox) == StEC.GetType())
            {
                //TODO:oxコマンドの処理の実装
                // Console.WriteLine("oxコマンドの受信");
                processOx((ox)StEC);
            }
            else if (typeof(isready) == StEC.GetType())
            {

                processIsready((isready)StEC);

            }
            else if (typeof(oxnewgame) == StEC.GetType())
            {

                processOxnewgame((oxnewgame)StEC);

            }
            else if (typeof(position) == StEC.GetType())
            {

                processPosition((position)StEC);

            }
            else if (typeof(go) == StEC.GetType())
            {

                processGo((go)StEC);

            }
            else if (typeof(stop) == StEC.GetType())
            {

                processStop((stop)StEC);

            }
            else if (typeof(quit) == StEC.GetType())
            {

                processQuit((quit)StEC);

            }
            else if (typeof(gameover) == StEC.GetType())
            {

                processGameover((gameover)StEC);

            }
        }

        //oxコマンドの処理
        void processOx(ox command)
        {
            //idコマンドの送信
            sendEtSCommand(new id(idType.name));
            sendEtSCommand(new id(idType.author));
            //!前処理が必要ならここでやっておくといいかも
            //oxokコマンドの送信
            sendEtSCommand(new oxok());
        }

        void processIsready(isready command)
        {
            //readyokの送信
            sendEtSCommand(new readyok());
        }

        void processOxnewgame(oxnewgame command)
        {
            //準備する
        }

        void processPosition(position command)
        {
            //処理
            board.setBoard(command);
        }

        void processGo(go command)
        {
            var move = engine.Go(command, board);
            if (move == null)
            {

            }
            else if (move != null)
            {
                sendEtSCommand(new bestmove((Game.move) move));
            }
        }

        void processStop(stop command)
        {
            var move = engine.Stop();
            if (move == null)
            {

            }
            else if (move != null)
            {
                sendEtSCommand(new bestmove((Game.move) move));
            }
        }

        void processQuit(quit command)
        {
            //TODO:終了前の準備処理を行う

            System.Environment.Exit(0);
        }

        void processGameover(gameover command)
        {

        }

        //EtSコマンドを送信する関数
        void sendEtSCommand(EtSCommand EtSC)
        {
            //コマンドをテキスト形式に変換して標準出力に流すだけ
            Console.WriteLine(EtSC.genCommandString());
        }
    }

}

