using System;
using OXengine_random.Body;

namespace OXengine_random.Game
{
    public class Board
    {
        //順序に情報がないので、盤面状況だけを保持する
        int[,] body;
        //ボードデータのアクセスは必ずロックされた状態で行うこと
        object LockObj;

        public Board(){
            body = new int[3,3];
            LockObj=new object();
        }

        public void setBoard(position command){
            
            //
            lock(LockObj){

            }
        }
    }
}
