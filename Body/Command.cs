using System;

namespace OXengine_random.Body
{
    //コマンドを一元管理する抽象クラス
    public abstract class Command
    {

    }



    //サーバーからエンジンに送られるコマンド
    public class StECommand : Command
    {

        //コマンドを空白で区切った後の文字列。送られてきた元のコマンドになる。

        protected string[] args=new string[0];

        public static StECommand? generateCommand(string commandString)
        {
            string[] Args = commandString.Split(' ');

            //コマンドタイプごとに振り分け

            switch (Args[0])
            {
                case "ox":
                    return new ox(Args);
                default:
                    return null;//TODO:未登録コマンドが送信されたときの処理
            }
        }
    }

    //ox
    public class ox : StECommand
    {
        internal ox(string[] args)
        {
            this.args = args;
        }
    }



    //エンジンからサーバーに送られるコマンド
    public class EtSCommand : Command
    {

    }
}
