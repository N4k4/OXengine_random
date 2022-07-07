using System;

namespace OXengine_random.Game
{
    //思考エンジン
    public class Engine
    {
        //現在思考中かどうかを記録
        public bool isThinking { get; private set; }
        //stopコマンドが立った時に立ち上げる。
        bool stopFlag;

        //現時点での候補を格納
        move candidate;

        public Engine()
        {
            isThinking = false;
            stopFlag = false;
            candidate = new move(0,0);
        }

        //思考開始
        public move? Go(Body.go command,Board board)
        {

            isThinking = true;
            //中断フラグが立つまで思考する
            //TODO:制限時間が近づいたら切り上げる
            while(!stopFlag){
                Random rnd = new Random();
                candidate = new move(rnd.Next(3),rnd.Next(3));

                if(board.checkMove(candidate)){
                    isThinking = false;
                    return candidate;
                }

            }
            isThinking = false;
            stopFlag = false;
            return null;
        }

        //思考中止
        //現時点での候補を返す
        public move? Stop()
        {
            if (isThinking == true)
            {
                isThinking = false;
                stopFlag = true;
                return candidate;
            }
            else
            {
                return null;//現在思考中でない時はnullを返す
            }

        }


    }
}
