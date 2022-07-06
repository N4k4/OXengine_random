using System;
using OXengine_random.Body;

namespace OXengine_random.Game
{
    public class Board
    {
        //順序に情報がないので、盤面状況だけを保持する
        //自身の駒を0,相手の駒を1とする。
        public int[,] body;
        //ボードデータのアクセスは必ずロックされた状態で行うこと
        object LockObj;

        public Board()
        {
            body = new int[3, 3];
            LockObj = new object();

            //盤面の初期化
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    body[i, j] = -1;
                }
            }
        }

        public void setBoard(position command)
        {
            lock (LockObj)
            {
                if (command.move != null)//初期盤面から変化があるとき
                {
                    //最後の手が相手の手であることを使って、最初の手がどちらのものかを判別。
                    int currentTurn=(command.move.Length+1) % 2;

                    foreach(string positionString in command.move){

                        // Console.WriteLine("{0},{1}",positionString[0]-'a',positionString[1]-'1');

                        body[positionString[0]-'a',positionString[1]-'1']=currentTurn;
                        currentTurn = (currentTurn+1)%2;
                    }
                }
            }
        }

        //書き込み作業中は取り出さない。
        public int[,] getBoard(){
            int[,] obj;
            lock(LockObj){
                obj = body;
            }
            return obj;
        }
    }
}
