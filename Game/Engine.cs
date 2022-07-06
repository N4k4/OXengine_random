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
        (int, int) candidate;

        Engine()
        {
            isThinking = false;
            stopFlag = false;
            candidate = (0, 0);
        }

        //思考開始
        (int, int)? Go(Board board)
        {

            isThinking = true;
            //中断フラグが立つまで思考する
            while(!stopFlag){

            }
            stopFlag = false;
            return null;
        }

        //思考中止
        //現時点での候補を返す
        (int, int)? Stop()
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
