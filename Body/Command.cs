using System;

namespace OXengine_random.Body
{
    //コマンドを一元管理する抽象クラス
    public abstract class Command
    {
        //!コマンドの発行時刻を記録してもいいかもしれない
    }



    //サーバーからエンジンに送られるコマンド
    public class StECommand : Command
    {

        //コマンドを空白で区切った後の文字列。送られてきた元のコマンドになる。

        protected string[] args = new string[0];

        public StECommand(string[] args)
        {
            this.args = args;
        }

        public static StECommand? generateCommand(string commandString)
        {
            string[] Args = commandString.Split(' ');

            //コマンドタイプごとに振り分け

            switch (Args[0])
            {
                case "ox":
                    return new ox(Args);
                case "isready":
                    return new isready(Args);
                case "oxnewgame":
                    return new oxnewgame(Args);
                case "position":
                    return new position(Args);
                case "go":
                    return new go(Args);
                case "stop":
                    return new stop(Args);
                case "quit":
                    return new quit(Args);
                case "gameover":
                    return new gameover(Args);
                default:
                    return null;//TODO:未登録コマンドが送信されたときの処理
            }
        }
    }

    //ox
    public class ox : StECommand
    {
        public ox(string[] args) : base(args)
        {
            // this.args = args;
        }
    }

    //isready
    public class isready : StECommand
    {
        public isready(string[] args) : base(args)
        {
            // this.args = args;
        }
    }

    //oxnewgame
    public class oxnewgame : StECommand
    {
        public oxnewgame(string[] args) : base(args)
        {
            // this.args = args;
        }
    }

    //position
    public class position : StECommand
    {
        //TODO:動きの記録方法の追加
        public position(string[] args) : base(args)
        {
            //TODO:moveオプションからログを取得
        }
    }

    //go
    public class go : StECommand
    {
        int byouyomi;
        public go(string[] args) : base(args)
        {
            //TODO:ほかのオプションが追加されたときのために、コマンドの構文解釈をするように変更したい

            //!Parseに失敗したときの処理の追加
            byouyomi = int.Parse(args[2]);
        }
    }

    //stop
    public class stop : StECommand
    {
        public stop(string[] args) : base(args)
        {

        }
    }

    //quit
    public class quit : StECommand
    {
        public quit(string[] args) : base(args)
        {

        }
    }

    //gameover
    //ゲームオーバーの結果
    public enum gameoverType
    {
        win, lose, draw,
        unknown
    }
    public class gameover : StECommand
    {
        public gameoverType result { get; }
        public gameover(string[] args) : base(args)
        {
            //結果を取得
            switch (args[1])
            {
                case "win":
                    result = gameoverType.win;
                    break;
                case "lose":
                    result = gameoverType.lose;
                    break;
                case "draw":
                    result = gameoverType.draw;
                    break;
                case "unknown":
                    result = gameoverType.unknown;
                    break;
                default:
                    result = gameoverType.unknown;
                    break;
            }
        }
    }




    //エンジンからサーバーに送られるコマンド
    public abstract class EtSCommand : Command
    {
        //それぞれのコマンドについて、標準出力に流すテキスト形式に変換する関数
        public abstract string genCommandString();
    }

    public enum idType
    {
        name, author
    }

    //idコマンド
    public class id : EtSCommand
    {
        idType idType;
        public id(idType idT)
        {
            this.idType = idT;
        }

        public override string genCommandString()
        {
            if (idType == idType.name)
            {
                return "id name " + Programs.Program.NAME;
            }
            else if (idType == idType.author)
            {
                return "id author " + Programs.Program.AUTHOR;
            }
            else
            {
                return "";
            }
        }
    }

    //oxokコマンド
    public class oxok : EtSCommand
    {
        public oxok()
        {

        }

        public override string genCommandString()
        {
            return "oxok";
        }
    }

    //readyok
    public class readyok : EtSCommand
    {
        public readyok()
        {

        }

        public override string genCommandString()
        {
            return "readyok";
        }
    }

    //bestmove
    //!未実装
    public class bestmove : EtSCommand
    {

        //TODO:動きを受け付ける
        //TODO:降参を適切に受け付ける
        public bestmove()
        {

        }

        public bestmove(int a)
        {

        }

        public override string genCommandString()
        {
            return "bestmove ";
        }

    }

}
